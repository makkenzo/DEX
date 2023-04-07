﻿
namespace DEX.Forms
{
    partial class Transaction
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelCoin = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbCoin = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbSum = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbType = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnDone = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DEX.Properties.Resources.close_button;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(530, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 36);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(122)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(571, 46);
            this.panel1.TabIndex = 12;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(62, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "DEX";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DEX.Properties.Resources.logo_color1;
            this.pictureBox2.Location = new System.Drawing.Point(12, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelId.ForeColor = System.Drawing.Color.White;
            this.labelId.Location = new System.Drawing.Point(127, 58);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(35, 23);
            this.labelId.TabIndex = 13;
            this.labelId.Text = "_id";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDate.ForeColor = System.Drawing.Color.White;
            this.labelDate.Location = new System.Drawing.Point(109, 331);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(53, 23);
            this.labelDate.TabIndex = 14;
            this.labelDate.Text = "Дата";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUser.ForeColor = System.Drawing.Color.White;
            this.labelUser.Location = new System.Drawing.Point(25, 292);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(137, 23);
            this.labelUser.TabIndex = 15;
            this.labelUser.Text = "Пользователь";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelType.ForeColor = System.Drawing.Color.White;
            this.labelType.Location = new System.Drawing.Point(74, 253);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(88, 23);
            this.labelType.TabIndex = 16;
            this.labelType.Text = "Тип лота";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSum.ForeColor = System.Drawing.Color.White;
            this.labelSum.Location = new System.Drawing.Point(55, 214);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(107, 23);
            this.labelSum.TabIndex = 17;
            this.labelSum.Text = "Стоимость";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAmount.ForeColor = System.Drawing.Color.White;
            this.labelAmount.Location = new System.Drawing.Point(46, 175);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(116, 23);
            this.labelAmount.TabIndex = 18;
            this.labelAmount.Text = "Количество";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.ForeColor = System.Drawing.Color.White;
            this.labelPrice.Location = new System.Drawing.Point(107, 136);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(55, 23);
            this.labelPrice.TabIndex = 19;
            this.labelPrice.Text = "Цена";
            // 
            // labelCoin
            // 
            this.labelCoin.AutoSize = true;
            this.labelCoin.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCoin.ForeColor = System.Drawing.Color.White;
            this.labelCoin.Location = new System.Drawing.Point(84, 97);
            this.labelCoin.Name = "labelCoin";
            this.labelCoin.Size = new System.Drawing.Size(78, 23);
            this.labelCoin.TabIndex = 20;
            this.labelCoin.Text = "Валюта";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(168, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(386, 1);
            this.panel3.TabIndex = 24;
            // 
            // tbId
            // 
            this.tbId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.tbId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbId.ForeColor = System.Drawing.Color.Gray;
            this.tbId.Location = new System.Drawing.Point(168, 58);
            this.tbId.MaxLength = 105;
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(386, 23);
            this.tbId.TabIndex = 23;
            this.tbId.Text = "_id";
            // 
            // tbCoin
            // 
            this.tbCoin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.tbCoin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCoin.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCoin.ForeColor = System.Drawing.Color.Gray;
            this.tbCoin.Location = new System.Drawing.Point(168, 97);
            this.tbCoin.MaxLength = 105;
            this.tbCoin.Name = "tbCoin";
            this.tbCoin.ReadOnly = true;
            this.tbCoin.Size = new System.Drawing.Size(386, 23);
            this.tbCoin.TabIndex = 23;
            this.tbCoin.Text = "coin";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(168, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 1);
            this.panel2.TabIndex = 24;
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPrice.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPrice.ForeColor = System.Drawing.Color.Gray;
            this.tbPrice.Location = new System.Drawing.Point(168, 136);
            this.tbPrice.MaxLength = 105;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.ReadOnly = true;
            this.tbPrice.Size = new System.Drawing.Size(386, 23);
            this.tbPrice.TabIndex = 23;
            this.tbPrice.Text = "price";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(168, 164);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(386, 1);
            this.panel4.TabIndex = 24;
            // 
            // tbAmount
            // 
            this.tbAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.tbAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAmount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAmount.ForeColor = System.Drawing.Color.Gray;
            this.tbAmount.Location = new System.Drawing.Point(168, 175);
            this.tbAmount.MaxLength = 105;
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.ReadOnly = true;
            this.tbAmount.Size = new System.Drawing.Size(386, 23);
            this.tbAmount.TabIndex = 23;
            this.tbAmount.Text = "amount";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(168, 203);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(386, 1);
            this.panel5.TabIndex = 24;
            // 
            // tbSum
            // 
            this.tbSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.tbSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSum.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSum.ForeColor = System.Drawing.Color.Gray;
            this.tbSum.Location = new System.Drawing.Point(168, 214);
            this.tbSum.MaxLength = 105;
            this.tbSum.Name = "tbSum";
            this.tbSum.ReadOnly = true;
            this.tbSum.Size = new System.Drawing.Size(386, 23);
            this.tbSum.TabIndex = 23;
            this.tbSum.Text = "sum";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(168, 242);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(386, 1);
            this.panel6.TabIndex = 24;
            // 
            // tbType
            // 
            this.tbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.tbType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbType.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbType.ForeColor = System.Drawing.Color.Gray;
            this.tbType.Location = new System.Drawing.Point(168, 253);
            this.tbType.MaxLength = 105;
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            this.tbType.Size = new System.Drawing.Size(386, 23);
            this.tbType.TabIndex = 23;
            this.tbType.Text = "type";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(168, 281);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(386, 1);
            this.panel7.TabIndex = 24;
            // 
            // tbUser
            // 
            this.tbUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.tbUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUser.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbUser.ForeColor = System.Drawing.Color.Gray;
            this.tbUser.Location = new System.Drawing.Point(168, 292);
            this.tbUser.MaxLength = 105;
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(386, 23);
            this.tbUser.TabIndex = 23;
            this.tbUser.Text = "user";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(168, 320);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(386, 1);
            this.panel8.TabIndex = 24;
            // 
            // tbDate
            // 
            this.tbDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.tbDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDate.ForeColor = System.Drawing.Color.Gray;
            this.tbDate.Location = new System.Drawing.Point(168, 331);
            this.tbDate.MaxLength = 105;
            this.tbDate.Name = "tbDate";
            this.tbDate.ReadOnly = true;
            this.tbDate.Size = new System.Drawing.Size(386, 23);
            this.tbDate.TabIndex = 23;
            this.tbDate.Text = "date";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Location = new System.Drawing.Point(168, 359);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(386, 1);
            this.panel9.TabIndex = 24;
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnDone.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(122)))), ((int)(((byte)(230)))));
            this.btnDone.FlatAppearance.BorderSize = 2;
            this.btnDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(122)))), ((int)(((byte)(230)))));
            this.btnDone.Location = new System.Drawing.Point(447, 383);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(107, 33);
            this.btnDone.TabIndex = 54;
            this.btnDone.Text = "Купить";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // Transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(571, 428);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.tbSum);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbCoin);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelCoin);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Roboto", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Transaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transaction";
            this.Load += new System.EventHandler(this.Transaction_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelCoin;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbCoin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbSum;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnDone;
    }
}