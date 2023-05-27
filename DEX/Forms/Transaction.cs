using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX.Forms
{
    public partial class Transaction : Form
    {
        private readonly ObjectId _id;
        private readonly string _coin;
        private readonly double _price;
        private readonly double _amount;
        private readonly double _sum;
        private readonly string _lotType;
        private readonly string _user;
        private readonly string _lotDate;
        private readonly UserCredentials _userCredentials;
        private readonly string _address;

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
            btnDone.Enabled = false;

            var database = DBManager.GetDatabase();

            var filterTransactionUser = Builders<BsonDocument>.Filter.Eq("username", tbUser.Text);
            var filterCurUser = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);

            var users = database.GetCollection<BsonDocument>("Users");
            var operations = database.GetCollection<BsonDocument>("Operations");

            var transactionUser = await users.Find(filterTransactionUser).FirstOrDefaultAsync();
            var curUser = await users.Find(filterCurUser).FirstOrDefaultAsync();

            var curUserBalanceUSD = curUser.GetValue("balanceUSD").AsDouble;
            var sellerBalanceUSD = transactionUser.GetValue("balanceUSD").AsDouble;

            var curUserCoinWallet = curUser.GetValue("wallets").AsBsonDocument.GetValue(_coin.ToLower()).AsBsonDocument;
            var sellerCoinWallet = transactionUser.GetValue("wallets").AsBsonDocument.GetValue(_coin.ToLower()).AsBsonDocument;

            var curUserPrivateKey = curUserCoinWallet.GetValue("privateKey").AsString;

            if (_lotType == "Продажа")
            {
                if (curUserBalanceUSD >= _sum)
                {
                    curUserBalanceUSD -= _sum;

                    if (tbPrivateKey.Text != curUserPrivateKey)
                    {
                        MessageBox.Show("Неправильный приватный ключ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    curUserCoinWallet["balance"] = curUserCoinWallet.GetValue("balance").AsDouble + _amount;
                    sellerCoinWallet["balance"] = sellerCoinWallet.GetValue("balance").AsDouble - _amount;

                    var updateCurUser = Builders<BsonDocument>.Update
                        .Set("balanceUSD", curUserBalanceUSD -= _sum)
                        .Set($"wallets.{_coin.ToLower()}.balance", curUserCoinWallet["balance"]);

                    var updateSeller = Builders<BsonDocument>.Update
                        .Set("balanceUSD", sellerBalanceUSD += _sum)
                        .Set($"wallets.{_coin.ToLower()}.balance", sellerCoinWallet["balance"]);

                    await users.UpdateOneAsync(filterCurUser, updateCurUser);
                    await users.UpdateOneAsync(filterTransactionUser, updateSeller);

                    MessageBox.Show("Транзакция успешно завершена.");

                    var lots = database.GetCollection<BsonDocument>("Lots");
                    var lotsFilter = Builders<BsonDocument>.Filter.Eq("_id", _id);

                    await lots.DeleteOneAsync(lotsFilter);

                    var operationDoc = new BsonDocument
                    {
                        { "amount", _amount },
                        { "buyerUsername", _userCredentials.Username },
                        { "sellerUsername", transactionUser.GetValue("username").AsString },
                        { "coinAbbr", _coin },
                        { "price", _price },
                        { "date", DateTime.Now },
                        { "status", "done" },
                        { "totalPrice", _amount * _price },
                        { "commision", (_amount * _price) * 0.05 }
                    };

                    await operations.InsertOneAsync(operationDoc);

                    this.DialogResult = DialogResult.OK;
                }
            }
            else if (_lotType == "Покупка")
            {
                curUserBalanceUSD += _sum;

                if (tbPrivateKey.Text != curUserPrivateKey)
                {
                    MessageBox.Show("Неправильный приватный ключ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                curUserCoinWallet["balance"] = curUserCoinWallet.GetValue("balance").AsDouble - _amount;
                sellerCoinWallet["balance"] = sellerCoinWallet.GetValue("balance").AsDouble + _amount;

                var updateCurUser = Builders<BsonDocument>.Update
                       .Set("balanceUSD", curUserBalanceUSD += _sum)
                       .Set($"wallets.{_coin.ToLower()}.balance", curUserCoinWallet["balance"]);

                var updateSeller = Builders<BsonDocument>.Update
                    .Set("balanceUSD", sellerBalanceUSD -= _sum)
                    .Set($"wallets.{_coin.ToLower()}.balance", sellerCoinWallet["balance"]);

                await users.UpdateOneAsync(filterCurUser, updateCurUser);
                await users.UpdateOneAsync(filterTransactionUser, updateSeller);

                MessageBox.Show("Транзакция успешно завершена.");

                var lots = database.GetCollection<BsonDocument>("Lots");
                var lotsFilter = Builders<BsonDocument>.Filter.Eq("_id", _id);

                await lots.DeleteOneAsync(lotsFilter);

                this.DialogResult = DialogResult.OK;
            }
            btnDone.Enabled = true;
        }
    }
}
