using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static DEX.Authorization;

namespace DEX.UserControls
{
    public partial class UC_Operations : UserControl
    {
        public UC_Operations(UserCredentials userCredentials)
        {
            InitializeComponent();

            _userCredentials = userCredentials;
        }

        private static readonly IMongoDatabase db = DBManager.GetDatabase();
        private readonly IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("Operations");
        private readonly UserCredentials _userCredentials;

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

        private async void UC_Operations_Load(object sender, System.EventArgs e)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("buyerUsername", _userCredentials.Username) | Builders<BsonDocument>.Filter.Eq("sellerUsername", _userCredentials.Username);
            var operations = await collection.Find(filter).ToListAsync();

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

            dgvOperations.DataSource = operationsList;

            GenerateOperationsFrequencyChart(operationsList);
            GenerateMostFrequentCryptocurrenciesChart(operationsList);
        }

        private void GenerateOperationsFrequencyChart(List<Operation> operationsList)
        {
            var operationFrequency = new Dictionary<string, int>();

            foreach (var operation in operationsList)
            {
                if (operationFrequency.ContainsKey(operation.Date.ToString("MMMM yyyy")))
                {
                    operationFrequency[operation.Date.ToString("MMMM yyyy")]++;
                }
                else
                {
                    operationFrequency.Add(operation.Date.ToString("MMMM yyyy"), 1);
                }
            }

            var series = new Series();
            series.ChartType = SeriesChartType.Column;

            foreach (var kvp in operationFrequency)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }

            chartOperationsFrequency.Series.Add(series);

            // Добавление заголовка
            var title = new Title();
            title.Text = "Частота операций";
            chartOperationsFrequency.Titles.Add(title);
        }

        private void GenerateMostFrequentCryptocurrenciesChart(List<Operation> operationsList)
        {
            var cryptocurrenciesFrequency = new Dictionary<string, int>();

            foreach (var operation in operationsList)
            {
                if (cryptocurrenciesFrequency.ContainsKey(operation.CoinAbbr))
                {
                    cryptocurrenciesFrequency[operation.CoinAbbr]++;
                }
                else
                {
                    cryptocurrenciesFrequency.Add(operation.CoinAbbr, 1);
                }
            }

            // Создание объекта диаграммы
            var chart = new Chart();
            chart.Size = new Size(500, 300);

            // Добавление области диаграммы
            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Добавление серии данных
            var series = new Series();
            series.ChartType = SeriesChartType.Pie;

            foreach (var kvp in cryptocurrenciesFrequency)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
                series.Points.Last().LegendText = $"{kvp.Key} ({kvp.Value})";
            }

            // Добавление процентов к каждому сектору диаграммы
            series.Label = "#PERCENT{P0}";

            chart.Series.Add(series);

            // Добавление легенды
            var legend = new Legend();
            chart.Legends.Add(legend);

            // Добавление заголовка
            var title = new Title();
            title.Text = "Самые частые криптовалюты";
            chart.Titles.Add(title);

            // Отображение диаграммы на форме или контроле
            chartMostFrequentCryptocurrencies.Controls.Add(chart);
        }
    }
}
