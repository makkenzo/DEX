using DEX.UserControls;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DEX
{
    public partial class MenuAdmin : Form
    {
        private static readonly IMongoDatabase db = DBManager.GetDatabase();
        private readonly IMongoCollection<BsonDocument> coins = db.GetCollection<BsonDocument>("Coins");
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            UpdateCoinData();

            buttonUsersLeft.Visible = true;
            btnVolumeLeft.Visible = false;

            UCA_Users users = new UCA_Users();
            addUserControl(users);
        }

        private void UpdateCoinData()
        {
            var symbols = new List<string> { "BTC", "ETH", "USDT", "USDC", "XRP", "LTC", "DAI", "SOL", "BUSD", "ADA" };
            foreach (var symbol in symbols)
            {
                var client = new RestClient($"https://rest.coinapi.io/v1/exchangerate/{symbol}/USD");
                var request = new RestRequest(Method.GET);
                request.AddHeader("X-CoinAPI-Key", ConfigurationManager.AppSettings.Get("CoinAPIToken"));
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = response.Content;
                    var coinData = ParseApiResponse(content);

                    // TODO: mongodb update
                    var filter = Builders<BsonDocument>.Filter.Eq("abbr", coinData.asset_id_base);
                    var update = Builders<BsonDocument>.Update.Set("price", Math.Round(coinData.rate, 4));
                    coins.UpdateOne(filter, update);
                }
            }
        }

        public class CoinData
        {
            public string asset_id_base { get; set; }
            public double rate { get; set; }
        }

        private CoinData ParseApiResponse(string content)
        {
            CoinData coinData = null;

            try
            {
                coinData = JsonConvert.DeserializeObject<CoinData>(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }

            return coinData;
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


        private void addUserControl(UserControl userControl)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControl);
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            buttonUsersLeft.Visible = true;
            btnVolumeLeft.Visible = false;

            UCA_Users users = new UCA_Users();
            addUserControl(users);
        }

        private void btnVolume_Click(object sender, EventArgs e)
        {
            buttonUsersLeft.Visible = false;
            btnVolumeLeft.Visible = true;

            UCA_Volume volume = new UCA_Volume();
            addUserControl(volume);
        }
    }
}
