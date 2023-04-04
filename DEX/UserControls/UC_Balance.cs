using DEX.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX.UserControls
{
    public partial class UC_Balance : UserControl
    {
        private UserCredentials _userCredentials;
        private IMongoDatabase database = DBManager.GetDatabase();

        private string ethAddress, btcAddress, usdtAddress, usdcAddress, xrpAddress, ltcAddress, daiAddress, solAddress, busdAddress, adaAddress;
        private string ethPrivateKey;
        private double ethBalance, btcBalance, usdtBalance, usdcBalance, xrpBalance, ltcBalance, daiBalance, solBalance, busdBalance, adaBalance;

        public UC_Balance(UserCredentials userCredentials)
        {
            InitializeComponent();

            _userCredentials = userCredentials;
        }

        private async void UC_Balance_Load(object sender, EventArgs e)
        {
            imgETH.Parent = imgETHWallet;
            imgBTC.Parent = imgBTCWallet;
            imgUSDT.Parent = imgUSDTWallet;
            imgLTC.Parent = imgLTCWallet;
            imgXRP.Parent = imgXRPWallet;
            imgDAI.Parent = imgDAIWallet;
            imgUSDC.Parent = imgUSDCWallet;
            imgSOL.Parent = imgSOLWallet;
            imgBUSD.Parent = imgBUSDWallet;
            imgADA.Parent = imgADAWallet;

            TogglePanels(false);

            await LoadUserDataAsync();
        }

        private async Task LoadUserDataAsync()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
            var collection = database.GetCollection<BsonDocument>("Users");

            var userDocument = await collection.Find(filter).FirstOrDefaultAsync();
            var walletsDocument = userDocument["wallets"].AsBsonDocument;

            LoadWalletData("eth", walletsDocument, labelETHBalance, labelETHAddress, ref ethAddress, ref ethBalance);
            LoadWalletData("btc", walletsDocument, labelBTCBalance, labelBTCAddress, ref btcAddress, ref btcBalance);
            LoadWalletData("usdt", walletsDocument, labelUSDTBalance, labelUSDTAddress, ref usdtAddress, ref usdtBalance);
            LoadWalletData("usdc", walletsDocument, labelUSDCBalance, labelUSDCAddress, ref usdcAddress, ref usdcBalance);
            LoadWalletData("xrp", walletsDocument, labelXRPBalance, labelXRPAddress, ref xrpAddress, ref xrpBalance);
            LoadWalletData("ltc", walletsDocument, labelLTCBalance, labelLTCAddress, ref ltcAddress, ref ltcBalance);
            LoadWalletData("dai", walletsDocument, labelDAIBalance, labelDAIAddress, ref daiAddress, ref daiBalance);
            LoadWalletData("sol", walletsDocument, labelSOLBalance, labelSOLAddress, ref solAddress, ref solBalance);
            LoadWalletData("busd", walletsDocument, labelBUSDBalance, labelBUSDAddress, ref busdAddress, ref busdBalance);
            LoadWalletData("ada", walletsDocument, labelADABalance, labelADAAddress, ref adaAddress, ref adaBalance);

            TogglePanels(true);
        }

        private void LoadWalletData(string walletName, BsonDocument walletsDocument, Label balanceLabel, Label addressLabel, ref string address, ref double balance)
        {
            var walletDocument = walletsDocument[walletName].AsBsonDocument;

            if (walletDocument.Contains("address") && !string.IsNullOrEmpty(walletDocument["address"].AsString))
            {
                address = walletDocument["address"].AsString;
                var valueShort = address.Substring(0, 4) + "..." + address.Substring(address.Length - 6);

                balance = walletDocument["balance"].AsDouble;

                balanceLabel.Text = balance.ToString() + " " + walletName.ToUpper();
                addressLabel.Text = valueShort;
            }
            else
            {
                balanceLabel.Visible = false;
                addressLabel.Text = "Кошелек не найден";
                addressLabel.Enabled = false;
            }

            if (walletName == "eth")
            {
                var privateKeyDoc = walletDocument["privateKey"];
                if (privateKeyDoc != null)
                {
                    ethPrivateKey = privateKeyDoc.AsString;
                }
            }

        }

        private void TogglePanels(bool state)
        {
            panelEth.Enabled = state;
            panelBtc.Enabled = state;
            panelUsdt.Enabled = state;
            panelLtc.Enabled = state;
            panelXrp.Enabled = state;
            panelUsdc.Enabled = state;
            panelDai.Enabled = state;
            panelSol.Enabled = state;
            panelBusd.Enabled = state;
            panelAda.Enabled = state;
        }

        private void EditAddress(string address, Label addressLabel, string currency, string privateKey)
        {
            EditWallet editWallet = new EditWallet(_userCredentials, address, currency, privateKey);
            editWallet.ShowDialog();

            if (editWallet.DialogResult == DialogResult.OK)
            {
                address = editWallet.Address;
                addressLabel.Text = editWallet.Address.Substring(0, 4) + "..." + editWallet.Address.Substring(address.Length - 6);
                addressLabel.Enabled = true;
            }
        }


        private void btnEthEdit_Click(object sender, EventArgs e)
        {
            EditAddress(ethAddress, labelETHAddress, "eth", ethPrivateKey);
        }

        private void btnBtcEdit_Click(object sender, EventArgs e)
        {
            EditAddress(btcAddress, labelBTCAddress, "btc", "");
        }

        private void btnUSDTEdit_Click(object sender, EventArgs e)
        {
            EditAddress(usdtAddress, labelUSDTAddress, "usdt", "");
        }

        private void btnXRPEdit_Click(object sender, EventArgs e)
        {
            EditAddress(xrpAddress, labelXRPAddress, "xrp", "");
        }

        private void btnLTCEdit_Click(object sender, EventArgs e)
        {
            EditAddress(ltcAddress, labelLTCAddress, "ltc", "");
        }

        private void btnDAIEdit_Click(object sender, EventArgs e)
        {
            EditAddress(daiAddress, labelDAIAddress, "dai", "");
        }

        private void btnUSDCEdit_Click(object sender, EventArgs e)
        {
            EditAddress(usdcAddress, labelUSDCAddress, "usdc", "");
        }

        private void btnADAEdit_Click(object sender, EventArgs e)
        {
            EditAddress(adaAddress, labelADAAddress, "ada", "");
        }

        private void btnBUSDEdit_Click(object sender, EventArgs e)
        {
            EditAddress(busdAddress, labelBUSDAddress, "busd", "");
        }

        private void btnSOLEdit_Click(object sender, EventArgs e)
        {
            EditAddress(solAddress, labelSOLAddress, "sol", "");
        }
    }
}
