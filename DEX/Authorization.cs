using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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

            var settings = MongoClientSettings.FromConnectionString($"mongodb+srv://root:{ConfigurationManager.AppSettings.Get("MyPass")}@dexcluster.mx0indr.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("DEXDB");

            var collection = database.GetCollection<BsonDocument>("Users");

            string user = tbLogin.Text;

            var filter = Builders<BsonDocument>.Filter.Eq("username", user);

            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                var pass = result.GetValue("password").AsString;

                if (pass == tbPass.Text)
                {
                    MainMenu menu = new MainMenu();
                    menu.Show();
                    this.Close();
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
            try
            {
                tbLogin.ForeColor = Color.White;
            }
            catch (Exception ex)
            {

            }
        }
        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbPass.ForeColor = Color.White;
                tbPass.PasswordChar = '•';
            }
            catch (Exception ex)
            {

            }
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
