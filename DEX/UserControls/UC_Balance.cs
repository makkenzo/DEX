using DEX.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
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
        private string etcValue;

        public UC_Balance(UserCredentials userCredentials)
        {
            InitializeComponent();

            _userCredentials = userCredentials;
        }

        private async Task LoadUserDataAsync()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
            var collection = database.GetCollection<BsonDocument>("Users");

            var cursor = await collection.FindAsync(filter);
            var userDocument = await cursor.FirstOrDefaultAsync();

            if (userDocument.Contains("wallets"))
            {
                var walletsDocument = userDocument["wallets"].AsBsonDocument;
                if (walletsDocument.Contains("eth") && !string.IsNullOrEmpty(walletsDocument["eth"].AsString))
                {
                    etcValue = walletsDocument["eth"].AsString;
                    string etcValueShort = etcValue.Substring(0, 4) + "..." + etcValue.Substring(etcValue.Length - 6);

                    labelEtc.Text = etcValueShort;
                }
                else
                {
                    labelEtc.Text = "Кошелька еще нет";
                }
            }
            else
            {
                labelEtc.Text = "Кошелька еще нет";
            }

            this.Enabled = true;
        }


        private async void UC_Balance_Load(object sender, System.EventArgs e)
        {
            labelEtc.Parent = imgWallet;
            labelEtc.BackColor = Color.Transparent;

            imgEth.Parent = imgWallet;

            this.Enabled = false;

            await LoadUserDataAsync();
        }

        private void btnEthEdit_Click(object sender, System.EventArgs e)
        {
            EditWallet editWallet = new EditWallet(_userCredentials, etcValue);
            editWallet.ShowDialog();

            labelEtc.Text = editWallet.EtcValue.Substring(0, 4) + "..." + editWallet.EtcValue.Substring(etcValue.Length - 6);
        }
    }
}
