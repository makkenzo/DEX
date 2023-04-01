using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DEX
{
    public partial class Authorization : Form
    {
        int pw;
        public Authorization()
        {
            InitializeComponent();
            pw = panel1.Width;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration regForm = new Registration();
            regForm.Show();
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            labelErr.Visible = false;

            var database = DBManager.GetDatabase();

            var collection = database.GetCollection<BsonDocument>("Users");

            string user = tbLogin.Text;

            var filter = Builders<BsonDocument>.Filter.Eq("username", user);

            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                var pass = result.GetValue("password").AsString;
                var role = result.GetValue("role").AsString;

                if (pass == tbPass.Text)
                {
                    if (role == "admin")
                    {
                        MenuAdmin menu = new MenuAdmin();
                        menu.Show();
                        this.Close();
                    }
                    else if (role == "user")
                    {
                        MenuUser menu = new MenuUser();
                        menu.Show();
                        this.Close();
                    }
                }
                else
                {
                    labelErr.Visible = true;
                }
            }
            else
            {
                labelErr.Visible = true;
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

    }
}
