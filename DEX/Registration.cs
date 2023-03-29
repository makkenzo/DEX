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
            var settings = MongoClientSettings.FromConnectionString($"mongodb+srv://root:{ConfigurationManager.AppSettings.Get("MyPass")}@dexcluster.mx0indr.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("DEXDB");

            var collection = database.GetCollection<BsonDocument>("Users");

            string username = textBox1.Text;
            string pass = textBox2.Text;

            var document = new BsonDocument
            {
                { "username", username },
                { "password", pass }
            };

            collection.InsertOne(document);

            Authorization loginForm = new Authorization();
            loginForm.Show();
            this.Close();
        }
    }
}
