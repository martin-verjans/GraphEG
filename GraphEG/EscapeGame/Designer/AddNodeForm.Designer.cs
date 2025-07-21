namespace GraphEG.EscapeGame
{
    partial class AddNodeForm
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
            this.btnAddSkill = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.btnAddClue = new System.Windows.Forms.Button();
            this.btnAddPuzzle = new System.Windows.Forms.Button();
            this.btnAddMeta = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnAddMeta, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnAddPuzzle, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAddClue, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAddRole, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAddRoom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddSkill, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(245, 384);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAddSkill
            // 
            this.btnAddSkill.Location = new System.Drawing.Point(3, 255);
            this.btnAddSkill.Name = "btnAddSkill";
            this.btnAddSkill.Size = new System.Drawing.Size(234, 57);
            this.btnAddSkill.TabIndex = 1;
            this.btnAddSkill.Text = "Skill";
            this.btnAddSkill.UseVisualStyleBackColor = true;
            this.btnAddSkill.Click += new System.EventHandler(this.btnAddSkill_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(3, 3);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(234, 57);
            this.btnAddRoom.TabIndex = 2;
            this.btnAddRoom.Text = "Room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(3, 66);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(234, 57);
            this.btnAddRole.TabIndex = 3;
            this.btnAddRole.Text = "Role";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnAddClue
            // 
            this.btnAddClue.Location = new System.Drawing.Point(3, 129);
            this.btnAddClue.Name = "btnAddClue";
            this.btnAddClue.Size = new System.Drawing.Size(234, 57);
            this.btnAddClue.TabIndex = 4;
            this.btnAddClue.Text = "Clue";
            this.btnAddClue.UseVisualStyleBackColor = true;
            this.btnAddClue.Click += new System.EventHandler(this.btnAddClue_Click);
            // 
            // btnAddPuzzle
            // 
            this.btnAddPuzzle.Location = new System.Drawing.Point(3, 192);
            this.btnAddPuzzle.Name = "btnAddPuzzle";
            this.btnAddPuzzle.Size = new System.Drawing.Size(234, 57);
            this.btnAddPuzzle.TabIndex = 5;
            this.btnAddPuzzle.Text = "Puzzle";
            this.btnAddPuzzle.UseVisualStyleBackColor = true;
            this.btnAddPuzzle.Click += new System.EventHandler(this.btnAddPuzzle_Click);
            // 
            // btnAddMeta
            // 
            this.btnAddMeta.Location = new System.Drawing.Point(3, 318);
            this.btnAddMeta.Name = "btnAddMeta";
            this.btnAddMeta.Size = new System.Drawing.Size(234, 57);
            this.btnAddMeta.TabIndex = 6;
            this.btnAddMeta.Text = "Meta";
            this.btnAddMeta.UseVisualStyleBackColor = true;
            this.btnAddMeta.Click += new System.EventHandler(this.btnAddMeta_Click);
            // 
            // AddNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 384);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddNodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Node Type";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddMeta;
        private System.Windows.Forms.Button btnAddPuzzle;
        private System.Windows.Forms.Button btnAddClue;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnAddSkill;
    }
}