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
        private string _id;
        private string _coin;
        private double _price;
        private double _amount;
        private double _sum;
        private string _lotType;
        private string _user;
        private string _lotDate;
        private UserCredentials _userCredentials;

        public Transaction(string id, string coin, double price, double amount, double sum, string type, string user, string lotDate, UserCredentials userCredentials)
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
            tbId.Text = _id;
            tbCoin.Text = _coin;
            tbPrice.Text = _price.ToString();
            tbAmount.Text = _amount.ToString();
            tbSum.Text = _sum.ToString();
            tbType.Text = _lotType;
            tbUser.Text = _user;
            tbDate.Text = _lotDate;

            if (_lotType == "Покупка")
                btnDone.Text = "Продать";
        }

        private async void btnDone_Click(object sender, EventArgs e)
        {
            var database = DBManager.GetDatabase();

            var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
            var collection = database.GetCollection<BsonDocument>("Users");

            var userDocument = await collection.Find(filter).FirstOrDefaultAsync();

            var balanceUSD = userDocument.GetValue("balanceUSD").AsDouble;

            if (_lotType == "Продажа")
            {
                if (balanceUSD >= _sum)
                {
                    balanceUSD -= _sum;

                    var update = Builders<BsonDocument>.Update
                                .Set("balanceUSD", balanceUSD);

                    await collection.UpdateOneAsync(filter, update);

                    MessageBox.Show("Транзакция успешно завершена.");

                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
