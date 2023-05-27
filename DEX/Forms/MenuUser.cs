using DEX.UserControls;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX
{
    public partial class MenuUser : Form
    {
        public UserCredentials _userCredentials;

        public MenuUser(UserCredentials userCredentials)
        {
            InitializeComponent();

            _userCredentials = userCredentials;

            UC_Profile uc = new UC_Profile(userCredentials);
            addUserControl(uc);
        }

        private void MenuUser_Load(object sender, EventArgs e)
        {
            panelProfile.Visible = true;

            buttonProfileLeft.Visible = true;
            buttonBalanceLeft.Visible = false;
            buttonRatingLeft.Visible = false;
            buttonLotsLeft.Visible = false;
            buttonHistoryLeft.Visible = false;
            buttonCryptocurrenciesLeft.Visible = false;
            buttonSettingsLeft.Visible = false;
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

        private void addUserControl(UserControl userControl)
        {
            panelProfile.Controls.Clear();
            panelProfile.Controls.Add(userControl);
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            panelProfile.Visible = true;

            buttonProfileLeft.Visible = true;
            buttonBalanceLeft.Visible = false;
            buttonRatingLeft.Visible = false;
            buttonLotsLeft.Visible = false;
            buttonHistoryLeft.Visible = false;
            buttonCryptocurrenciesLeft.Visible = false;
            buttonSettingsLeft.Visible = false;

            UC_Profile uc = new UC_Profile(_userCredentials);
            addUserControl(uc);
        }
        private void buttonBalance_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible = false;
            buttonBalanceLeft.Visible = true;
            buttonRatingLeft.Visible = false;
            buttonLotsLeft.Visible = false;
            buttonHistoryLeft.Visible = false;
            buttonCryptocurrenciesLeft.Visible = false;
            buttonSettingsLeft.Visible = false;

            UC_Balance uc = new UC_Balance(_userCredentials);
            addUserControl(uc);
        }

        private void buttonRating_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible = false;
            buttonBalanceLeft.Visible = false;
            buttonRatingLeft.Visible = true;
            buttonLotsLeft.Visible = false;
            buttonHistoryLeft.Visible = false;
            buttonCryptocurrenciesLeft.Visible = false;
            buttonSettingsLeft.Visible = false;

            UC_Rating uc = new UC_Rating();
            addUserControl(uc);
        }

        private void buttonLots_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible = false;
            buttonBalanceLeft.Visible = false;
            buttonRatingLeft.Visible = false;
            buttonLotsLeft.Visible = true;
            buttonHistoryLeft.Visible = false;
            buttonCryptocurrenciesLeft.Visible = false;
            buttonSettingsLeft.Visible = false;

            UC_Lots uc = new UC_Lots(_userCredentials);
            addUserControl(uc);
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible = false;
            buttonBalanceLeft.Visible = false;
            buttonRatingLeft.Visible = false;
            buttonLotsLeft.Visible = false;
            buttonHistoryLeft.Visible = true;
            buttonCryptocurrenciesLeft.Visible = false;
            buttonSettingsLeft.Visible = false;

            UC_Operations uc = new UC_Operations();
            addUserControl(uc);
        }

        private void buttonCryptocurrencies_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible = false;
            buttonBalanceLeft.Visible = false;
            buttonRatingLeft.Visible = false;
            buttonLotsLeft.Visible = false;
            buttonHistoryLeft.Visible = false;
            buttonCryptocurrenciesLeft.Visible = true;
            buttonSettingsLeft.Visible = false;

            UC_Cryptocurrencies uc = new UC_Cryptocurrencies();
            addUserControl(uc);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible = false;
            buttonBalanceLeft.Visible = false;
            buttonRatingLeft.Visible = false;
            buttonLotsLeft.Visible = false;
            buttonHistoryLeft.Visible = false;
            buttonCryptocurrenciesLeft.Visible = false;
            buttonSettingsLeft.Visible = true;

            UC_Settings uc = new UC_Settings();
            addUserControl(uc);
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
