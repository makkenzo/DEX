namespace DEX
{
    partial class MenuUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuUser));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.buttonCryptocurrencies = new System.Windows.Forms.Button();
            this.buttonHistory = new System.Windows.Forms.Button();
            this.buttonLots = new System.Windows.Forms.Button();
            this.buttonRating = new System.Windows.Forms.Button();
            this.buttonBalance = new System.Windows.Forms.Button();
            this.buttonProfile = new System.Windows.Forms.Button();
            this.buttonSettingsLeft = new System.Windows.Forms.Panel();
            this.buttonCryptocurrenciesLeft = new System.Windows.Forms.Panel();
            this.buttonHistoryLeft = new System.Windows.Forms.Panel();
            this.buttonLotsLeft = new System.Windows.Forms.Panel();
            this.buttonRatingLeft = new System.Windows.Forms.Panel();
            this.buttonBalanceLeft = new System.Windows.Forms.Panel();
            this.buttonProfileLeft = new System.Windows.Forms.Panel();
            this.panelProfile = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(122)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1280, 46);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Decentralized Cryptocurrency Application";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DEX.Properties.Resources.logo_color1;
            this.pictureBox2.Location = new System.Drawing.Point(12, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DEX.Properties.Resources.close_button__1_;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1239, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 36);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.panel2.Controls.Add(this.buttonSettings);
            this.panel2.Controls.Add(this.buttonLogOut);
            this.panel2.Controls.Add(this.buttonCryptocurrencies);
            this.panel2.Controls.Add(this.buttonHistory);
            this.panel2.Controls.Add(this.buttonLots);
            this.panel2.Controls.Add(this.buttonRating);
            this.panel2.Controls.Add(this.buttonBalance);
            this.panel2.Controls.Add(this.buttonProfile);
            this.panel2.Controls.Add(this.buttonSettingsLeft);
            this.panel2.Controls.Add(this.buttonCryptocurrenciesLeft);
            this.panel2.Controls.Add(this.buttonHistoryLeft);
            this.panel2.Controls.Add(this.buttonLotsLeft);
            this.panel2.Controls.Add(this.buttonRatingLeft);
            this.panel2.Controls.Add(this.buttonBalanceLeft);
            this.panel2.Controls.Add(this.buttonProfileLeft);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 674);
            this.panel2.TabIndex = 6;
            // 
            // buttonSettings
            // 
            this.buttonSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSettings.ForeColor = System.Drawing.Color.White;
            this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.Location = new System.Drawing.Point(8, 582);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(256, 37);
            this.buttonSettings.TabIndex = 9;
            this.buttonSettings.Text = "Настройки";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.buttonLogOut.FlatAppearance.BorderSize = 0;
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOut.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogOut.ForeColor = System.Drawing.Color.White;
            this.buttonLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogOut.Location = new System.Drawing.Point(8, 625);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(256, 37);
            this.buttonLogOut.TabIndex = 9;
            this.buttonLogOut.Text = "Выйти из аккаунта";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // buttonCryptocurrencies
            // 
            this.buttonCryptocurrencies.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.buttonCryptocurrencies.FlatAppearance.BorderSize = 0;
            this.buttonCryptocurrencies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCryptocurrencies.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCryptocurrencies.ForeColor = System.Drawing.Color.White;
            this.buttonCryptocurrencies.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCryptocurrencies.Location = new System.Drawing.Point(8, 215);
            this.buttonCryptocurrencies.Name = "buttonCryptocurrencies";
            this.buttonCryptocurrencies.Size = new System.Drawing.Size(256, 37);
            this.buttonCryptocurrencies.TabIndex = 9;
            this.buttonCryptocurrencies.Text = "Криптовалюты";
            this.buttonCryptocurrencies.UseVisualStyleBackColor = true;
            this.buttonCryptocurrencies.Click += new System.EventHandler(this.buttonCryptocurrencies_Click);
            // 
            // buttonHistory
            // 
            this.buttonHistory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.buttonHistory.FlatAppearance.BorderSize = 0;
            this.buttonHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHistory.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHistory.ForeColor = System.Drawing.Color.White;
            this.buttonHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHistory.Location = new System.Drawing.Point(8, 172);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(256, 37);
            this.buttonHistory.TabIndex = 9;
            this.buttonHistory.Text = "История покупок";
            this.buttonHistory.UseVisualStyleBackColor = true;
            this.buttonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // buttonLots
            // 
            this.buttonLots.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.buttonLots.FlatAppearance.BorderSize = 0;
            this.buttonLots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLots.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLots.ForeColor = System.Drawing.Color.White;
            this.buttonLots.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLots.Location = new System.Drawing.Point(8, 129);
            this.buttonLots.Name = "buttonLots";
            this.buttonLots.Size = new System.Drawing.Size(256, 37);
            this.buttonLots.TabIndex = 9;
            this.buttonLots.Text = "Лоты";
            this.buttonLots.UseVisualStyleBackColor = true;
            this.buttonLots.Click += new System.EventHandler(this.buttonLots_Click);
            // 
            // buttonRating
            // 
            this.buttonRating.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.buttonRating.FlatAppearance.BorderSize = 0;
            this.buttonRating.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRating.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRating.ForeColor = System.Drawing.Color.White;
            this.buttonRating.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRating.Location = new System.Drawing.Point(8, 86);
            this.buttonRating.Name = "buttonRating";
            this.buttonRating.Size = new System.Drawing.Size(256, 37);
            this.buttonRating.TabIndex = 9;
            this.buttonRating.Text = "Рейтинг";
            this.buttonRating.UseVisualStyleBackColor = true;
            this.buttonRating.Click += new System.EventHandler(this.buttonRating_Click);
            // 
            // buttonBalance
            // 
            this.buttonBalance.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.buttonBalance.FlatAppearance.BorderSize = 0;
            this.buttonBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBalance.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBalance.ForeColor = System.Drawing.Color.White;
            this.buttonBalance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBalance.Location = new System.Drawing.Point(8, 43);
            this.buttonBalance.Name = "buttonBalance";
            this.buttonBalance.Size = new System.Drawing.Size(256, 37);
            this.buttonBalance.TabIndex = 9;
            this.buttonBalance.Text = "Баланс";
            this.buttonBalance.UseVisualStyleBackColor = true;
            this.buttonBalance.Click += new System.EventHandler(this.buttonBalance_Click);
            // 
            // buttonProfile
            // 
            this.buttonProfile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.buttonProfile.FlatAppearance.BorderSize = 0;
            this.buttonProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProfile.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonProfile.ForeColor = System.Drawing.Color.White;
            this.buttonProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonProfile.Location = new System.Drawing.Point(8, 0);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(256, 37);
            this.buttonProfile.TabIndex = 8;
            this.buttonProfile.Text = "Профиль";
            this.buttonProfile.UseVisualStyleBackColor = true;
            this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
            // 
            // buttonSettingsLeft
            // 
            this.buttonSettingsLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(136)))), ((int)(((byte)(255)))));
            this.buttonSettingsLeft.Location = new System.Drawing.Point(0, 582);
            this.buttonSettingsLeft.Name = "buttonSettingsLeft";
            this.buttonSettingsLeft.Size = new System.Drawing.Size(8, 37);
            this.buttonSettingsLeft.TabIndex = 7;
            // 
            // buttonCryptocurrenciesLeft
            // 
            this.buttonCryptocurrenciesLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(136)))), ((int)(((byte)(255)))));
            this.buttonCryptocurrenciesLeft.Location = new System.Drawing.Point(0, 215);
            this.buttonCryptocurrenciesLeft.Name = "buttonCryptocurrenciesLeft";
            this.buttonCryptocurrenciesLeft.Size = new System.Drawing.Size(8, 37);
            this.buttonCryptocurrenciesLeft.TabIndex = 7;
            // 
            // buttonHistoryLeft
            // 
            this.buttonHistoryLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(136)))), ((int)(((byte)(255)))));
            this.buttonHistoryLeft.Location = new System.Drawing.Point(0, 172);
            this.buttonHistoryLeft.Name = "buttonHistoryLeft";
            this.buttonHistoryLeft.Size = new System.Drawing.Size(8, 37);
            this.buttonHistoryLeft.TabIndex = 7;
            // 
            // buttonLotsLeft
            // 
            this.buttonLotsLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(136)))), ((int)(((byte)(255)))));
            this.buttonLotsLeft.Location = new System.Drawing.Point(0, 129);
            this.buttonLotsLeft.Name = "buttonLotsLeft";
            this.buttonLotsLeft.Size = new System.Drawing.Size(8, 37);
            this.buttonLotsLeft.TabIndex = 7;
            // 
            // buttonRatingLeft
            // 
            this.buttonRatingLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(136)))), ((int)(((byte)(255)))));
            this.buttonRatingLeft.Location = new System.Drawing.Point(0, 86);
            this.buttonRatingLeft.Name = "buttonRatingLeft";
            this.buttonRatingLeft.Size = new System.Drawing.Size(8, 37);
            this.buttonRatingLeft.TabIndex = 7;
            // 
            // buttonBalanceLeft
            // 
            this.buttonBalanceLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(136)))), ((int)(((byte)(255)))));
            this.buttonBalanceLeft.Location = new System.Drawing.Point(0, 43);
            this.buttonBalanceLeft.Name = "buttonBalanceLeft";
            this.buttonBalanceLeft.Size = new System.Drawing.Size(8, 37);
            this.buttonBalanceLeft.TabIndex = 7;
            // 
            // buttonProfileLeft
            // 
            this.buttonProfileLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(136)))), ((int)(((byte)(255)))));
            this.buttonProfileLeft.Location = new System.Drawing.Point(0, 0);
            this.buttonProfileLeft.Name = "buttonProfileLeft";
            this.buttonProfileLeft.Size = new System.Drawing.Size(8, 37);
            this.buttonProfileLeft.TabIndex = 7;
            // 
            // panelProfile
            // 
            this.panelProfile.AutoScroll = true;
            this.panelProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.panelProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProfile.Location = new System.Drawing.Point(264, 46);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(1016, 674);
            this.panelProfile.TabIndex = 7;
            this.panelProfile.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            // 
            // MenuUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelProfile);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuUser";
            this.Load += new System.EventHandler(this.MenuUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel buttonProfileLeft;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.Button buttonHistory;
        private System.Windows.Forms.Button buttonLots;
        private System.Windows.Forms.Button buttonRating;
        private System.Windows.Forms.Button buttonBalance;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Button buttonCryptocurrencies;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Panel buttonSettingsLeft;
        private System.Windows.Forms.Panel buttonCryptocurrenciesLeft;
        private System.Windows.Forms.Panel buttonHistoryLeft;
        private System.Windows.Forms.Panel buttonLotsLeft;
        private System.Windows.Forms.Panel buttonRatingLeft;
        private System.Windows.Forms.Panel buttonBalanceLeft;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}