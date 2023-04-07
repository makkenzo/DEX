using DEX.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX.UserControls
{
    public partial class UC_Lots : UserControl
    {

        private IMongoDatabase database = DBManager.GetDatabase();
        private UserCredentials _userCredentials;

        public UC_Lots(UserCredentials userCredentials)
        {
            InitializeComponent();
            _userCredentials = userCredentials;
        }

        public class Lot
        {
            public string Id { get; set; }
            public string Coin { get; set; }
            public double Price { get; set; }
            public double Amount { get; set; }
            public double Sum { get; set; }
            public string Type { get; set; }
            public string Seller { get; set; }
            public string LotDate { get; set; }
        }

        private void AddLabelsGroup(string id, string coin, double price, double amount, double sum, string type, string user, string lotDate)
        {
            // создаем новую группу лейблов и настраиваем ее контролы
            var newLabelsGroup = new GroupBox
            {
                Text = id,
                Font = new Font("Roboto", 12f, FontStyle.Regular),
                ForeColor = Color.White,
                Size = new Size(970, 62)
            };

            var labelCoin = new Label { Text = coin, Location = new Point(15, 27) };
            var labelPrice = new Label { Text = price.ToString(), Location = new Point(152, 27) };
            var labelAmount = new Label { Text = amount.ToString(), Location = new Point(289, 27) };
            var labelSum = new Label { Text = sum.ToString(), Location = new Point(426, 27) };
            var labelType = new Label { Text = type, Location = new Point(563, 27) };
            var labelUser = new Label { Text = user, Location = new Point(700, 27) };
            var labelDateTime = new Label { Text = lotDate, Location = new Point(837, 27) };

            var btnShow = new Button 
            { 
                Text = "+", 
                Location = new Point(940, 25), 
                Size = new Size(20, 20), 
                Padding = new Padding(0, 0, 0, 5), 
                FlatStyle = FlatStyle.Flat 
            };

            newLabelsGroup.Controls.Add(labelCoin);
            newLabelsGroup.Controls.Add(labelPrice);
            newLabelsGroup.Controls.Add(labelAmount);
            newLabelsGroup.Controls.Add(labelSum);
            newLabelsGroup.Controls.Add(labelType);
            newLabelsGroup.Controls.Add(labelUser);
            newLabelsGroup.Controls.Add(labelDateTime);
            newLabelsGroup.Controls.Add(btnShow);

            var previousGroup = Controls.OfType<GroupBox>().LastOrDefault();
            if (previousGroup != null)
            {
                var newY = previousGroup.Location.Y + previousGroup.Height + 10; // добавляем отступ 10 пикселей между группами лейблов
                newLabelsGroup.Location = new Point(24, newY);
            }
            else
            {
                // если на форме нет групп лейблов, то добавляем новую группу лейблов в начало формы
                newLabelsGroup.Location = new Point(24, 92);
            }

            btnShow.MouseEnter += (sender, e) =>
            {
                newLabelsGroup.Cursor = Cursors.Hand;
            };

            btnShow.MouseLeave += (sender, e) =>
            {
                newLabelsGroup.Cursor = Cursors.Default;
            };

            btnShow.Click += (sender, e) =>
            {
                Transaction transaction = new Transaction(id, coin, price, amount, sum, type, user, lotDate, _userCredentials);
                transaction.ShowDialog();
            };

            Controls.Add(newLabelsGroup); // добавляем новую группу лейблов на форму
        }

        private void UC_Lots_Load(object sender, EventArgs e)
        {
            var collection = database.GetCollection<BsonDocument>("Lots");

            var filter = Builders<BsonDocument>.Filter.Empty;
            var lots = collection.Find(filter).ToList();

            var lotsArr = new Lot[lots.Count];

            for (int i = 0; i < lots.Count; i++)
            {
                var id = lots[i].GetValue("_id").AsObjectId;
                var coin = lots[i].GetValue("coin").AsString;
                var price = lots[i].GetValue("price").AsDouble;
                var amount = lots[i].GetValue("amount").AsDouble;
                var sum = lots[i].GetValue("sum").AsDouble;
                var type = lots[i].GetValue("type").AsString;
                var seller = lots[i].GetValue("seller").AsString;
                var lotDate = lots[i].GetValue("date").ToUniversalTime();

                var lot = new Lot
                {
                    Id = id.ToString(),
                    Coin = coin,
                    Price = price,
                    Amount = amount,
                    Sum = sum,
                    Type = type,
                    Seller = seller,
                    LotDate = lotDate.ToString()
                };

                lotsArr[i] = lot;
            }

            for (int i = 0; i < lotsArr.Length; i++)
            {
                var lot = lotsArr[i];

                AddLabelsGroup(lot.Id, lot.Coin, lot.Price, lot.Amount, lot.Sum, lot.Type, lot.Seller, lot.LotDate);
            }
        }
    }
}
