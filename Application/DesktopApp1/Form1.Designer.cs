namespace DesktopApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btAddGame = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbReleaseDate = new System.Windows.Forms.TextBox();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CLBGenres = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbAllGames = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btDeleteGame = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAddGame
            // 
            this.btAddGame.AutoEllipsis = true;
            this.btAddGame.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btAddGame.Location = new System.Drawing.Point(6, 495);
            this.btAddGame.Name = "btAddGame";
            this.btAddGame.Size = new System.Drawing.Size(175, 89);
            this.btAddGame.TabIndex = 0;
            this.btAddGame.Text = "Create game";
            this.btAddGame.UseVisualStyleBackColor = true;
            this.btAddGame.Click += new System.EventHandler(this.btAddGame_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(11, 97);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(181, 27);
            this.tbTitle.TabIndex = 1;
            // 
            // tbReleaseDate
            // 
            this.tbReleaseDate.Location = new System.Drawing.Point(11, 153);
            this.tbReleaseDate.Name = "tbReleaseDate";
            this.tbReleaseDate.Size = new System.Drawing.Size(181, 27);
            this.tbReleaseDate.TabIndex = 2;
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(11, 219);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(179, 27);
            this.tbURL.TabIndex = 3;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(6, 284);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(329, 126);
            this.tbDescription.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter the title of the game:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Enter the release date of the game:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enter the game photo URL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Enter the game description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(120, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Add game form";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1089, 620);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btDeleteGame);
            this.tabPage1.Controls.Add(this.CLBGenres);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lbAllGames);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btAddGame);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbTitle);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbReleaseDate);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbURL);
            this.tabPage1.Controls.Add(this.tbDescription);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1081, 587);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Game Form";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CLBGenres
            // 
            this.CLBGenres.FormattingEnabled = true;
            this.CLBGenres.Items.AddRange(new object[] {
            "Action",
            "Platform",
            "Shooter",
            "Survival",
            "Stealth",
            "Battle Royale",
            "MOBA"});
            this.CLBGenres.Location = new System.Drawing.Point(342, 102);
            this.CLBGenres.Name = "CLBGenres";
            this.CLBGenres.Size = new System.Drawing.Size(181, 180);
            this.CLBGenres.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(342, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Choose game genre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(729, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Display all games";
            // 
            // lbAllGames
            // 
            this.lbAllGames.FormattingEnabled = true;
            this.lbAllGames.ItemHeight = 20;
            this.lbAllGames.Location = new System.Drawing.Point(560, 74);
            this.lbAllGames.Name = "lbAllGames";
            this.lbAllGames.Size = new System.Drawing.Size(513, 504);
            this.lbAllGames.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1081, 587);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User Form";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btDeleteGame
            // 
            this.btDeleteGame.Location = new System.Drawing.Point(356, 492);
            this.btDeleteGame.Name = "btDeleteGame";
            this.btDeleteGame.Size = new System.Drawing.Size(198, 89);
            this.btDeleteGame.TabIndex = 15;
            this.btDeleteGame.Text = "Delete Game";
            this.btDeleteGame.UseVisualStyleBackColor = true;
            this.btDeleteGame.Click += new System.EventHandler(this.btDeleteGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 621);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btAddGame;
        private TextBox tbTitle;
        private TextBox tbReleaseDate;
        private TextBox tbURL;
        private TextBox tbDescription;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label6;
        private ListBox lbAllGames;
        private Label label7;
        private CheckedListBox CLBGenres;
        private Button btDeleteGame;
    }
}