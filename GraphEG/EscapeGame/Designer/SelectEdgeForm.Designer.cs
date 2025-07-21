namespace GraphEG.EscapeGame
{
    partial class SelectEdgeForm
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
            this.lbEdges = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbEdges
            // 
            this.lbEdges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEdges.FormattingEnabled = true;
            this.lbEdges.ItemHeight = 20;
            this.lbEdges.Location = new System.Drawing.Point(0, 0);
            this.lbEdges.Name = "lbEdges";
            this.lbEdges.Size = new System.Drawing.Size(248, 450);
            this.lbEdges.TabIndex = 0;
            this.lbEdges.DoubleClick += new System.EventHandler(this.lbNodes_DoubleClick);
            // 
            // SelectEdgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 450);
            this.Controls.Add(this.lbEdges);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectEdgeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Edge";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbEdges;
    }
}