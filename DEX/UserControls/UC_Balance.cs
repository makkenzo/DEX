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

        private string etcAddress;
        private double etcBalance;

        private string btcAddress;
        private double btcBalance;

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

            panelEth.Enabled = false;
            panelBtc.Enabled = false;
            panelUsdt.Enabled = false;
            panelLtc.Enabled = false;
            panelXrp.Enabled = false;
            panelUsdc.Enabled = false;
            panelDai.Enabled = false;
            panelSol.Enabled = false;
            panelBusd.Enabled = false;
            panelAda.Enabled = false;

            await LoadUserDataAsync();
        }

        private void btnEthEdit_Click(object sender, EventArgs e)
        {
            EditWallet editWallet = new EditWallet(_userCredentials, etcAddress, "eth");
            editWallet.ShowDialog();

            if (editWallet.DialogResult == DialogResult.OK)
            {
                labelETHAddress.Text = editWallet.Address.Substring(0, 4) + "..." + editWallet.Address.Substring(etcAddress.Length - 6);
            }
        }

        private void btnBtcEdit_Click(object sender, EventArgs e)
        {
            EditWallet editWallet = new EditWallet(_userCredentials, btcAddress, "btc");
            editWallet.ShowDialog();

            if (editWallet.DialogResult == DialogResult.OK)
            {
                labelBTCAddress.Text = editWallet.Address.Substring(0, 4) + "..." + editWallet.Address.Substring(btcAddress.Length - 6);
            }
        }

        private void btnUSDTEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnXRPEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnLTCEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDAIEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnUSDCEdit_Click(object sender, EventArgs e)
        {

        }

        private async Task LoadUserDataAsync()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
            var collection = database.GetCollection<BsonDocument>("Users");

            var userDocument = await collection.Find(filter).FirstOrDefaultAsync();

            var walletsDocument = userDocument["wallets"].AsBsonDocument;

            var ethWalletDocument = walletsDocument["eth"].AsBsonDocument;
            var btcWalletDocument = walletsDocument["btc"].AsBsonDocument;

            if (ethWalletDocument.Contains("address") && !string.IsNullOrEmpty(ethWalletDocument["address"].AsString))
            {
                etcAddress = ethWalletDocument["address"].AsString;
                string etcValueShort = etcAddress.Substring(0, 4) + "..." + etcAddress.Substring(etcAddress.Length - 6);

                etcBalance = ethWalletDocument["balance"].AsDouble;

                labelETHBalance.Text = Convert.ToString(etcBalance);
                labelETHAddress.Text = etcValueShort;
            }
            else
            {
                labelETHAddress.Text = "Кошелек не найден";
            }

            if (btcWalletDocument.Contains("address") && !string.IsNullOrEmpty(btcWalletDocument["address"].AsString))
            {
                btcAddress = btcWalletDocument["address"].AsString;
                string btcValueShort = btcAddress.Substring(0, 4) + "..." + btcAddress.Substring(btcAddress.Length - 6);

                btcBalance = btcWalletDocument["balance"].AsDouble;

                labelBTCBalance.Text = Convert.ToString(btcBalance);
                labelBTCAddress.Text = btcValueShort;
            }
            else
            {
                labelBTCAddress.Text = "Кошелек не найден";
            }

            panelEth.Enabled = true;
            panelBtc.Enabled = true;
            panelUsdt.Enabled = true;
            panelLtc.Enabled = true;
            panelXrp.Enabled = true;
            panelUsdc.Enabled = true;
            panelDai.Enabled = true;
            panelSol.Enabled = true;
            panelBusd.Enabled = true;
            panelAda.Enabled = true;
        }
    }
}
