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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX.Forms
{
    public partial class EditWallet : Form
    {
        private UserCredentials _userCredentials;
        private string _address;
        private string _currency;

        public string Address { get; set; }

        public EditWallet(UserCredentials userCredentials, string address, string currency)
        {
            InitializeComponent();

            _userCredentials = userCredentials;
            _address = address;
            _currency = currency;
        }

        private void EditWallet_Load(object sender, EventArgs e)
        {
            tbAddress.Text = _address;
            tbAddress.ForeColor = Color.Gray;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.ForeColor = Color.White;
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (_currency == "eth")
            {
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^0x[a-fA-F0-9]{40}$"))
                {
                    MessageBox.Show("Неправильный формат ETH-счета");
                    return;
                }
            }
            else if (_currency == "btc")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                {
                    return;
                }
                if (tbAddress.Text.Length < 26 || tbAddress.Text.Length > 35)
                {
                    return;
                }
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^[13][a-km-zA-HJ-NP-Z1-9]{25,34}$"))
                {
                    MessageBox.Show("Неправильный формат BTC-счета");
                    return;
                }
            }

            var database = DBManager.GetDatabase();
            var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
            var update = Builders<BsonDocument>.Update.Set($"wallets.{_currency}.address", tbAddress.Text);

            var collection = database.GetCollection<BsonDocument>("Users");

            this.Enabled = false;

            try
            {
                await collection.UpdateOneAsync(filter, update);

                this.Address = tbAddress.Text;

                MessageBox.Show("Реквизиты успешно сохранены");

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
            finally
            {
                this.Enabled = true;
            }
        }
    }
}
