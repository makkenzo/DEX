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

namespace DEX
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration regForm = new Registration();
            regForm.Show();
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var settings = MongoClientSettings.FromConnectionString($"mongodb+srv://root:{ConfigurationManager.AppSettings.Get("MyPass")}@dexcluster.mx0indr.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("DEXDB");

            var collection = database.GetCollection<BsonDocument>("Users");

            string user = textBox1.Text;

            var filter = Builders<BsonDocument>.Filter.Eq("username", user);

            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                var pass = result.GetValue("password").AsString;

                if (pass == textBox2.Text)
                {
                    MainMenu menu = new MainMenu();
                    menu.Show();
                    this.Close();
                }
            }
        }
    }
}
