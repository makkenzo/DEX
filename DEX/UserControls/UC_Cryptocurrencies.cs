using MongoDB.Bson;
using MongoDB.Driver;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace DEX.UserControls
{
    public partial class UC_Cryptocurrencies : UserControl
    {
        public UC_Cryptocurrencies()
        {
            InitializeComponent();
        }

        private static readonly IMongoDatabase db = DBManager.GetDatabase();
        private readonly IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("Coins");

        public class Coin
        {
            public string CoinAbbr { get; set; }
            public double Price { get; set; }
        }

        private async void UC_Cryptocurrencies_Load(object sender, System.EventArgs e)
        {
            var coins = await collection.Find(_ => true).ToListAsync();

            var coinsList = new List<Coin>();

            foreach (var coin in coins)
            {
                var coinModel = new Coin
                {
                    CoinAbbr = coin.GetValue("abbr").AsString,
                    Price = coin.GetValue("price").AsDouble,
                };

                coinsList.Add(coinModel);
            }

            dgvCoins.DataSource = coinsList;

            dgvCoins.Columns["Price"].Width = 150;
        }
    }
}
