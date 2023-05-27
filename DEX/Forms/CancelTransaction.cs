using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DEX.Forms
{
    public partial class CancelTransaction : Form
    {
        private ObjectId _id;

        public CancelTransaction(ObjectId id)
        {
            InitializeComponent();

            _id = id;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnYes_Click(object sender, EventArgs e)
        {
            var database = DBManager.GetDatabase();

            var lots = database.GetCollection<BsonDocument>("Lots");
            var lotsFilter = Builders<BsonDocument>.Filter.Eq("_id", _id);

            await lots.DeleteOneAsync(lotsFilter);

            MessageBox.Show($"Лот {_id} успешно удален.");

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
