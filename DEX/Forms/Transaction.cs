using DEX.UserControls;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX.Forms
{
    public partial class Transaction : Form
    {
        private ObjectId _id;
        private string _coin;
        private double _price;
        private double _amount;
        private double _sum;
        private string _lotType;
        private string _user;
        private string _lotDate;
        private UserCredentials _userCredentials;
        private string _address;

        public Transaction(ObjectId id, string coin, double price, double amount, double sum, string type, string user, string lotDate, UserCredentials userCredentials, string address)
        {
            InitializeComponent();

            _id = id;
            _coin = coin;
            _price = price;
            _amount = amount;
            _sum = sum;
            _lotType = type;
            _user = user;
            _lotDate = lotDate;
            _userCredentials = userCredentials;
            _address = address;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.ForeColor = Color.White;
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            tbId.Text = _id.ToString();
            tbCoin.Text = _coin;
            tbPrice.Text = _price.ToString();
            tbAmount.Text = _amount.ToString();
            tbSum.Text = _sum.ToString();
            tbType.Text = _lotType;
            tbUser.Text = _user;
            tbDate.Text = _lotDate;
            tbAddress.Text = _address;

            if (_lotType == "Покупка")
                btnDone.Text = "Продать";
        }

        private async void btnDone_Click(object sender, EventArgs e)
        {
            var database = DBManager.GetDatabase();

            var filterTransactionUser = Builders<BsonDocument>.Filter.Eq("username", tbUser.Text);
            var filterCurUser = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);

            var collection = database.GetCollection<BsonDocument>("Users");

            var seller = await collection.Find(filterTransactionUser).FirstOrDefaultAsync();
            var curUser = await collection.Find(filterCurUser).FirstOrDefaultAsync();

            if (_lotType == "Продажа")
            {
                var curBalanceUSD = curUser.GetValue("balanceUSD").AsDouble;
                var sellerBalanceUSD = seller.GetValue("balanceUSD").AsDouble;

                if (curBalanceUSD >= _sum)
                {
                    curBalanceUSD -= _sum;

                    var buyerCoinWallet = curUser.GetValue("wallets").AsBsonDocument.GetValue(_coin.ToLower()).AsBsonDocument;
                    var sellerCoinWallet = seller.GetValue("wallets").AsBsonDocument.GetValue(_coin.ToLower()).AsBsonDocument;

                    buyerCoinWallet["balance"] = buyerCoinWallet.GetValue("balance").AsDouble + _amount;
                    sellerCoinWallet["balance"] = sellerCoinWallet.GetValue("balance").AsDouble - _amount;

                    var updateCurUser = Builders<BsonDocument>.Update
                        .Set("balanceUSD", curBalanceUSD -= _sum)
                        .Set($"wallets.{_coin.ToLower()}.balance", buyerCoinWallet["balance"]);

                    var updateSeller = Builders<BsonDocument>.Update
                        .Set("balanceUSD", sellerBalanceUSD += _sum)
                        .Set($"wallets.{_coin.ToLower()}.balance", sellerCoinWallet["balance"]);

                    await collection.UpdateOneAsync(filterCurUser, updateCurUser);
                    await collection.UpdateOneAsync(filterTransactionUser, updateSeller);

                    MessageBox.Show("Транзакция успешно завершена.");

                    var lots = database.GetCollection<BsonDocument>("Lots");
                    var lotsFilter = Builders<BsonDocument>.Filter.Eq("_id", _id);

                    await lots.DeleteOneAsync(lotsFilter);

                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
