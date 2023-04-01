using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX
{
    public partial class MenuUser : Form
    {
        private IMongoDatabase _database;
        private UserCredentials _userCredentials;

        public MenuUser(UserCredentials userCredentials)
        {
            InitializeComponent();
            _database = DBManager.GetDatabase();
            _userCredentials = userCredentials;
        }

        private void MenuUser_Load(object sender, EventArgs e)
        {
            panelProfile.Visible = true;

            buttonProfileLeft.Visible           = true;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;

            labelUpdateSuccess.Visible = false;

            labelUsername.Text = _userCredentials.Username;

            tbFName.Text = _userCredentials.FName;
            tbLName.Text = _userCredentials.LName;

            var binaryData = _userCredentials.Photo.AsBsonBinaryData;
            var bytes = binaryData.AsByteArray;

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image image = Image.FromStream(ms);
                profileImg.Image = image;
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
            Application.Exit();
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            panelProfile.Visible = true;

            buttonProfileLeft.Visible           = true;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;

            doneIcon.Visible = false;
            errorIcon.Visible = false;
        }
        private void buttonBalance_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = true;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;
        }

        private void buttonRating_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = true;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;
        }

        private void buttonLots_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = true;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = true;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;
        }

        private void buttonCryptocurrencies_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = true;
            buttonSettingsLeft.Visible          = false;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = true;
        }

        private void tbFName_TextChanged(object sender, EventArgs e)
        {
            tbFName.ForeColor = Color.White;
        }

        private void tbLName_TextChanged(object sender, EventArgs e)
        {
            tbLName.ForeColor = Color.White;
        }

        private void tbFName_Click(object sender, EventArgs e)
        {
            tbFName.SelectAll();
        }

        private void tbLName_Click(object sender, EventArgs e)
        {
            tbLName.SelectAll();
        }

        private void buttonFNameEdit_Click(object sender, EventArgs e)
        {
            tbFName.Enabled = true;
        }

        private void buttonLNameEdit_Click(object sender, EventArgs e)
        {
            tbLName.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
            var update = Builders<BsonDocument>.Update
                .Set("fName", tbFName.Text)
                .Set("lName", tbLName.Text);
            var collection = _database.GetCollection<BsonDocument>("Users");
            var result = collection.UpdateOne(filter, update);

            if (result.ModifiedCount == 1)
            {
                doneIcon.Visible = true;
                errorIcon.Visible = false;

                labelUpdateSuccess.Visible = true;
            }
            else
            {
                doneIcon.Visible = false;
                errorIcon.Visible = true;
            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            string file = "userstate.dat";
            if (File.Exists(file))
            {
                File.Delete(file);
            }

            Authorization auth = new Authorization();
            auth.Show();
            this.Close();
        }
    }
}
