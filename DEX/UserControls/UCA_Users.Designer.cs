
namespace DEX.UserControls
{
    partial class UCA_Users
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.errorIcon = new System.Windows.Forms.PictureBox();
            this.doneIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doneIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(124)))), ((int)(((byte)(187)))));
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(124)))), ((int)(((byte)(187)))));
            this.dgvUsers.Location = new System.Drawing.Point(24, 22);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUsers.Size = new System.Drawing.Size(969, 575);
            this.dgvUsers.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.buttonDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(122)))), ((int)(((byte)(230)))));
            this.buttonDelete.FlatAppearance.BorderSize = 2;
            this.buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(122)))), ((int)(((byte)(230)))));
            this.buttonDelete.Location = new System.Drawing.Point(870, 615);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(123, 42);
            this.buttonDelete.TabIndex = 52;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.errorIcon);
            this.panel10.Controls.Add(this.doneIcon);
            this.panel10.Location = new System.Drawing.Point(799, 607);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(65, 58);
            this.panel10.TabIndex = 57;
            // 
            // errorIcon
            // 
            this.errorIcon.Image = global::DEX.Properties.Resources.multiply;
            this.errorIcon.Location = new System.Drawing.Point(18, 14);
            this.errorIcon.Name = "errorIcon";
            this.errorIcon.Size = new System.Drawing.Size(30, 30);
            this.errorIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.errorIcon.TabIndex = 53;
            this.errorIcon.TabStop = false;
            this.errorIcon.Visible = false;
            // 
            // doneIcon
            // 
            this.doneIcon.Image = global::DEX.Properties.Resources.right;
            this.doneIcon.Location = new System.Drawing.Point(18, 14);
            this.doneIcon.Name = "doneIcon";
            this.doneIcon.Size = new System.Drawing.Size(30, 30);
            this.doneIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.doneIcon.TabIndex = 52;
            this.doneIcon.TabStop = false;
            this.doneIcon.Visible = false;
            // 
            // UCA_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dgvUsers);
            this.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.Name = "UCA_Users";
            this.Size = new System.Drawing.Size(1016, 674);
            this.Load += new System.EventHandler(this.UCA_Users_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doneIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.PictureBox errorIcon;
        private System.Windows.Forms.PictureBox doneIcon;
    }
}
