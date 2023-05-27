using DEX.UserControls;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DEX
{
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
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

        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            buttonUsersLeft.Visible = true;
            btnVolumeLeft.Visible = false;

            UCA_Users users = new UCA_Users();
            addUserControl(users);
        }

        private void addUserControl(UserControl userControl)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControl);
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            buttonUsersLeft.Visible = true;
            btnVolumeLeft.Visible = false;

            UCA_Users users = new UCA_Users();
            addUserControl(users);
        }

        private void btnVolume_Click(object sender, EventArgs e)
        {
            buttonUsersLeft.Visible = false;
            btnVolumeLeft.Visible = true;

            UCA_Volume volume = new UCA_Volume();
            addUserControl(volume);
        }
    }
}
