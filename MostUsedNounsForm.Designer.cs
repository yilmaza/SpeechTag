namespace Alev
{
    partial class MostUsedNounsForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Noun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrectUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrectUsePerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncorrectUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncorrectUserPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Noun,
            this.TotalUse,
            this.CorrectUse,
            this.CorrectUsePerc,
            this.IncorrectUse,
            this.IncorrectUserPerc});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1062, 628);
            this.dataGridView1.TabIndex = 1;
            // 
            // Noun
            // 
            this.Noun.DataPropertyName = "Noun";
            this.Noun.HeaderText = "Noun";
            this.Noun.Name = "Noun";
            // 
            // TotalUse
            // 
            this.TotalUse.DataPropertyName = "TotalUse";
            this.TotalUse.HeaderText = "Total Use";
            this.TotalUse.Name = "TotalUse";
            // 
            // CorrectUse
            // 
            this.CorrectUse.DataPropertyName = "CorrectUse";
            this.CorrectUse.HeaderText = "Correct Use";
            this.CorrectUse.Name = "CorrectUse";
            // 
            // CorrectUsePerc
            // 
            this.CorrectUsePerc.DataPropertyName = "CorrectUsePerc";
            this.CorrectUsePerc.HeaderText = "CorrectUsePerc";
            this.CorrectUsePerc.Name = "CorrectUsePerc";
            // 
            // IncorrectUse
            // 
            this.IncorrectUse.DataPropertyName = "IncorrectUse";
            this.IncorrectUse.HeaderText = "IncorrectUse";
            this.IncorrectUse.Name = "IncorrectUse";
            // 
            // IncorrectUserPerc
            // 
            this.IncorrectUserPerc.DataPropertyName = "IncorrectUsePerc";
            this.IncorrectUserPerc.HeaderText = "IncorrectUsePerc";
            this.IncorrectUserPerc.Name = "IncorrectUserPerc";
            // 
            // MostUsedNounsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 628);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MostUsedNounsForm";
            this.Text = "Most Used Nouns";
            this.Load += new System.EventHandler(this.MostUsedNounsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noun;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrectUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrectUsePerc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncorrectUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncorrectUserPerc;

    }
}