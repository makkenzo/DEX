using CoinAPI.REST.V1;
using RestSharp;
using System.Windows.Forms;

namespace DEX.UserControls
{
    public partial class UC_Cryptocurrencies : UserControl
    {
        public UC_Cryptocurrencies()
        {
            InitializeComponent();
        }

        private void UC_Cryptocurrencies_Load(object sender, System.EventArgs e)
        {
            var client = new RestClient("https://rest.coinapi.io/v1/exchangerate/BTC/USD");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", "70FE834F-D8EE-4DE5-A2A6-C4D5D0C33E23");
            IRestResponse response = client.Execute(request);
        }
    }
}
