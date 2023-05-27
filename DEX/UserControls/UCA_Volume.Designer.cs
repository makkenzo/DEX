
namespace DEX.UserControls
{
    partial class UCA_Volume
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.dgvVolume = new System.Windows.Forms.DataGridView();
            this.chartVolume = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVolume
            // 
            this.dgvVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVolume.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(124)))), ((int)(((byte)(187)))));
            this.dgvVolume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVolume.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVolume.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(124)))), ((int)(((byte)(187)))));
            this.dgvVolume.Location = new System.Drawing.Point(17, 17);
            this.dgvVolume.Name = "dgvVolume";
            this.dgvVolume.ReadOnly = true;
            this.dgvVolume.Size = new System.Drawing.Size(982, 301);
            this.dgvVolume.TabIndex = 1;
            // 
            // chartVolume
            // 
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartVolume.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVolume.Legends.Add(legend1);
            this.chartVolume.Location = new System.Drawing.Point(17, 324);
            this.chartVolume.Name = "chartVolume";
            this.chartVolume.Size = new System.Drawing.Size(982, 331);
            this.chartVolume.TabIndex = 2;
            this.chartVolume.Text = "chart1";
            // 
            // UCA_Volume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.chartVolume);
            this.Controls.Add(this.dgvVolume);
            this.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.Name = "UCA_Volume";
            this.Size = new System.Drawing.Size(1016, 674);
            this.Load += new System.EventHandler(this.UCA_Volume_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVolume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVolume;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVolume;
    }
}
