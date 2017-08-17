namespace TurkishTag
{
    partial class MultipleDocumentAnalysisForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rtbIntermediate = new System.Windows.Forms.RichTextBox();
            this.rtbPostBeginner = new System.Windows.Forms.RichTextBox();
            this.rtbBeginner = new System.Windows.Forms.RichTextBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tvVerbs = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tvNouns = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tvActions = new System.Windows.Forms.TreeView();
            this.Noun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrectUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncorrectUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrectUsePerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncorrectUserPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkAllVerbsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllNounsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.rtbIntermediate);
            this.splitContainer1.Panel1.Controls.Add(this.rtbPostBeginner);
            this.splitContainer1.Panel1.Controls.Add(this.rtbBeginner);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1256, 804);
            this.splitContainer1.SplitterDistance = 1009;
            this.splitContainer1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Noun,
            this.Level,
            this.TotalUse,
            this.CorrectUse,
            this.IncorrectUse,
            this.CorrectUsePerc,
            this.IncorrectUserPerc});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1009, 780);
            this.dataGridView1.TabIndex = 0;
            // 
            // rtbIntermediate
            // 
            this.rtbIntermediate.Location = new System.Drawing.Point(638, 525);
            this.rtbIntermediate.Name = "rtbIntermediate";
            this.rtbIntermediate.Size = new System.Drawing.Size(100, 96);
            this.rtbIntermediate.TabIndex = 4;
            this.rtbIntermediate.Text = "";
            // 
            // rtbPostBeginner
            // 
            this.rtbPostBeginner.Location = new System.Drawing.Point(484, 525);
            this.rtbPostBeginner.Name = "rtbPostBeginner";
            this.rtbPostBeginner.Size = new System.Drawing.Size(100, 96);
            this.rtbPostBeginner.TabIndex = 3;
            this.rtbPostBeginner.Text = "";
            // 
            // rtbBeginner
            // 
            this.rtbBeginner.Location = new System.Drawing.Point(330, 525);
            this.rtbBeginner.Name = "rtbBeginner";
            this.rtbBeginner.Size = new System.Drawing.Size(100, 96);
            this.rtbBeginner.TabIndex = 2;
            this.rtbBeginner.Text = "";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAllVerbsToolStripMenuItem,
            this.checkAllNounsToolStripMenuItem,
            this.checkAllActionsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1009, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem1.Text = "Clean All";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(243, 804);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tvVerbs);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(235, 778);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Verbs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tvVerbs
            // 
            this.tvVerbs.CheckBoxes = true;
            this.tvVerbs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvVerbs.Location = new System.Drawing.Point(3, 3);
            this.tvVerbs.Name = "tvVerbs";
            this.tvVerbs.Size = new System.Drawing.Size(229, 772);
            this.tvVerbs.TabIndex = 6;
            this.tvVerbs.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvVerbs_AfterCheck);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tvNouns);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(235, 778);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nouns";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tvNouns
            // 
            this.tvNouns.CheckBoxes = true;
            this.tvNouns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNouns.Location = new System.Drawing.Point(3, 3);
            this.tvNouns.Name = "tvNouns";
            this.tvNouns.Size = new System.Drawing.Size(229, 772);
            this.tvNouns.TabIndex = 7;
            this.tvNouns.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvNouns_AfterCheck);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tvActions);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(235, 778);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Actions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tvActions
            // 
            this.tvActions.CheckBoxes = true;
            this.tvActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvActions.Location = new System.Drawing.Point(0, 0);
            this.tvActions.Name = "tvActions";
            this.tvActions.Size = new System.Drawing.Size(235, 778);
            this.tvActions.TabIndex = 5;
            this.tvActions.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvActions_AfterCheck);
            // 
            // Noun
            // 
            this.Noun.DataPropertyName = "Keyword";
            this.Noun.HeaderText = "Keyword";
            this.Noun.Name = "Noun";
            // 
            // Level
            // 
            this.Level.DataPropertyName = "Level";
            this.Level.HeaderText = "Level";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            // 
            // TotalUse
            // 
            this.TotalUse.DataPropertyName = "TotalUse";
            this.TotalUse.HeaderText = "TotalUse";
            this.TotalUse.Name = "TotalUse";
            // 
            // CorrectUse
            // 
            this.CorrectUse.DataPropertyName = "CorrectUse";
            this.CorrectUse.HeaderText = "CorrectUse";
            this.CorrectUse.Name = "CorrectUse";
            this.CorrectUse.ReadOnly = true;
            // 
            // IncorrectUse
            // 
            this.IncorrectUse.DataPropertyName = "IncorrectUse";
            this.IncorrectUse.HeaderText = "IncorrectUse";
            this.IncorrectUse.Name = "IncorrectUse";
            this.IncorrectUse.ReadOnly = true;
            // 
            // CorrectUsePerc
            // 
            this.CorrectUsePerc.DataPropertyName = "CorrectUsePerc";
            this.CorrectUsePerc.HeaderText = "Target Use";
            this.CorrectUsePerc.Name = "CorrectUsePerc";
            // 
            // IncorrectUserPerc
            // 
            this.IncorrectUserPerc.DataPropertyName = "IncorrectUsePerc";
            this.IncorrectUserPerc.HeaderText = "Non-Target Use";
            this.IncorrectUserPerc.Name = "IncorrectUserPerc";
            // 
            // checkAllVerbsToolStripMenuItem
            // 
            this.checkAllVerbsToolStripMenuItem.Name = "checkAllVerbsToolStripMenuItem";
            this.checkAllVerbsToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.checkAllVerbsToolStripMenuItem.Text = "Check All Verbs";
            this.checkAllVerbsToolStripMenuItem.Click += new System.EventHandler(this.checkAllVerbsToolStripMenuItem_Click);
            // 
            // checkAllNounsToolStripMenuItem
            // 
            this.checkAllNounsToolStripMenuItem.Name = "checkAllNounsToolStripMenuItem";
            this.checkAllNounsToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.checkAllNounsToolStripMenuItem.Text = "Check All Nouns";
            this.checkAllNounsToolStripMenuItem.Click += new System.EventHandler(this.checkAllNounsToolStripMenuItem_Click);
            // 
            // checkAllActionsToolStripMenuItem
            // 
            this.checkAllActionsToolStripMenuItem.Name = "checkAllActionsToolStripMenuItem";
            this.checkAllActionsToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.checkAllActionsToolStripMenuItem.Text = "Check All Actions";
            this.checkAllActionsToolStripMenuItem.Click += new System.EventHandler(this.checkAllActionsToolStripMenuItem_Click);
            // 
            // MultipleDocumentAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 804);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MultipleDocumentAnalysisForm";
            this.Text = "MultipleDocumentAnalysisForm";
            this.Load += new System.EventHandler(this.MultipleDocumentAnalysisForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView tvVerbs;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView tvNouns;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView tvActions;
        private System.Windows.Forms.RichTextBox rtbIntermediate;
        private System.Windows.Forms.RichTextBox rtbPostBeginner;
        private System.Windows.Forms.RichTextBox rtbBeginner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noun;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrectUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncorrectUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrectUsePerc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncorrectUserPerc;
        private System.Windows.Forms.ToolStripMenuItem checkAllVerbsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAllNounsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAllActionsToolStripMenuItem;

    }
}