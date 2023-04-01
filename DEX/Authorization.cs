using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace DEX
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration regForm = new Registration();
            regForm.Show();
            this.Close();
        }

        public class UserCredentials
        {
            public string Username { get; set; }
            public string FName { get; set; }
            public string LName { get; set; }
            public string RegistrationDate { get; set; }
            public string BirthDate { get; set; }
            public string Email { get; set; }
            public BsonBinaryData Photo { get; set; }
            public string UserID { get; set; }
            public string Activity { get; set; }
            public string Phone { get; set; }
        }

        [Serializable]
        public class UserState
        {
            public string Username { get; set; }
            public string FName { get; set; }
            public string LName { get; set; }
            public byte[] Photo { get; set; }
            public string RegistrationDate { get; set; }
            public string BirthDate { get; set; }
            public string Email { get; set; }
            public string UserID { get; set; }
            public string Phone { get; set; }
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            labelErr.Visible = false;

            var database = DBManager.GetDatabase();
            var collection = database.GetCollection<BsonDocument>("Users");

            string user = tbLogin.Text;

            var filter = Builders<BsonDocument>.Filter.Eq("username", user);
            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                var pass = result.GetValue("password").AsString;
                var role = result.GetValue("role").AsString;

                if (pass == tbPass.Text)
                {
                    if (role == "admin")
                    {
                        MenuAdmin menu = new MenuAdmin();
                        menu.Show();
                        this.Close();
                    }
                    else if (role == "user")
                    {
                        UserCredentials credentials = new UserCredentials();
                        credentials.Username = user;
                        credentials.FName = result.GetValue("fName").AsString;
                        credentials.LName = result.GetValue("lName").AsString;
                        credentials.Photo = result.GetValue("photo").AsBsonBinaryData;
                        credentials.RegistrationDate = result.GetValue("registrationDate").AsString;
                        credentials.BirthDate = result.GetValue("birthDate").AsString;
                        credentials.Email = result.GetValue("email").AsString;
                        credentials.UserID = result.GetValue("userID").AsString;
                        credentials.Phone = result.GetValue("phone").AsString;

                        UserState state = new UserState();
                        state.Username = credentials.Username;
                        state.FName = credentials.FName;
                        state.LName = credentials.LName;
                        state.Photo = credentials.Photo.RawValue as byte[];
                        state.RegistrationDate = credentials.RegistrationDate;
                        state.BirthDate = credentials.BirthDate;
                        state.Email = credentials.Email;
                        state.UserID = credentials.UserID;
                        state.Phone = credentials.Phone;

                        using (FileStream file = new FileStream("userstate.dat", FileMode.Create))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(file, state);
                        }

                        MenuUser menu = new MenuUser(credentials);
                        menu.Show();
                        this.Close();
                    }
                }
                else
                {
                    labelErr.Visible = true;
                }
            }
            else
            {
                labelErr.Visible = true;
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbLogin.ForeColor = Color.White;
        }
        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            tbPass.ForeColor = Color.White;
            tbPass.PasswordChar = '•';
        }

        private void tbLogin_Click(object sender, EventArgs e)
        {
            tbLogin.SelectAll();
        }

        private void tbPass_Click(object sender, EventArgs e)
        {
            tbPass.SelectAll();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {

        }
    }
}
