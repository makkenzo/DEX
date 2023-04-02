using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX.UserControls
{
    public partial class UC_Profile : UserControl
    {
        private IMongoDatabase _database;
        private UserCredentials _userCredentials;
        private byte[] imageBinaryData;
        
        public UC_Profile(UserCredentials userCredentials)
        {
            InitializeComponent();

            _database = DBManager.GetDatabase();
            _userCredentials = userCredentials;
        }

        private void UC_Profile_Load(object sender, EventArgs e)
        {
            doneIcon.Visible = false;
            errorIcon.Visible = false;

            labelUpdateSuccess.Visible = false;

            /* filling the textboxes with the data from the database. */
            labelUsername.Text = _userCredentials.Username;

            tbFName.Text = _userCredentials.FName;
            tbLName.Text = _userCredentials.LName;

            tbRegistrationDate.Text = _userCredentials.RegistrationDate;
            tbBirthDate.Text = _userCredentials.BirthDate;

            tbEmail.Text = _userCredentials.Email;
            tbUserID.Text = _userCredentials.UserID;
            tbPhone.Text = _userCredentials.Phone;
            labelRating.Text = Convert.ToString(_userCredentials.Activity);

            tbPass.Text = _userCredentials.Pass;

            var binaryData = _userCredentials.Photo.AsBsonBinaryData;
            var bytes = binaryData.AsByteArray;

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image image = Image.FromStream(ms);
                profileImg.Image = image;
            }
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

        private void buttonPassEdit_Click(object sender, EventArgs e)
        {
            tbPass.Enabled = true;
        }

        private void buttonPassShowToggle_Click(object sender, EventArgs e)
        {
            if (tbPass.PasswordChar == '•')
            {
                tbPass.PasswordChar = '\0'; // показываем пароль
                buttonPassShowToggle.BackgroundImage = Properties.Resources.hide; // изменяем изображение на "hide"
            }
            else
            {
                tbPass.PasswordChar = '•'; // скрываем пароль
                buttonPassShowToggle.BackgroundImage = Properties.Resources.show; // изменяем изображение на "show"
            }
        }

        /// <summary>
        /// It takes a byte array and converts it into an image
        /// </summary>
        /// <param name="byteArray">The byte array that you want to convert to an image.</param>
        /// <returns>
        /// The image is being returned.
        /// </returns>
        private Image byteArrayToImage(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            Image image = Image.FromStream(memoryStream);
            return image;
        }

        /// <summary>
        /// It opens a file dialog, reads the selected file into a byte array, crops the image to a
        /// square, and then displays the image in a picture box
        /// </summary>
        /// <param name="sender">The control/object that raised the event.</param>
        /// <param name="EventArgs">e</param>
        private void buttonImageEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageBinaryData = File.ReadAllBytes(openFileDialog.FileName);
                imageBinaryData = CropToSquare(imageBinaryData);
                profileImg.Image = byteArrayToImage(imageBinaryData);
            }
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

        /// <summary>
        /// If the email address contains a character that is not an @ symbol, a space, or a period, and
        /// if the email address contains an @ symbol, a period, and no spaces, then the email address
        /// is valid
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>
        /// The method is returning a boolean value.
        /// </returns>
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// It checks if the phone number is in the format of +12345678901
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>
        /// A boolean value.
        /// </returns>
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(@"^\+\d{11}$");
            return regex.IsMatch(phoneNumber);
        }

        /// <summary>
        /// It takes a byte array of an image, crops it to a square, and returns a byte array of the
        /// cropped image
        /// </summary>
        /// <param name="imageBytes">The image you want to crop.</param>
        /// <returns>
        /// The cropped image in byte array format.
        /// </returns>
        public static byte[] CropToSquare(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image img = Image.FromStream(ms);
                int size = Math.Min(img.Width, img.Height);
                int x = (img.Width - size) / 2;
                int y = (img.Height - size) / 2;

                Rectangle cropArea = new Rectangle(x, y, size, size);

                Bitmap bmp = new Bitmap(cropArea.Width, cropArea.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), cropArea, GraphicsUnit.Pixel);
                }

                using (MemoryStream ms2 = new MemoryStream())
                {
                    bmp.Save(ms2, ImageFormat.Jpeg); // можно изменить формат изображения, если необходимо
                    return ms2.ToArray();
                }
            }
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
                    if (tbPass.Text.Length < 8)
                    {
                        MessageBox.Show("Неверный формат пароля. Введите минимум 8 символов.");
                        return;
                    }
                    if (!IsValidPhoneNumber(tbPhone.Text))
                    {
                        MessageBox.Show("Номер телефона введен некорректно. Пожалуйста, введите номер в формате +xxxxxxxxxxx.");
                        return;
                    }
                    /* Updating the user's information in the database. */
                    var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
                    var update = Builders<BsonDocument>.Update
                        .Set("fName", tbFName.Text)
                        .Set("lName", tbLName.Text)
                        .Set("birthDate", tbBirthDate.Text)
                        .Set("email", tbEmail.Text)
                        .Set("userID", tbUserID.Text)
                        .Set("phone", tbPhone.Text)
                        .Set("password", tbPass.Text);
                    var collection = _database.GetCollection<BsonDocument>("Users");

                    /* Saving the user's information to a file. */
                    UserState state;
                    using (FileStream file = new FileStream("userstate.dat", FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        state = (UserState)formatter.Deserialize(file);
                    }

                    if (imageBinaryData != null && !imageBinaryData.SequenceEqual(state.Photo))
                    {
                        imageBinaryData = CropToSquare(imageBinaryData);
                        update = update.Set("photo", new BsonBinaryData(imageBinaryData));
                        state.Photo = imageBinaryData;
                    }

                    var result = collection.UpdateOne(filter, update);

                    state.FName = tbFName.Text;
                    state.LName = tbLName.Text;
                    state.BirthDate = tbBirthDate.Text;
                    state.Email = tbEmail.Text;
                    state.UserID = tbUserID.Text;
                    state.Phone = tbPhone.Text;
                    state.Pass = tbPass.Text;

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
    }
}
