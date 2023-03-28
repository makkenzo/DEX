using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DEX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var settings = MongoClientSettings.FromConnectionString($"mongodb+srv://root:{ConfigurationManager.AppSettings.Get("MyPass")}@dexcluster.mx0indr.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("DEXDB");

            var collection = database.GetCollection<BsonDocument>("test1");
            var document = new BsonDocument
            {
                { "amount", 0 },
            };


            collection.InsertOne(document);
        }
    }
}
