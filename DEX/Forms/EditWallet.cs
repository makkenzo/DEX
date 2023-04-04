using MongoDB.Bson;
using MongoDB.Driver;
using NBitcoin;
using Nethereum.Signer;
using Nethereum.Util;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX.Forms
{
    public partial class EditWallet : Form
    {
        private UserCredentials _userCredentials;
        private string _address;
        private string _currency;

        private string _privateKey;

        public string Address { get; set; }
        public string PrivateKey { get; set; }

        public EditWallet(UserCredentials userCredentials, string address, string currency, string privateKey)
        {
            InitializeComponent();

            _userCredentials = userCredentials;
            _address = address;
            _currency = currency;
            _privateKey = privateKey;
        }

        private void EditWallet_Load(object sender, EventArgs e)
        {
            tbAddress.Text = _address;
            tbAddress.ForeColor = Color.Gray;

            tbPrivateKey.Text = _privateKey;

            toolTip1.SetToolTip(tbPrivateKey, "Приватный ключ (privateKey) - это секретная информация, которая используется для подписи транзакций и доступа к вашему Ethereum кошельку.\n" +
                                              "Никогда не делитесь своим приватным ключом с кем-либо и не храните его в открытом виде на своем компьютере.\n" +
                                              "Если злоумышленник получит ваш приватный ключ, он сможет управлять вашими средствами на Ethereum.\n" +
                                              "Обязательно сохраните свой приватный ключ в безопасном месте и не забудьте его.");

            if (_privateKey == "")
            {
                if (_currency == "eth")
                {
                    return;
                }
                tbPrivateKey.Enabled = false;
                label1.Enabled = false;
                btnPrivateKeyShowToggle.Enabled = false;
            }
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

        private void TextBox_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.SelectAll();
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (_currency == "eth")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^0x[a-fA-F0-9]{40}$"))
                {
                    MessageBox.Show("Неправильный формат ETH-счета");
                    return;
                }
            }
            else if (_currency == "btc")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (tbAddress.Text.Length < 26 || tbAddress.Text.Length > 35)
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^[13][a-km-zA-HJ-NP-Z1-9]{25,34}$"))
                {
                    MessageBox.Show("Неправильный формат BTC-счета");
                    return;
                }
            }
            else if (_currency == "usdt" || _currency == "usdc")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^0x[0-9a-fA-F]{40}$"))
                {
                    MessageBox.Show("Неправильный формат USDT/USDC-счета");
                    return;
                }
            }
            else if (_currency == "xrp")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), @"^r[0-9a-zA-Z]{33}$"))
                {
                    MessageBox.Show("Неправильный формат XRP-счета");
                    return;
                }
            }
            else if (_currency == "ltc")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^[LM3][a-km-zA-HJ-NP-Z1-9]{26,33}$"))
                {
                    MessageBox.Show("Неправильный формат LTC-счета");
                    return;
                }
            }
            else if (_currency == "dai")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^0x[0-9a-fA-F]{40}$"))
                {
                    MessageBox.Show("Неправильный формат DAI-счета");
                    return;
                }
            }
            else if (_currency == "sol")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^[1-9a-zA-Z]{32,44}$"))
                {
                    MessageBox.Show("Неправильный формат SOL-счета");
                    return;
                }
            }
            else if (_currency == "busd")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^0x[0-9a-fA-F]{40}$"))
                {
                    MessageBox.Show("Неправильный формат BUSD-счета");
                    return;
                }
            }
            else if (_currency == "ada")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text, "^addr1[0-9a-zA-Z]{57}$"))
                {
                    MessageBox.Show("Неправильный формат ADA-счета");
                    return;
                }
            }

            if (_currency != "eth")
            {
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
            else
            {
                var database = DBManager.GetDatabase();
                var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
                var update = Builders<BsonDocument>.Update
                    .Set("wallets.eth.address", tbAddress.Text)
                    .Set("wallets.eth.privateKey", tbPrivateKey.Text);

                var collection = database.GetCollection<BsonDocument>("Users");

                this.Enabled = false;

                try
                {
                    await collection.UpdateOneAsync(filter, update);

                    this.Address = tbAddress.Text;
                    this.PrivateKey = tbPrivateKey.Text;

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

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (_currency == "btc")
            {
                Network network = Network.Main; // указываем использовать основную Bitcoin-сеть
                PubKey pubKey = new Key().PubKey; // генерируем публичный ключ
                string address = pubKey.GetAddress(ScriptPubKeyType.Legacy, network).ToString(); // создаем Bitcoin-адрес

                tbAddress.Text = address;
            }
            else if (_currency == "eth")
            {
                var ecKey = EthECKey.GenerateKey();
                var address = ecKey.GetPublicAddress();

                var privateKey = ecKey.GetPrivateKey();

                tbAddress.Text = address;
                tbPrivateKey.Text = privateKey;
            }
        }

        private void btnPrivateKeyShowToggle_Click(object sender, EventArgs e)
        {
            if (tbPrivateKey.PasswordChar == '•')
            {
                tbPrivateKey.PasswordChar = '\0'; // показываем пароль
                btnPrivateKeyShowToggle.BackgroundImage = Properties.Resources.hide; // изменяем изображение на "hide"
            }
            else
            {
                tbPrivateKey.PasswordChar = '•'; // скрываем пароль
                btnPrivateKeyShowToggle.BackgroundImage = Properties.Resources.show; // изменяем изображение на "show"
            }
        }
    }
}
