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
        private string etcAddress;
        private double etcBalance;

        public UC_Balance(UserCredentials userCredentials)
        {
            InitializeComponent();

            _userCredentials = userCredentials;
        }

        private async void UC_Balance_Load(object sender, EventArgs e)
        {
            labelEthAddress.Parent = imgEthWallet;
            labelEthAddress.BackColor = Color.Transparent;

            labelEthBalance.Parent = imgEthWallet;
            labelEthBalance.BackColor = Color.Transparent;

            imgEth.Parent = imgEthWallet;

            this.Enabled = false;

            await LoadUserDataAsync();
        }

        private async Task LoadUserDataAsync()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
            var collection = database.GetCollection<BsonDocument>("Users");

            var userDocument = await collection.Find(filter).FirstOrDefaultAsync();

            var walletsDocument = userDocument["wallets"].AsBsonDocument;
            var ethWalletDocument = walletsDocument["eth"].AsBsonDocument;

            if (ethWalletDocument.Contains("address") && !string.IsNullOrEmpty(ethWalletDocument["address"].AsString))
            {
                etcAddress = ethWalletDocument["address"].AsString;
                string etcValueShort = etcAddress.Substring(0, 4) + "..." + etcAddress.Substring(etcAddress.Length - 6);

                etcBalance = ethWalletDocument["balance"].AsDouble;

                labelEthBalance.Text = Convert.ToString(etcBalance);
                labelEthAddress.Text = etcValueShort;
            }
            else
            {
                labelEthAddress.Text = "Кошелька еще нет";
            }

            this.Enabled = true;
        }

        private void btnEthEdit_Click(object sender, EventArgs e)
        {
            EditWallet editWallet = new EditWallet(_userCredentials, etcAddress);
            editWallet.ShowDialog();

            labelEthAddress.Text = editWallet.EtcAddress.Substring(0, 4) + "..." + editWallet.EtcAddress.Substring(etcAddress.Length - 6);
        }
    }
}
