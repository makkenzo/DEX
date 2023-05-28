namespace DEX.UserControls
{
    partial class UC_Operations
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.dgvOperations = new System.Windows.Forms.DataGridView();
            this.chartMostFrequentCryptocurrencies = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartOperationsFrequency = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMostFrequentCryptocurrencies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOperationsFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOperations
            // 
            this.dgvOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOperations.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(124)))), ((int)(((byte)(187)))));
            this.dgvOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOperations.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOperations.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(124)))), ((int)(((byte)(187)))));
            this.dgvOperations.Location = new System.Drawing.Point(17, 18);
            this.dgvOperations.Name = "dgvOperations";
            this.dgvOperations.ReadOnly = true;
            this.dgvOperations.Size = new System.Drawing.Size(984, 257);
            this.dgvOperations.TabIndex = 2;
            // 
            // chartMostFrequentCryptocurrencies
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMostFrequentCryptocurrencies.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMostFrequentCryptocurrencies.Legends.Add(legend1);
            this.chartMostFrequentCryptocurrencies.Location = new System.Drawing.Point(525, 281);
            this.chartMostFrequentCryptocurrencies.Name = "chartMostFrequentCryptocurrencies";
            this.chartMostFrequentCryptocurrencies.Size = new System.Drawing.Size(476, 380);
            this.chartMostFrequentCryptocurrencies.TabIndex = 3;
            this.chartMostFrequentCryptocurrencies.Text = "chart1";
            // 
            // chartOperationsFrequency
            // 
            chartArea2.Name = "ChartArea1";
            this.chartOperationsFrequency.ChartAreas.Add(chartArea2);
            this.chartOperationsFrequency.Location = new System.Drawing.Point(17, 281);
            this.chartOperationsFrequency.Name = "chartOperationsFrequency";
            this.chartOperationsFrequency.Size = new System.Drawing.Size(502, 380);
            this.chartOperationsFrequency.TabIndex = 3;
            this.chartOperationsFrequency.Text = "chart1";
            // 
            // UC_Operations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.chartOperationsFrequency);
            this.Controls.Add(this.chartMostFrequentCryptocurrencies);
            this.Controls.Add(this.dgvOperations);
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UC_Operations";
            this.Size = new System.Drawing.Size(1016, 674);
            this.Load += new System.EventHandler(this.UC_Operations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMostFrequentCryptocurrencies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOperationsFrequency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOperations;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMostFrequentCryptocurrencies;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOperationsFrequency;
    }
}
