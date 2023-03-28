using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://root:buhwNMyMOqnGUIlE@dexcluster.mx0indr.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("DEXDB");

            var collection = database.GetCollection<BsonDocument>("Operations");
            var document = new BsonDocument
            {
                { "amount", 0.01295 },
                { "buyerUsername", "makkenzo" },
                { "sellerUsername", "alishka" },
                { "coinName", "Bitcoin" },
                { "coinAbbr", "BTC" },
                { "price", 27943 },
                { "date", DateTime.Now },
                { "status", "done" },
                { "totalPrice", 27943.0 * 0.01295 },
                { "commission", 5 }
            };


            collection.InsertOne(document);

            /*var document = collection.Find(new BsonDocument()).FirstOrDefault();

            var price = document["price"].AsInt32;

            label1.Text = Convert.ToString(price);*/
        }
    }
}
