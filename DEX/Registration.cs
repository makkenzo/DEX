using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Configuration;
using System.Runtime.InteropServices;
using System.IO;

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
            // this.Cursor = Cursors.WaitCursor;

            var settings = MongoClientSettings.FromConnectionString($"mongodb+srv://root:{ConfigurationManager.AppSettings.Get("MyPass")}@dexcluster.mx0indr.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("DEXDB");

            var collection = database.GetCollection<BsonDocument>("Users");

            string username = tbLogin.Text;
            string pass = tbPass.Text;

            var photoBytes = File.ReadAllBytes("profile.jpg");
            var filter = Builders<BsonDocument>.Filter.Eq("username", username);

            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                labelUsername.Visible = true;

                // this.Cursor = Cursors.Default;
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

                // this.Cursor = Cursors.Default;

                Authorization loginForm = new Authorization();
                loginForm.Show();
                this.Close();
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
