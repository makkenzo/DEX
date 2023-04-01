using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX
{
    public partial class MenuUser : Form
    {
        private IMongoDatabase _database;
        private UserCredentials _userCredentials;

        private byte[] imageBinaryData;

        public MenuUser(UserCredentials userCredentials)
        {
            InitializeComponent();
            _database = DBManager.GetDatabase();
            _userCredentials = userCredentials;
        }

        private void MenuUser_Load(object sender, EventArgs e)
        {
            buttonImageEdit.BackColor = Color.FromArgb(128, Color.Black);

            panelProfile.Visible = true;

            buttonProfileLeft.Visible           = true;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;

            labelUpdateSuccess.Visible = false;

            labelUsername.Text = _userCredentials.Username;

            tbFName.Text = _userCredentials.FName;
            tbLName.Text = _userCredentials.LName;

            tbRegistrationDate.Text = _userCredentials.RegistrationDate;
            tbBirthDate.Text = _userCredentials.BirthDate;

            tbEmail.Text = _userCredentials.Email;
            tbUserID.Text = _userCredentials.UserID;
            tbPhone.Text = _userCredentials.Phone;

            var binaryData = _userCredentials.Photo.AsBsonBinaryData;
            var bytes = binaryData.AsByteArray;

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image image = Image.FromStream(ms);
                profileImg.Image = image;
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

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            panelProfile.Visible = true;

            buttonProfileLeft.Visible           = true;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;

            doneIcon.Visible = false;
            errorIcon.Visible = false;
        }
        private void buttonBalance_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = true;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;
        }

        private void buttonRating_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = true;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;
        }

        private void buttonLots_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = true;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = true;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = false;
        }

        private void buttonCryptocurrencies_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = true;
            buttonSettingsLeft.Visible          = false;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            buttonProfileLeft.Visible           = false;
            buttonBalanceLeft.Visible           = false;
            buttonRatingLeft.Visible            = false;
            buttonLotsLeft.Visible              = false;
            buttonHistoryLeft.Visible           = false;
            buttonCryptocurrenciesLeft.Visible  = false;
            buttonSettingsLeft.Visible          = true;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.ForeColor = Color.White;
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.SelectAll();
        }

        private void buttonFNameEdit_Click(object sender, EventArgs e)
        {
            tbFName.Enabled = true;
        }

        private void buttonLNameEdit_Click(object sender, EventArgs e)
        {
            tbLName.Enabled = true;
        }
        private void buttonBirthDateEdit_Click(object sender, EventArgs e)
        {
            tbBirthDate.Enabled = true;
        }

        private void buttonEmailEdit_Click(object sender, EventArgs e)
        {
            tbEmail.Enabled = true;
        }

        private void buttonUserIDEdit_Click(object sender, EventArgs e)
        {
            tbUserID.Enabled = true;
        }

        private void buttonPhoneEdit_Click(object sender, EventArgs e)
        {
            tbPhone.Enabled = true;
        }

        private void buttonImageEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageBinaryData = File.ReadAllBytes(openFileDialog.FileName);
                profileImg.Image = byteArrayToImage(imageBinaryData);
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(@"^\+\d{11}$");
            return regex.IsMatch(phoneNumber);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string inputDate = tbBirthDate.Text;
            string format = "dd.MM.yyyy";
            DateTime dateValue;

            if (DateTime.TryParseExact(inputDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                if (dateValue.Year >= 1900 && dateValue.Year <= 9999
                    && dateValue.Month >= 1 && dateValue.Month <= 12
                    && dateValue.Day >= 1 && dateValue.Day <= DateTime.DaysInMonth(dateValue.Year, dateValue.Month))
                {
                    if (!IsValidEmail(tbEmail.Text))
                    {
                        MessageBox.Show("Введите корректный адрес почты.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (tbUserID.Text.Length != 12)
                    {
                        MessageBox.Show("Неверный формат ИНН. Введите 12 символов.");
                        return;
                    }
                    if (!IsValidPhoneNumber(tbPhone.Text))
                    {
                        MessageBox.Show("Номер телефона введен некорректно. Пожалуйста, введите номер в формате +xxxxxxxxxxx.");
                        return;
                    }
                    var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
                    var update = Builders<BsonDocument>.Update
                        .Set("fName", tbFName.Text)
                        .Set("lName", tbLName.Text)
                        .Set("birthDate", tbBirthDate.Text)
                        .Set("email", tbEmail.Text)
                        .Set("userID", tbUserID.Text)
                        .Set("phone", tbPhone.Text)
                        .Set("photo", new BsonBinaryData(imageBinaryData));
                    var collection = _database.GetCollection<BsonDocument>("Users");
                    var result = collection.UpdateOne(filter, update);

                    UserState state;
                    using (FileStream file = new FileStream("userstate.dat", FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        state = (UserState)formatter.Deserialize(file);
                    }

                    state.FName = tbFName.Text;
                    state.LName = tbLName.Text;
                    state.BirthDate = tbBirthDate.Text;
                    state.Email = tbEmail.Text;
                    state.UserID = tbUserID.Text;
                    state.Phone = tbPhone.Text;
                    state.Photo = imageBinaryData;

                    using (FileStream file = new FileStream("userstate.dat", FileMode.Create))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(file, state);
                    }

                    if (result.ModifiedCount == 1)
                    {
                        doneIcon.Visible = true;
                        errorIcon.Visible = false;

                        labelUpdateSuccess.Visible = true;
                    }
                    else
                    {
                        doneIcon.Visible = false;
                        errorIcon.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный день, месяц или год", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Неверный формат даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image byteArrayToImage(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            Image image = Image.FromStream(memoryStream);
            return image;
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            string file = "userstate.dat";
            if (File.Exists(file))
            {
                File.Delete(file);
            }

            Authorization auth = new Authorization();
            auth.Show();
            this.Close();
        }
    }
}
