using MongoDB.Bson;
using MongoDB.Driver;
using NBitcoin;
using NBitcoin.Altcoins;
using Nethereum.Hex.HexTypes;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
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

            toolTip1.SetToolTip(tbPrivateKey, "Приватный ключ (privateKey) - это секретная информация, которая используется для подписи транзакций и доступа к вашему кошельку.\n" +
                                              "Никогда не делитесь своим приватным ключом с кем-либо и не храните его в открытом виде на своем компьютере.\n" +
                                              "Если злоумышленник получит ваш приватный ключ, он сможет управлять вашими средствами.\n" +
                                              "Обязательно сохраните свой приватный ключ в безопасном месте и не забудьте его.");
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
                    MessageBox.Show("Неправильный формат ETH-счета", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (_currency == "btc")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^([13][a-km-zA-HJ-NP-Z1-9]{25,34}|bc1[ac-hj-np-z0-9]{11,71})$"))
                {
                    MessageBox.Show("Неправильный формат BTC-счета", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (_currency == "usdt" || _currency == "usdc")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^0x[0-9a-fA-F]{40}$"))
                {
                    MessageBox.Show("Неправильный формат USDT/USDC-счета (на блокчейне Ethereum).", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (_currency == "xrp")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), @"^r[0-9a-zA-Z]{33}$"))
                {
                    MessageBox.Show("Неправильный формат XRP-счета", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (_currency == "ltc")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^[LM3][a-km-zA-HJ-NP-Z1-9]{26,33}$"))
                {
                    MessageBox.Show("Неправильный формат LTC-счета", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (_currency == "dai")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^0x[0-9a-fA-F]{40}$"))
                {
                    MessageBox.Show("Неправильный формат DAI-счета", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (_currency == "sol")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^[1-9a-zA-Z]{32,44}$"))
                {
                    MessageBox.Show("Неправильный формат SOL-счета", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (_currency == "busd")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text.Trim(), "^0x[0-9a-fA-F]{40}$"))
                {
                    MessageBox.Show("Неправильный формат BUSD-счета", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (_currency == "ada")
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                    return;
                if (!Regex.IsMatch(tbAddress.Text, "^addr1[0-9a-zA-Z]{57}$"))
                {
                    MessageBox.Show("Неправильный формат ADA-счета", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var result = MessageBox.Show($"Вы точно хотите обновить реквизиты {_currency.ToUpper()}-кошелька?", "Подтверждение обновления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var database = DBManager.GetDatabase();
                var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
                var update = Builders<BsonDocument>.Update.Set($"wallets.{_currency}.address", tbAddress.Text)
                    .Set($"wallets.{_currency}.privateKey", tbPrivateKey.Text);

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
                Network network = Network.Main;

                Key privateKey = new Key();

                PubKey pubKey = new Key().PubKey;

                string privateKeyHex = privateKey.GetBitcoinSecret(network).ToString();
                string address = pubKey.GetAddress(ScriptPubKeyType.Legacy, network).ToString();

                tbAddress.Text = address;
                tbPrivateKey.Text = privateKeyHex;
            }
            else if (_currency == "eth" || _currency == "usdt" || _currency == "usdc")
            {
                EthECKey ecKey = EthECKey.GenerateKey();
                string address = ecKey.GetPublicAddress();

                string privateKey = ecKey.GetPrivateKey();

                tbAddress.Text = address;
                tbPrivateKey.Text = privateKey;
            }
            else if (_currency == "ltc")
            {
                Network network = Litecoin.Instance.Mainnet;

                Key privateKey = new Key();

                BitcoinAddress address = privateKey.PubKey.GetAddress(ScriptPubKeyType.Legacy, network);
                BitcoinSecret privateKeyHex = privateKey.GetBitcoinSecret(network);

                tbAddress.Text = address.ToString();
                tbPrivateKey.Text = privateKeyHex.ToString();
            }
            else if (_currency == "dai")
            {
                var ecKey = EthECKey.GenerateKey();
                var privateKey = ecKey.GetPrivateKey();
                var account = new Account(privateKey);

                // Получение адреса кошелька DAI
                var address = account.Address;
                var hexAddress = new HexBigInteger(address);
                var daiAddress = new AddressUtil().ConvertToChecksumAddress(hexAddress);

                tbAddress.Text = daiAddress;
                tbPrivateKey.Text = privateKey;
            }
            else if (_currency == "sol")
            {
                // TODO: SOL generator
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
