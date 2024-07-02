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
            this.tbGenreSpecific = new System.Windows.Forms.TextBox();
            this.lblGenreSpecific = new System.Windows.Forms.Label();
            this.btDeleteGame = new System.Windows.Forms.Button();
            this.CLBGenres = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbAllGames = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btDeleteComment = new System.Windows.Forms.Button();
            this.lbAllReports = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNewUsername = new System.Windows.Forms.TextBox();
            this.btChangeUsername = new System.Windows.Forms.Button();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAddGame
            // 
            this.btAddGame.AutoEllipsis = true;
            this.btAddGame.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btAddGame.Location = new System.Drawing.Point(5, 371);
            this.btAddGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAddGame.Name = "btAddGame";
            this.btAddGame.Size = new System.Drawing.Size(153, 67);
            this.btAddGame.TabIndex = 0;
            this.btAddGame.Text = "Create game";
            this.btAddGame.UseVisualStyleBackColor = true;
            this.btAddGame.Click += new System.EventHandler(this.btAddGame_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(10, 73);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(159, 23);
            this.tbTitle.TabIndex = 1;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // tbReleaseDate
            // 
            this.tbReleaseDate.Location = new System.Drawing.Point(10, 115);
            this.tbReleaseDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReleaseDate.Name = "tbReleaseDate";
            this.tbReleaseDate.Size = new System.Drawing.Size(159, 23);
            this.tbReleaseDate.TabIndex = 2;
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(10, 164);
            this.tbURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(157, 23);
            this.tbURL.TabIndex = 3;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(5, 213);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(288, 96);
            this.tbDescription.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter the title of the game:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Enter the release date of the game:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enter the game photo URL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Enter the game description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(105, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Add game form";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(953, 496);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbGenreSpecific);
            this.tabPage1.Controls.Add(this.lblGenreSpecific);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(945, 468);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Game Form";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbGenreSpecific
            // 
            this.tbGenreSpecific.Location = new System.Drawing.Point(299, 234);
            this.tbGenreSpecific.Multiline = true;
            this.tbGenreSpecific.Name = "tbGenreSpecific";
            this.tbGenreSpecific.Size = new System.Drawing.Size(185, 75);
            this.tbGenreSpecific.TabIndex = 17;
            // 
            // lblGenreSpecific
            // 
            this.lblGenreSpecific.AutoSize = true;
            this.lblGenreSpecific.Location = new System.Drawing.Point(299, 216);
            this.lblGenreSpecific.Name = "lblGenreSpecific";
            this.lblGenreSpecific.Size = new System.Drawing.Size(0, 15);
            this.lblGenreSpecific.TabIndex = 16;
            // 
            // btDeleteGame
            // 
            this.btDeleteGame.Location = new System.Drawing.Point(312, 369);
            this.btDeleteGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDeleteGame.Name = "btDeleteGame";
            this.btDeleteGame.Size = new System.Drawing.Size(173, 67);
            this.btDeleteGame.TabIndex = 15;
            this.btDeleteGame.Text = "Delete Game";
            this.btDeleteGame.UseVisualStyleBackColor = true;
            this.btDeleteGame.Click += new System.EventHandler(this.btDeleteGame_Click);
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
            this.CLBGenres.Location = new System.Drawing.Point(299, 76);
            this.CLBGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CLBGenres.Name = "CLBGenres";
            this.CLBGenres.Size = new System.Drawing.Size(159, 130);
            this.CLBGenres.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Choose game genre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(638, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Display all games";
            // 
            // lbAllGames
            // 
            this.lbAllGames.FormattingEnabled = true;
            this.lbAllGames.ItemHeight = 15;
            this.lbAllGames.Location = new System.Drawing.Point(490, 56);
            this.lbAllGames.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbAllGames.Name = "lbAllGames";
            this.lbAllGames.Size = new System.Drawing.Size(449, 379);
            this.lbAllGames.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.btDeleteComment);
            this.tabPage2.Controls.Add(this.lbAllReports);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tbNewUsername);
            this.tabPage2.Controls.Add(this.btChangeUsername);
            this.tabPage2.Controls.Add(this.lbUsers);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(945, 468);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User Form";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(96, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 21);
            this.label10.TabIndex = 7;
            this.label10.Text = "Reports";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(734, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "Users";
            // 
            // btDeleteComment
            // 
            this.btDeleteComment.Location = new System.Drawing.Point(311, 406);
            this.btDeleteComment.Name = "btDeleteComment";
            this.btDeleteComment.Size = new System.Drawing.Size(115, 50);
            this.btDeleteComment.TabIndex = 5;
            this.btDeleteComment.Text = "Delete comment";
            this.btDeleteComment.UseVisualStyleBackColor = true;
            this.btDeleteComment.Click += new System.EventHandler(this.btDeleteComment_Click);
            // 
            // lbAllReports
            // 
            this.lbAllReports.FormattingEnabled = true;
            this.lbAllReports.ItemHeight = 15;
            this.lbAllReports.Location = new System.Drawing.Point(6, 65);
            this.lbAllReports.Name = "lbAllReports";
            this.lbAllReports.Size = new System.Drawing.Size(304, 304);
            this.lbAllReports.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(480, 359);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Enter new username";
            // 
            // tbNewUsername
            // 
            this.tbNewUsername.Location = new System.Drawing.Point(480, 377);
            this.tbNewUsername.Name = "tbNewUsername";
            this.tbNewUsername.Size = new System.Drawing.Size(131, 23);
            this.tbNewUsername.TabIndex = 2;
            // 
            // btChangeUsername
            // 
            this.btChangeUsername.Location = new System.Drawing.Point(480, 406);
            this.btChangeUsername.Name = "btChangeUsername";
            this.btChangeUsername.Size = new System.Drawing.Size(131, 50);
            this.btChangeUsername.TabIndex = 1;
            this.btChangeUsername.Text = "Submit new username";
            this.btChangeUsername.UseVisualStyleBackColor = true;
            this.btChangeUsername.Click += new System.EventHandler(this.btChangeUsername_Click);
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.ItemHeight = 15;
            this.lbUsers.Location = new System.Drawing.Point(610, 59);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(312, 304);
            this.lbUsers.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 492);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private Button btChangeUsername;
        private ListBox lbUsers;
        private Label label8;
        private TextBox tbNewUsername;
        private Button btDeleteComment;
        private ListBox lbAllReports;
        private Label label10;
        private Label label9;
        private TextBox tbGenreSpecific;
        private Label lblGenreSpecific;
    }
}