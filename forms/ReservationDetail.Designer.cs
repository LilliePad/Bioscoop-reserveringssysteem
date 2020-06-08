namespace Projects.Forms {
    partial class ReservationDetail {
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
            this.Reservation_Detail_Label = new System.Windows.Forms.Label();
            this.Confirm_Changes_Button = new System.Windows.Forms.Button();
            this.Delete_Reservation_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Reservation_Detail_Label
            // 
            this.Reservation_Detail_Label.AutoSize = true;
            this.Reservation_Detail_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reservation_Detail_Label.Location = new System.Drawing.Point(13, 111);
            this.Reservation_Detail_Label.Name = "Reservation_Detail_Label";
            this.Reservation_Detail_Label.Size = new System.Drawing.Size(470, 63);
            this.Reservation_Detail_Label.TabIndex = 2;
            this.Reservation_Detail_Label.Text = "Reservation Detail";
            // 
            // Confirm_Changes_Button
            // 
            this.Confirm_Changes_Button.Location = new System.Drawing.Point(995, 515);
            this.Confirm_Changes_Button.Name = "Confirm_Changes_Button";
            this.Confirm_Changes_Button.Size = new System.Drawing.Size(276, 97);
            this.Confirm_Changes_Button.TabIndex = 3;
            this.Confirm_Changes_Button.Text = "Confirm Changes";
            this.Confirm_Changes_Button.UseVisualStyleBackColor = true;
            // 
            // Delete_Reservation_button
            // 
            this.Delete_Reservation_button.Location = new System.Drawing.Point(26, 491);
            this.Delete_Reservation_button.Name = "Delete_Reservation_button";
            this.Delete_Reservation_button.Size = new System.Drawing.Size(263, 120);
            this.Delete_Reservation_button.TabIndex = 4;
            this.Delete_Reservation_button.Text = "Delete reservation";
            this.Delete_Reservation_button.UseVisualStyleBackColor = true;
            this.Delete_Reservation_button.Click += new System.EventHandler(this.Delete_Reservation_button_Click);
            // 
            // ReservationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 654);
            this.Controls.Add(this.Delete_Reservation_button);
            this.Controls.Add(this.Confirm_Changes_Button);
            this.Controls.Add(this.Reservation_Detail_Label);
            this.Name = "ReservationDetail";
            this.Text = "/";
            this.Controls.SetChildIndex(this.Reservation_Detail_Label, 0);
            this.Controls.SetChildIndex(this.Confirm_Changes_Button, 0);
            this.Controls.SetChildIndex(this.Delete_Reservation_button, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Reservation_Detail_Label;
        private System.Windows.Forms.Button Confirm_Changes_Button;
        private System.Windows.Forms.Button Delete_Reservation_button;
    }
}