﻿
namespace DEX
{
    partial class Registration
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Логин";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.textBox1.Location = new System.Drawing.Point(22, 38);
            this.textBox1.MaxLength = 32;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 30);
            this.textBox1.TabIndex = 6;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.buttonLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.buttonLogin.FlatAppearance.BorderSize = 3;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.buttonLogin.Location = new System.Drawing.Point(22, 151);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(197, 42);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Зарегистрироваться";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Пароль";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.textBox2.Location = new System.Drawing.Point(22, 103);
            this.textBox2.MaxLength = 32;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '•';
            this.textBox2.Size = new System.Drawing.Size(197, 30);
            this.textBox2.TabIndex = 8;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(238, 213);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonLogin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}