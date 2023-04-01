using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DEX
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            labelPassErr.Visible = false;
            labelUsernameErr.Visible = false;

            var database = DBManager.GetDatabase();

            var collection = database.GetCollection<BsonDocument>("Users");

            string username = tbLogin.Text;
            string pass = tbPass.Text;

            if (username == "Введите логин" || pass == "Введите пароль")
            {
                MessageBox.Show("Вы оставили пустым одно или несколько полей");
            }
            else
            {
                if (pass.Length < 8)
                {
                    labelPassErr.Visible = true;
                }
                else
                {
                    var photoBytes = File.ReadAllBytes("profile.jpg");
                    var filter = Builders<BsonDocument>.Filter.Eq("username", username);

                    var result = collection.Find(filter).FirstOrDefault();

                    if (result != null)
                    {
                        labelUsernameErr.Visible = true;
                    }
                    else
                    {
                        var document = new BsonDocument
                        {
                            { "username", username },
                            { "fName", "" },
                            { "lName", "" },
                            { "registrationDate", DateTime.Now.ToString() },
                            { "birthDate", "" },
                            { "email", "" },
                            { "photo", new BsonBinaryData(photoBytes) },
                            { "userID", "" },
                            { "activity", 0 },
                            { "phone", "" },
                            { "password", pass },
                            { "role", "user" }
                        };

                        collection.InsertOne(document);

                        Authorization loginForm = new Authorization();
                        loginForm.Show();
                        this.Close();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbLogin.ForeColor = Color.White;
        }
        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            tbPass.ForeColor = Color.White;
            tbPass.PasswordChar = '•';
        }

        private void tbLogin_Click(object sender, EventArgs e)
        {
            tbLogin.SelectAll();
        }

        private void tbPass_Click(object sender, EventArgs e)
        {
            tbPass.SelectAll();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Authorization authForm = new Authorization();
            authForm.Show();
            this.Close();
        }
    }
}
