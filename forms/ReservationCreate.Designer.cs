namespace Bioscoop_reserveringssysteem.forms {
    partial class ReservationCreate {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Create_reservation = new System.Windows.Forms.Button();
            this.Reservation_text = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.username_placeholder_text = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chose_chair_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Create_reservation
            // 
            this.Create_reservation.Location = new System.Drawing.Point(1209, 601);
            this.Create_reservation.Name = "Create_reservation";
            this.Create_reservation.Size = new System.Drawing.Size(100, 40);
            this.Create_reservation.TabIndex = 2;
            this.Create_reservation.Text = "Tickets Reserveren";
            this.Create_reservation.UseVisualStyleBackColor = true;
            this.Create_reservation.Click += new System.EventHandler(this.Create_reservation_Click);
            // 
            // Reservation_text
            // 
            this.Reservation_text.AutoSize = true;
            this.Reservation_text.Location = new System.Drawing.Point(30, 122);
            this.Reservation_text.Name = "Reservation_text";
            this.Reservation_text.Size = new System.Drawing.Size(62, 13);
            this.Reservation_text.TabIndex = 3;
            this.Reservation_text.Text = "Reserveren";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // username_placeholder_text
            // 
            this.username_placeholder_text.AutoSize = true;
            this.username_placeholder_text.Location = new System.Drawing.Point(30, 188);
            this.username_placeholder_text.Name = "username_placeholder_text";
            this.username_placeholder_text.Size = new System.Drawing.Size(111, 13);
            this.username_placeholder_text.TabIndex = 5;
            this.username_placeholder_text.Text = "UsernamePlaceholder";
            this.username_placeholder_text.Click += new System.EventHandler(this.username_placeholder_text_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(32, 250);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 230);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // chose_chair_button
            // 
            this.chose_chair_button.Location = new System.Drawing.Point(360, 300);
            this.chose_chair_button.Name = "chose_chair_button";
            this.chose_chair_button.Size = new System.Drawing.Size(194, 72);
            this.chose_chair_button.TabIndex = 8;
            this.chose_chair_button.Text = "Stoel Kiezen";
            this.chose_chair_button.UseVisualStyleBackColor = true;
            this.chose_chair_button.Click += new System.EventHandler(this.chose_chair_button_Click_1);
            // 
            // ReservationCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 653);
            this.Controls.Add(this.chose_chair_button);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.username_placeholder_text);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Reservation_text);
            this.Controls.Add(this.Create_reservation);
            this.Name = "ReservationCreate";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ReservationCreate_Load);
            this.Controls.SetChildIndex(this.Create_reservation, 0);
            this.Controls.SetChildIndex(this.Reservation_text, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.username_placeholder_text, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.chose_chair_button, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Create_reservation;
        private System.Windows.Forms.Label Reservation_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label username_placeholder_text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button chose_chair_button;
    }
}