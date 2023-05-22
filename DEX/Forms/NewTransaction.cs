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
    public partial class NewTransaction : Form
    {
        private UserCredentials _userCredentials;

        public NewTransaction(UserCredentials userCredentials)
        {
            InitializeComponent();

            _userCredentials = userCredentials;
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

        private void cbCoin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cryptoCurrency = cbCoin.SelectedItem.ToString();

            string walletAddress = GetWallet(cryptoCurrency);
            tbAddress.Text = walletAddress;

            double price = GetPrice(cryptoCurrency);
            tbPrice.Text = price.ToString();
        }

        private string GetWallet(string cryptoCurrency)
        {
            var database = DBManager.GetDatabase();
            var collection = database.GetCollection<BsonDocument>("Users");

            var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
            var projection = Builders<BsonDocument>.Projection.Include("wallets." + cryptoCurrency.ToLower() + ".address");
            var result = collection.Find(filter).Project(projection).FirstOrDefault();

            string walletAddress = result["wallets"][cryptoCurrency.ToLower()]["address"].AsString;

            return walletAddress;
        }

        private double GetPrice(string cryptoCurrency)
        {
            var database = DBManager.GetDatabase();
            var collection = database.GetCollection<BsonDocument>("Coins");

            var filter = Builders<BsonDocument>.Filter.Eq("abbr", cryptoCurrency);
            var result = collection.Find(filter).FirstOrDefault();
            double price = result["price"].AsDouble;

            return price;
        }

        private void NewTransaction_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            tbDate.Text = currentDate.ToString("dd/MM/yyyy");
            tbUser.Text = _userCredentials.Username;
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tbPrice.Text, out double price) && double.TryParse(tbAmount.Text, out double amount))
            {
                double sum = price * amount;
                tbSum.Text = sum.ToString();
            }
        }

        private void tbSum_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tbPrice.Text, out double price) && double.TryParse(tbSum.Text, out double sum))
            {
                double amount = sum / price;
                tbAmount.Text = amount.ToString();
            }
        }

        public class Lot
        {
            public string coin { get; set; }
            public double price { get; set; }
            public double amount { get; set; }
            public double sum { get; set; }
            public string type { get; set; }
            public string user { get; set; }
            public DateTime date { get; set; }
            public string wallet { get; set; }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var newLot = new Lot
            {
                coin = cbCoin.Text,
                price = double.Parse(tbPrice.Text),
                amount = double.Parse(tbAmount.Text),
                sum = double.Parse(tbSum.Text),
                type = cbType.Text,
                user = tbUser.Text,
                date = DateTime.Parse(tbDate.Text),
                wallet = tbAddress.Text
            };

            if (string.IsNullOrEmpty(newLot.coin) ||
                newLot.price <= 0 ||
                newLot.amount <= 0 ||
                newLot.sum <= 0 ||
                string.IsNullOrEmpty(newLot.type) ||
                string.IsNullOrEmpty(newLot.user) ||
                newLot.date == default(DateTime) ||
                string.IsNullOrEmpty(newLot.wallet))
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }

            if (newLot.type == "Продажа" && !HasSufficientFunds(newLot.coin, newLot.amount))
            {
                MessageBox.Show($"Недостаточно средств на балансе {newLot.coin}.");
                return;
            }

            var database = DBManager.GetDatabase();
            var collection = database.GetCollection<Lot>("Lots");

            collection.InsertOne(newLot);

            MessageBox.Show("Лот был успешно добавлен.");

            DialogResult = DialogResult.OK;

            this.Close();
        }

        private bool HasSufficientFunds(string cryptoCurrency, double requestedAmount)
        {
            double walletBalance = GetBalance(cryptoCurrency);

            return walletBalance >= requestedAmount;
        }

        private double GetBalance(string cryptoCurrency)
        {
            var database = DBManager.GetDatabase();
            var collection = database.GetCollection<BsonDocument>("Users");

            var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
            var projection = Builders<BsonDocument>.Projection.Include("wallets." + cryptoCurrency.ToLower() + ".balance");
            var result = collection.Find(filter).Project(projection).FirstOrDefault();

            double walletBalance = result["wallets"][cryptoCurrency.ToLower()]["balance"].AsDouble;

            return walletBalance;
        }
    }
}
