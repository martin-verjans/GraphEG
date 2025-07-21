namespace GraphEG.EscapeGame
{
    partial class GameDesigner
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemoveEdge = new System.Windows.Forms.Button();
            this.btnAddEdge = new System.Windows.Forms.Button();
            this.btnRemoveNode = new System.Windows.Forms.Button();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.gbDisplay = new System.Windows.Forms.GroupBox();
            this.cbListDisplay = new System.Windows.Forms.CheckedListBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSaveGame = new System.Windows.Forms.Button();
            this.btnNewEG = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbGraph = new System.Windows.Forms.PictureBox();
            this.gbErrors = new System.Windows.Forms.GroupBox();
            this.lbErrors = new System.Windows.Forms.ListBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).BeginInit();
            this.gbErrors.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnRemoveEdge, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAddEdge, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnRemoveNode, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAddNode, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbDisplay, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnLoad, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveGame, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNewEG, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1262, 536);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnRemoveEdge
            // 
            this.btnRemoveEdge.Location = new System.Drawing.Point(1059, 144);
            this.btnRemoveEdge.Name = "btnRemoveEdge";
            this.btnRemoveEdge.Size = new System.Drawing.Size(200, 41);
            this.btnRemoveEdge.TabIndex = 7;
            this.btnRemoveEdge.Text = "Remove Edge";
            this.btnRemoveEdge.UseVisualStyleBackColor = true;
            this.btnRemoveEdge.Click += new System.EventHandler(this.btnRemoveEdge_Click);
            // 
            // btnAddEdge
            // 
            this.btnAddEdge.Location = new System.Drawing.Point(1059, 97);
            this.btnAddEdge.Name = "btnAddEdge";
            this.btnAddEdge.Size = new System.Drawing.Size(200, 41);
            this.btnAddEdge.TabIndex = 6;
            this.btnAddEdge.Text = "Add Edge";
            this.btnAddEdge.UseVisualStyleBackColor = true;
            this.btnAddEdge.Click += new System.EventHandler(this.btnAddEdge_Click);
            // 
            // btnRemoveNode
            // 
            this.btnRemoveNode.Location = new System.Drawing.Point(1059, 50);
            this.btnRemoveNode.Name = "btnRemoveNode";
            this.btnRemoveNode.Size = new System.Drawing.Size(200, 41);
            this.btnRemoveNode.TabIndex = 5;
            this.btnRemoveNode.Text = "Remove Node";
            this.btnRemoveNode.UseVisualStyleBackColor = true;
            this.btnRemoveNode.Click += new System.EventHandler(this.btnRemoveNode_Click);
            // 
            // btnAddNode
            // 
            this.btnAddNode.Location = new System.Drawing.Point(1059, 3);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(200, 41);
            this.btnAddNode.TabIndex = 4;
            this.btnAddNode.Text = "Add Node";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // gbDisplay
            // 
            this.gbDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbDisplay.Controls.Add(this.cbListDisplay);
            this.gbDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDisplay.Location = new System.Drawing.Point(3, 191);
            this.gbDisplay.Name = "gbDisplay";
            this.gbDisplay.Size = new System.Drawing.Size(200, 342);
            this.gbDisplay.TabIndex = 1;
            this.gbDisplay.TabStop = false;
            this.gbDisplay.Text = "Display Options";
            // 
            // cbListDisplay
            // 
            this.cbListDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbListDisplay.FormattingEnabled = true;
            this.cbListDisplay.Location = new System.Drawing.Point(3, 22);
            this.cbListDisplay.Name = "cbListDisplay";
            this.cbListDisplay.Size = new System.Drawing.Size(194, 317);
            this.cbListDisplay.TabIndex = 1;
            this.cbListDisplay.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cbListDisplay_ItemCheck);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(3, 97);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(200, 41);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.Location = new System.Drawing.Point(3, 50);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(200, 41);
            this.btnSaveGame.TabIndex = 2;
            this.btnSaveGame.Text = "Save";
            this.btnSaveGame.UseVisualStyleBackColor = true;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // btnNewEG
            // 
            this.btnNewEG.Location = new System.Drawing.Point(3, 3);
            this.btnNewEG.Name = "btnNewEG";
            this.btnNewEG.Size = new System.Drawing.Size(200, 41);
            this.btnNewEG.TabIndex = 1;
            this.btnNewEG.Text = "New Escape Game";
            this.btnNewEG.UseVisualStyleBackColor = true;
            this.btnNewEG.Click += new System.EventHandler(this.btnNewEG_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(209, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbGraph);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbErrors);
            this.splitContainer1.Panel2MinSize = 50;
            this.tableLayoutPanel1.SetRowSpan(this.splitContainer1, 5);
            this.splitContainer1.Size = new System.Drawing.Size(844, 530);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 11;
            // 
            // pbGraph
            // 
            this.pbGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbGraph.Location = new System.Drawing.Point(0, 0);
            this.pbGraph.Name = "pbGraph";
            this.pbGraph.Size = new System.Drawing.Size(844, 300);
            this.pbGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGraph.TabIndex = 9;
            this.pbGraph.TabStop = false;
            // 
            // gbErrors
            // 
            this.gbErrors.Controls.Add(this.lbErrors);
            this.gbErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbErrors.Location = new System.Drawing.Point(0, 0);
            this.gbErrors.Name = "gbErrors";
            this.gbErrors.Size = new System.Drawing.Size(844, 226);
            this.gbErrors.TabIndex = 10;
            this.gbErrors.TabStop = false;
            this.gbErrors.Text = "Errors";
            // 
            // lbErrors
            // 
            this.lbErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbErrors.FormattingEnabled = true;
            this.lbErrors.ItemHeight = 20;
            this.lbErrors.Location = new System.Drawing.Point(3, 22);
            this.lbErrors.Name = "lbErrors";
            this.lbErrors.Size = new System.Drawing.Size(838, 201);
            this.lbErrors.TabIndex = 0;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "sg";
            this.saveFileDialog.Filter = "Static Graph|*.sg";
            this.saveFileDialog.Title = "Select File Location";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "sg";
            this.openFileDialog.Filter = "Static Graph|*.sg";
            this.openFileDialog.Title = "Select File Location";
            // 
            // GameDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 536);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GameDesigner";
            this.Text = "GameDesigner";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbDisplay.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).EndInit();
            this.gbErrors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnRemoveEdge;
        private System.Windows.Forms.Button btnAddEdge;
        private System.Windows.Forms.Button btnRemoveNode;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.GroupBox gbDisplay;
        private System.Windows.Forms.CheckedListBox cbListDisplay;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSaveGame;
        private System.Windows.Forms.Button btnNewEG;
        private System.Windows.Forms.PictureBox pbGraph;
        private System.Windows.Forms.GroupBox gbErrors;
        private System.Windows.Forms.ListBox lbErrors;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}