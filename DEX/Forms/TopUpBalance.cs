using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DEX.Authorization;

namespace DEX.Forms
{
    public partial class TopUpBalance : Form
    {
        private UserCredentials _userCredentials;

        public TopUpBalance(UserCredentials userCredentials)
        {
            InitializeComponent();

            _userCredentials = userCredentials;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnTopUpBalance_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            try
            {
                var db = DBManager.GetDatabase();
                var collection = db.GetCollection<BsonDocument>("Users");

                var filter = Builders<BsonDocument>.Filter.Eq("username", _userCredentials.Username);
                var result = await collection.Find(filter).FirstOrDefaultAsync();
                var balanceUSD = result.GetValue("balanceUSD").AsDouble;
                var update = Builders<BsonDocument>.Update
                            .Set("balanceUSD", balanceUSD + double.Parse(tbAmount.Text.Replace(".", ",")));

                await collection.UpdateOneAsync(filter, update);

                MessageBox.Show("Ваш счет успешно пополнен");

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
            finally
            {
                this.Enabled = true;
            }
        }
    }
}
