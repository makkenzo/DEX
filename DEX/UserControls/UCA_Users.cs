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
    public partial class UCA_Users : UserControl
    {
        public UCA_Users()
        {
            InitializeComponent();
        }

        private static readonly IMongoDatabase db = DBManager.GetDatabase();
        private readonly IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("Users");

        public class User
        {
            public ObjectId ID { get; set; }
            public string Username { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string RegistrationDate { get; set; }
            public string BirthDate { get; set; }
            public string Email { get; set; }
            public string UserID { get; set; }
            public int Activity { get; set; }
            public string Phone { get; set; }
            public string Password { get; set; }
            public double BalanceUSD { get; set; }
            public string Role { get; set; }
        }

        private async void LoadUsers()
        {
            var users = await collection.Find(_ => true).Skip(1).ToListAsync();

            var userList = new List<User>();

            foreach (var user in users)
            {
                var userModel = new User
                {
                    ID = user.GetValue("_id").AsObjectId,
                    Username = user.GetValue("username").AsString,
                    FirstName = user.GetValue("fName").AsString,
                    LastName = user.GetValue("lName").AsString,
                    RegistrationDate = user.GetValue("registrationDate").AsString,
                    BirthDate = user.GetValue("birthDate").AsString,
                    Email = user.GetValue("email").AsString,
                    UserID = user.GetValue("userID").AsString,
                    Activity = user.GetValue("activity").AsInt32,
                    Phone = user.GetValue("phone").AsString,
                    Password = user.GetValue("password").AsString,
                    BalanceUSD = user.GetValue("balanceUSD").AsDouble,
                    Role = user.GetValue("role").AsString,
                };

                userList.Add(userModel);
            }

            dgvUsers.DataSource = userList;

            dgvUsers.Columns["ID"].Width = 200;
            dgvUsers.Columns["RegistrationDate"].Width = 150;
            dgvUsers.Columns["Email"].Width = 150;
        }


        private async void UCA_Users_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvUsers.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvUsers.Rows[selectedRowIndex];

                if (selectedRow.Cells["ID"].Value != null)
                {
                    string idString = selectedRow.Cells["ID"].Value.ToString();
                    ObjectId id = ObjectId.Parse(idString);

                    var filter = Builders<BsonDocument>.Filter.Eq("_id", id);

                    var result = await collection.DeleteOneAsync(filter);

                    if (result.DeletedCount == 1)
                    {
                        doneIcon.Visible = true;
                        errorIcon.Visible = false;
                    }
                    else
                    {
                        doneIcon.Visible = false;
                        errorIcon.Visible = true;
                    }
                }

                LoadUsers();
            }
        }
    }
}
