namespace Movie_Theater
{
    partial class ClientPortal
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
            this.movieShowtimeListBox = new System.Windows.Forms.ListBox();
            this.showtimeLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.titleDisplayLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buyTicketButton = new System.Windows.Forms.Button();
            this.genreDisplayLabel = new System.Windows.Forms.Label();
            this.lengthDisplayLabel = new System.Windows.Forms.Label();
            this.movieLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.viewETicketButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // movieShowtimeListBox
            // 
            this.movieShowtimeListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.movieShowtimeListBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.movieShowtimeListBox.FormattingEnabled = true;
            this.movieShowtimeListBox.ItemHeight = 16;
            this.movieShowtimeListBox.Location = new System.Drawing.Point(16, 44);
            this.movieShowtimeListBox.Margin = new System.Windows.Forms.Padding(4);
            this.movieShowtimeListBox.Name = "movieShowtimeListBox";
            this.movieShowtimeListBox.Size = new System.Drawing.Size(313, 340);
            this.movieShowtimeListBox.TabIndex = 0;
            this.movieShowtimeListBox.SelectedIndexChanged += new System.EventHandler(this.MovieShowtimeListBox_SelectedIndexChanged);
            // 
            // showtimeLabel
            // 
            this.showtimeLabel.AutoSize = true;
            this.showtimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showtimeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.showtimeLabel.Location = new System.Drawing.Point(11, 11);
            this.showtimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.showtimeLabel.Name = "showtimeLabel";
            this.showtimeLabel.Size = new System.Drawing.Size(141, 29);
            this.showtimeLabel.TabIndex = 1;
            this.showtimeLabel.Text = "Showtimes";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleLabel.Location = new System.Drawing.Point(4, 12);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(35, 17);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Title";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.genreLabel.Location = new System.Drawing.Point(4, 46);
            this.genreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(48, 17);
            this.genreLabel.TabIndex = 3;
            this.genreLabel.Text = "Genre";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lengthLabel.Location = new System.Drawing.Point(4, 79);
            this.lengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(52, 17);
            this.lengthLabel.TabIndex = 4;
            this.lengthLabel.Text = "Length";
            // 
            // titleDisplayLabel
            // 
            this.titleDisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleDisplayLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleDisplayLabel.Location = new System.Drawing.Point(64, 6);
            this.titleDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleDisplayLabel.Name = "titleDisplayLabel";
            this.titleDisplayLabel.Size = new System.Drawing.Size(133, 28);
            this.titleDisplayLabel.TabIndex = 5;
            this.titleDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.buyTicketButton);
            this.panel1.Controls.Add(this.genreDisplayLabel);
            this.panel1.Controls.Add(this.lengthDisplayLabel);
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Controls.Add(this.genreLabel);
            this.panel1.Controls.Add(this.lengthLabel);
            this.panel1.Controls.Add(this.titleDisplayLabel);
            this.panel1.Location = new System.Drawing.Point(376, 44);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 194);
            this.panel1.TabIndex = 8;
            // 
            // buyTicketButton
            // 
            this.buyTicketButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buyTicketButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buyTicketButton.Location = new System.Drawing.Point(64, 124);
            this.buyTicketButton.Margin = new System.Windows.Forms.Padding(4);
            this.buyTicketButton.Name = "buyTicketButton";
            this.buyTicketButton.Size = new System.Drawing.Size(100, 37);
            this.buyTicketButton.TabIndex = 8;
            this.buyTicketButton.Text = "Buy Ticket";
            this.buyTicketButton.UseVisualStyleBackColor = false;
            // 
            // genreDisplayLabel
            // 
            this.genreDisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.genreDisplayLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.genreDisplayLabel.Location = new System.Drawing.Point(64, 39);
            this.genreDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.genreDisplayLabel.Name = "genreDisplayLabel";
            this.genreDisplayLabel.Size = new System.Drawing.Size(133, 28);
            this.genreDisplayLabel.TabIndex = 7;
            this.genreDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lengthDisplayLabel
            // 
            this.lengthDisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lengthDisplayLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lengthDisplayLabel.Location = new System.Drawing.Point(64, 73);
            this.lengthDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lengthDisplayLabel.Name = "lengthDisplayLabel";
            this.lengthDisplayLabel.Size = new System.Drawing.Size(133, 28);
            this.lengthDisplayLabel.TabIndex = 6;
            this.lengthDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // movieLabel
            // 
            this.movieLabel.AutoSize = true;
            this.movieLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.movieLabel.Location = new System.Drawing.Point(371, 11);
            this.movieLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.movieLabel.Name = "movieLabel";
            this.movieLabel.Size = new System.Drawing.Size(83, 29);
            this.movieLabel.TabIndex = 9;
            this.movieLabel.Text = "Movie";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(681, 44);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 261);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // viewETicketButton
            // 
            this.viewETicketButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewETicketButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.viewETicketButton.Location = new System.Drawing.Point(431, 278);
            this.viewETicketButton.Margin = new System.Windows.Forms.Padding(4);
            this.viewETicketButton.Name = "viewETicketButton";
            this.viewETicketButton.Size = new System.Drawing.Size(129, 50);
            this.viewETicketButton.TabIndex = 11;
            this.viewETicketButton.Text = "View E-Ticket";
            this.viewETicketButton.UseVisualStyleBackColor = false;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logoutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.logoutButton.Location = new System.Drawing.Point(804, 343);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(4);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(125, 42);
            this.logoutButton.TabIndex = 12;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ClientPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(951, 410);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.viewETicketButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.movieLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.showtimeLabel);
            this.Controls.Add(this.movieShowtimeListBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientPortal";
            this.Opacity = 0.9D;
            this.Text = "ClientPortal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox movieShowtimeListBox;
        private System.Windows.Forms.Label showtimeLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label titleDisplayLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buyTicketButton;
        private System.Windows.Forms.Label genreDisplayLabel;
        private System.Windows.Forms.Label lengthDisplayLabel;
        private System.Windows.Forms.Label movieLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button viewETicketButton;
        private System.Windows.Forms.Button logoutButton;
    }
}