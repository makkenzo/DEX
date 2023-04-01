using MongoDB.Bson;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX
{
    public partial class Begin : Form
    {
        public Begin()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = "userstate.dat";
            if (File.Exists(file))
            {
                using (FileStream stream = new FileStream(file, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    UserState state = formatter.Deserialize(stream) as UserState;

                    // Создание объекта UserCredentials из состояния авторизации пользователя
                    UserCredentials credentials = new UserCredentials();
                    credentials.Username = state.Username;
                    credentials.FName = state.FName;
                    credentials.LName = state.LName;
                    credentials.Photo = new BsonBinaryData(state.Photo);
                    credentials.RegistrationDate = state.RegistrationDate;
                    credentials.BirthDate = state.BirthDate;
                    credentials.Email = state.Email;
                    credentials.UserID = state.UserID;
                    credentials.Phone = state.Phone;

                    MenuUser menu = new MenuUser(credentials);
                    menu.Show();
                    this.Close();
                }
            }
            else
            {
                Authorization authForm = new Authorization();
                authForm.Show();
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
