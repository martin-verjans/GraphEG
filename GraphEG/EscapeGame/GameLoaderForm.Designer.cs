namespace GraphEG.EscapeGame
{
    partial class GameLoaderForm
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
            this.lbSessions = new System.Windows.Forms.ListBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNewSessionName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbSessions
            // 
            this.lbSessions.FormattingEnabled = true;
            this.lbSessions.ItemHeight = 20;
            this.lbSessions.Location = new System.Drawing.Point(12, 92);
            this.lbSessions.Name = "lbSessions";
            this.lbSessions.Size = new System.Drawing.Size(640, 244);
            this.lbSessions.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(418, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(233, 74);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New session";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(418, 342);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(233, 74);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load selected";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "New session name :";
            // 
            // tbNewSessionName
            // 
            this.tbNewSessionName.Location = new System.Drawing.Point(168, 32);
            this.tbNewSessionName.Name = "tbNewSessionName";
            this.tbNewSessionName.Size = new System.Drawing.Size(217, 26);
            this.tbNewSessionName.TabIndex = 4;
            // 
            // GameLoaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 450);
            this.Controls.Add(this.tbNewSessionName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lbSessions);
            this.Name = "GameLoaderForm";
            this.Text = "Select existing game session";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbSessions;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNewSessionName;
    }
}