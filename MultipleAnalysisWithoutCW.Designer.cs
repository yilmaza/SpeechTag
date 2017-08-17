﻿namespace TurkishTag
{
    partial class MultipleAnalysisWithoutCW
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.checkAllVerbsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllNounsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Noun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubKeyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrectUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrectUsePerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncorrectUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncorrectUserPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtbIntermediate = new System.Windows.Forms.RichTextBox();
            this.rtbPostBeginner = new System.Windows.Forms.RichTextBox();
            this.rtbBeginner = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tvVerbs = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tvNouns = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tvActions = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAllVerbsToolStripMenuItem,
            this.checkAllNounsToolStripMenuItem,
            this.checkAllActionsToolStripMenuItem,
            this.cleanAllToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1242, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
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
            // cleanAllToolStripMenuItem
            // 
            this.cleanAllToolStripMenuItem.Name = "cleanAllToolStripMenuItem";
            this.cleanAllToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.cleanAllToolStripMenuItem.Text = "Clean All";
            this.cleanAllToolStripMenuItem.Click += new System.EventHandler(this.cleanAllToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.rtbIntermediate);
            this.splitContainer1.Panel1.Controls.Add(this.rtbPostBeginner);
            this.splitContainer1.Panel1.Controls.Add(this.rtbBeginner);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1242, 726);
            this.splitContainer1.SplitterDistance = 995;
            this.splitContainer1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Noun,
            this.SubKeyword,
            this.Level,
            this.TotalUse,
            this.CorrectUse,
            this.CorrectUsePerc,
            this.IncorrectUse,
            this.IncorrectUserPerc});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(995, 726);
            this.dataGridView1.TabIndex = 0;
            // 
            // Noun
            // 
            this.Noun.DataPropertyName = "Keyword";
            this.Noun.HeaderText = "Keyword";
            this.Noun.Name = "Noun";
            // 
            // SubKeyword
            // 
            this.SubKeyword.DataPropertyName = "SubKeyword";
            this.SubKeyword.HeaderText = "SubKeyword";
            this.SubKeyword.Name = "SubKeyword";
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
            // rtbIntermediate
            // 
            this.rtbIntermediate.Location = new System.Drawing.Point(575, 311);
            this.rtbIntermediate.Name = "rtbIntermediate";
            this.rtbIntermediate.Size = new System.Drawing.Size(100, 96);
            this.rtbIntermediate.TabIndex = 7;
            this.rtbIntermediate.Text = "";
            // 
            // rtbPostBeginner
            // 
            this.rtbPostBeginner.Location = new System.Drawing.Point(421, 311);
            this.rtbPostBeginner.Name = "rtbPostBeginner";
            this.rtbPostBeginner.Size = new System.Drawing.Size(100, 96);
            this.rtbPostBeginner.TabIndex = 6;
            this.rtbPostBeginner.Text = "";
            // 
            // rtbBeginner
            // 
            this.rtbBeginner.Location = new System.Drawing.Point(267, 311);
            this.rtbBeginner.Name = "rtbBeginner";
            this.rtbBeginner.Size = new System.Drawing.Size(100, 96);
            this.rtbBeginner.TabIndex = 5;
            this.rtbBeginner.Text = "";
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
            this.tabControl1.Size = new System.Drawing.Size(243, 726);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tvVerbs);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(235, 700);
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
            this.tvVerbs.Size = new System.Drawing.Size(229, 694);
            this.tvVerbs.TabIndex = 6;
            this.tvVerbs.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvVerbs_AfterCheck);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tvNouns);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(235, 700);
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
            this.tvNouns.Size = new System.Drawing.Size(229, 694);
            this.tvNouns.TabIndex = 7;
            this.tvNouns.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvNouns_AfterCheck);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tvActions);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(235, 700);
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
            this.tvActions.Size = new System.Drawing.Size(235, 700);
            this.tvActions.TabIndex = 5;
            this.tvActions.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvActions_AfterCheck);
            // 
            // MultipleAnalysisWithoutCW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 750);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MultipleAnalysisWithoutCW";
            this.Text = "MultipleAnalysisWithoutCW";
            this.Load += new System.EventHandler(this.MultipleAnalysisWithoutCW_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem checkAllVerbsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAllNounsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAllActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanAllToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noun;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubKeyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrectUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrectUsePerc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncorrectUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncorrectUserPerc;
        private System.Windows.Forms.RichTextBox rtbIntermediate;
        private System.Windows.Forms.RichTextBox rtbPostBeginner;
        private System.Windows.Forms.RichTextBox rtbBeginner;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView tvVerbs;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView tvNouns;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView tvActions;
    }
}