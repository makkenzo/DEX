using DEX.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
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
        private double ethBalance, btcBalance, usdtBalance, usdcBalance, xrpBalance, ltcBalance, daiBalance, solBalance, busdBalance, adaBalance;

        private void btnTopUpBalance_Click(object sender, EventArgs e)
        {
            TopUpBalance topUpBalance = new TopUpBalance(_userCredentials);
            topUpBalance.ShowDialog();
        }

        private string ethPrivateKey, btcPrivateKey, usdtPrivateKey, usdcPrivateKey, xrpPrivateKey, ltcPrivateKey, daiPrivateKey, solPrivateKey, busdPrivateKey, adaPrivateKey;

        public UC_Balance(UserCredentials userCredentials)
        {
            InitializeComponent();

            _userCredentials = userCredentials;
        }

        private async void UC_Balance_Load(object sender, EventArgs e)
        {
            imgETH.Parent = imgETHWallet;
            imgETH.BackColor = Color.Transparent;
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

            var balanceUSD = userDocument.GetValue("balanceUSD").AsDouble;

            labelBalanceUSD.Text = $"Баланс: {Math.Round(balanceUSD, 2)}$";

            LoadWalletData("eth", walletsDocument, labelETHBalance, labelETHAddress, ref ethAddress, ref ethBalance, ref ethPrivateKey);
            LoadWalletData("btc", walletsDocument, labelBTCBalance, labelBTCAddress, ref btcAddress, ref btcBalance, ref btcPrivateKey);
            LoadWalletData("usdt", walletsDocument, labelUSDTBalance, labelUSDTAddress, ref usdtAddress, ref usdtBalance, ref usdtPrivateKey);
            LoadWalletData("usdc", walletsDocument, labelUSDCBalance, labelUSDCAddress, ref usdcAddress, ref usdcBalance, ref usdcPrivateKey);
            LoadWalletData("xrp", walletsDocument, labelXRPBalance, labelXRPAddress, ref xrpAddress, ref xrpBalance, ref xrpPrivateKey);
            LoadWalletData("ltc", walletsDocument, labelLTCBalance, labelLTCAddress, ref ltcAddress, ref ltcBalance, ref ltcPrivateKey);
            LoadWalletData("dai", walletsDocument, labelDAIBalance, labelDAIAddress, ref daiAddress, ref daiBalance, ref daiPrivateKey);
            LoadWalletData("sol", walletsDocument, labelSOLBalance, labelSOLAddress, ref solAddress, ref solBalance, ref solPrivateKey);
            LoadWalletData("busd", walletsDocument, labelBUSDBalance, labelBUSDAddress, ref busdAddress, ref busdBalance, ref busdPrivateKey);
            LoadWalletData("ada", walletsDocument, labelADABalance, labelADAAddress, ref adaAddress, ref adaBalance, ref adaPrivateKey);

            TogglePanels(true);
        }

        private void LoadWalletData(string walletName, BsonDocument walletsDocument, Label balanceLabel, Label addressLabel, ref string address, ref double balance, ref string privateKey)
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

            var privateKeyDoc = walletDocument["privateKey"];
            if (privateKeyDoc != null && !privateKeyDoc.IsBsonNull)
            {
                privateKey = privateKeyDoc.AsString;
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

            btnTopUpBalance.Enabled = state;
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
            EditAddress(btcAddress, labelBTCAddress, "btc", btcPrivateKey);
        }

        private void btnUSDTEdit_Click(object sender, EventArgs e)
        {
            EditAddress(usdtAddress, labelUSDTAddress, "usdt", usdtPrivateKey);
        }

        private void btnXRPEdit_Click(object sender, EventArgs e)
        {
            EditAddress(xrpAddress, labelXRPAddress, "xrp", xrpPrivateKey);
        }

        private void btnLTCEdit_Click(object sender, EventArgs e)
        {
            EditAddress(ltcAddress, labelLTCAddress, "ltc", ltcPrivateKey);
        }

        private void btnDAIEdit_Click(object sender, EventArgs e)
        {
            EditAddress(daiAddress, labelDAIAddress, "dai", daiPrivateKey);
        }

        private void btnUSDCEdit_Click(object sender, EventArgs e)
        {
            EditAddress(usdcAddress, labelUSDCAddress, "usdc", usdcPrivateKey);
        }

        private void btnADAEdit_Click(object sender, EventArgs e)
        {
            EditAddress(adaAddress, labelADAAddress, "ada", adaPrivateKey);
        }

        private void btnBUSDEdit_Click(object sender, EventArgs e)
        {
            EditAddress(busdAddress, labelBUSDAddress, "busd", busdPrivateKey);
        }

        private void btnSOLEdit_Click(object sender, EventArgs e)
        {
            EditAddress(solAddress, labelSOLAddress, "sol", solPrivateKey);
        }
    }
}
