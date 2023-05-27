using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEX.UserControls
{
    public partial class UCA_Volume : UserControl
    {
        public UCA_Volume()
        {
            InitializeComponent();
        }

        private static readonly IMongoDatabase db = DBManager.GetDatabase();
        private readonly IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("Operations");

        public class Operation
        {
            public ObjectId ID { get; set; }
            public double Amount { get; set; }
            public string Buyer { get; set; }
            public string Seller { get; set; }
            public string CoinAbbr { get; set; }
            public double Price { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
            public double TotalPrice { get; set; }
            public double Commission { get; set; }
        }

        private async void UCA_Volume_Load(object sender, EventArgs e)
        {
            var operations = await collection.Find(_ => true).ToListAsync();

            var operationsList = new List<Operation>();

            foreach (var operation in operations)
            {
                var userModel = new Operation
                {
                    ID = operation.GetValue("_id").AsObjectId,
                    Amount = operation.GetValue("amount").AsDouble,
                    Buyer = operation.GetValue("buyerUsername").AsString,
                    Seller = operation.GetValue("sellerUsername").AsString,
                    CoinAbbr = operation.GetValue("coinAbbr").AsString,
                    Price = operation.GetValue("price").AsDouble,
                    Date = operation.GetValue("date").ToUniversalTime(),
                    Status = operation.GetValue("status").AsString,
                    TotalPrice = operation.GetValue("totalPrice").AsDouble,
                    Commission = operation.GetValue("commision").AsDouble,
                };

                operationsList.Add(userModel);
            }

            dgvVolume.DataSource = operationsList;

            dgvVolume.Columns["ID"].Width = 200;
            dgvVolume.Columns["Date"].Width = 150;
            dgvVolume.Columns["Amount"].Width = 150;
        }
    }
}
