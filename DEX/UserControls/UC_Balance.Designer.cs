namespace DEX.UserControls
{
    partial class UC_Balance
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Balance));
            this.label1 = new System.Windows.Forms.Label();
            this.panelEth = new System.Windows.Forms.Panel();
            this.btnEthEdit = new System.Windows.Forms.Button();
            this.imgEth = new System.Windows.Forms.PictureBox();
            this.labelEthBalance = new System.Windows.Forms.Label();
            this.labelEthAddress = new System.Windows.Forms.Label();
            this.imgEthWallet = new System.Windows.Forms.PictureBox();
            this.panelEth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEthWallet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Реквизиты";
            // 
            // panelEth
            // 
            this.panelEth.Controls.Add(this.btnEthEdit);
            this.panelEth.Controls.Add(this.imgEth);
            this.panelEth.Controls.Add(this.labelEthBalance);
            this.panelEth.Controls.Add(this.labelEthAddress);
            this.panelEth.Controls.Add(this.imgEthWallet);
            this.panelEth.Location = new System.Drawing.Point(35, 75);
            this.panelEth.Name = "panelEth";
            this.panelEth.Size = new System.Drawing.Size(296, 162);
            this.panelEth.TabIndex = 2;
            // 
            // btnEthEdit
            // 
            this.btnEthEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnEthEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(122)))), ((int)(((byte)(230)))));
            this.btnEthEdit.FlatAppearance.BorderSize = 2;
            this.btnEthEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEthEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEthEdit.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEthEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(122)))), ((int)(((byte)(230)))));
            this.btnEthEdit.Location = new System.Drawing.Point(177, 14);
            this.btnEthEdit.Name = "btnEthEdit";
            this.btnEthEdit.Size = new System.Drawing.Size(107, 33);
            this.btnEthEdit.TabIndex = 52;
            this.btnEthEdit.Text = "Изменить";
            this.btnEthEdit.UseVisualStyleBackColor = false;
            this.btnEthEdit.Click += new System.EventHandler(this.btnEthEdit_Click);
            // 
            // imgEth
            // 
            this.imgEth.BackColor = System.Drawing.Color.Transparent;
            this.imgEth.Image = global::DEX.Properties.Resources.ethereum;
            this.imgEth.Location = new System.Drawing.Point(3, 14);
            this.imgEth.Name = "imgEth";
            this.imgEth.Size = new System.Drawing.Size(60, 60);
            this.imgEth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgEth.TabIndex = 4;
            this.imgEth.TabStop = false;
            // 
            // labelEthBalance
            // 
            this.labelEthBalance.AutoSize = true;
            this.labelEthBalance.BackColor = System.Drawing.Color.Transparent;
            this.labelEthBalance.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEthBalance.ForeColor = System.Drawing.Color.Black;
            this.labelEthBalance.Location = new System.Drawing.Point(14, 87);
            this.labelEthBalance.Name = "labelEthBalance";
            this.labelEthBalance.Size = new System.Drawing.Size(95, 29);
            this.labelEthBalance.TabIndex = 3;
            this.labelEthBalance.Text = "Баланс";
            // 
            // labelEthAddress
            // 
            this.labelEthAddress.AutoSize = true;
            this.labelEthAddress.BackColor = System.Drawing.Color.Transparent;
            this.labelEthAddress.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEthAddress.ForeColor = System.Drawing.Color.Black;
            this.labelEthAddress.Location = new System.Drawing.Point(14, 116);
            this.labelEthAddress.Name = "labelEthAddress";
            this.labelEthAddress.Size = new System.Drawing.Size(139, 29);
            this.labelEthAddress.TabIndex = 3;
            this.labelEthAddress.Text = "Реквизиты";
            // 
            // imgEthWallet
            // 
            this.imgEthWallet.Image = ((System.Drawing.Image)(resources.GetObject("imgEthWallet.Image")));
            this.imgEthWallet.Location = new System.Drawing.Point(3, 3);
            this.imgEthWallet.Name = "imgEthWallet";
            this.imgEthWallet.Size = new System.Drawing.Size(290, 156);
            this.imgEthWallet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgEthWallet.TabIndex = 0;
            this.imgEthWallet.TabStop = false;
            // 
            // UC_Balance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.panelEth);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UC_Balance";
            this.Size = new System.Drawing.Size(1016, 674);
            this.Load += new System.EventHandler(this.UC_Balance_Load);
            this.panelEth.ResumeLayout(false);
            this.panelEth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEthWallet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelEth;
        private System.Windows.Forms.PictureBox imgEthWallet;
        private System.Windows.Forms.Label labelEthAddress;
        private System.Windows.Forms.PictureBox imgEth;
        private System.Windows.Forms.Button btnEthEdit;
        private System.Windows.Forms.Label labelEthBalance;
    }
}
