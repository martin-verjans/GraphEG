namespace GraphEG.EscapeGame
{
    partial class SelectOriginNodeForm
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
            this.lbNodes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbNodes
            // 
            this.lbNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNodes.FormattingEnabled = true;
            this.lbNodes.ItemHeight = 20;
            this.lbNodes.Location = new System.Drawing.Point(0, 0);
            this.lbNodes.Name = "lbNodes";
            this.lbNodes.Size = new System.Drawing.Size(248, 450);
            this.lbNodes.TabIndex = 0;
            this.lbNodes.DoubleClick += new System.EventHandler(this.lbNodes_DoubleClick);
            // 
            // SelectOriginNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 450);
            this.Controls.Add(this.lbNodes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectOriginNodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Origin Node";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbNodes;
    }
}