namespace GraphEG.EscapeGame
{
    partial class GraphEG
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDesigner = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.openFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lbRecentFolders = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadSelected = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDesigner
            // 
            this.btnDesigner.Location = new System.Drawing.Point(13, 13);
            this.btnDesigner.Name = "btnDesigner";
            this.btnDesigner.Size = new System.Drawing.Size(207, 65);
            this.btnDesigner.TabIndex = 0;
            this.btnDesigner.Text = "Open Designer";
            this.btnDesigner.UseVisualStyleBackColor = true;
            this.btnDesigner.Click += new System.EventHandler(this.btnDesigner_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(13, 84);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(207, 65);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "Start New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "sg";
            this.openFileDialog.Filter = "Static Graph File|*.sg";
            this.openFileDialog.Title = "Select a static graph file";
            // 
            // lbRecentFolders
            // 
            this.lbRecentFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRecentFolders.FormattingEnabled = true;
            this.lbRecentFolders.ItemHeight = 20;
            this.lbRecentFolders.Location = new System.Drawing.Point(3, 22);
            this.lbRecentFolders.Name = "lbRecentFolders";
            this.lbRecentFolders.Size = new System.Drawing.Size(364, 262);
            this.lbRecentFolders.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbRecentFolders);
            this.groupBox1.Location = new System.Drawing.Point(227, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 287);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recent Games";
            // 
            // btnLoadSelected
            // 
            this.btnLoadSelected.Location = new System.Drawing.Point(13, 235);
            this.btnLoadSelected.Name = "btnLoadSelected";
            this.btnLoadSelected.Size = new System.Drawing.Size(207, 65);
            this.btnLoadSelected.TabIndex = 4;
            this.btnLoadSelected.Text = "Load Selected";
            this.btnLoadSelected.UseVisualStyleBackColor = true;
            this.btnLoadSelected.Click += new System.EventHandler(this.btnLoadSelected_Click);
            // 
            // GraphEG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 312);
            this.Controls.Add(this.btnLoadSelected);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnDesigner);
            this.Name = "GraphEG";
            this.Text = "Escape Game Modeling";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDesigner;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.FolderBrowserDialog openFolderDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox lbRecentFolders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadSelected;
    }
}

