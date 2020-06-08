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
            this.Reservation_Id_Label = new System.Windows.Forms.Label();
            this.Reservation_Show_Label = new System.Windows.Forms.Label();
            this.Reservation_Chair_Label = new System.Windows.Forms.Label();
            this.Reservation_Id_Text = new System.Windows.Forms.Label();
            this.Show_Text = new System.Windows.Forms.Label();
            this.Chair_Text = new System.Windows.Forms.Label();
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
            // Reservation_Id_Label
            // 
            this.Reservation_Id_Label.AutoSize = true;
            this.Reservation_Id_Label.Location = new System.Drawing.Point(98, 197);
            this.Reservation_Id_Label.Name = "Reservation_Id_Label";
            this.Reservation_Id_Label.Size = new System.Drawing.Size(72, 13);
            this.Reservation_Id_Label.TabIndex = 5;
            this.Reservation_Id_Label.Text = "Reservatie ID";
            this.Reservation_Id_Label.Click += new System.EventHandler(this.Reservation_Id_Label_Click);
            // 
            // Reservation_Show_Label
            // 
            this.Reservation_Show_Label.AutoSize = true;
            this.Reservation_Show_Label.Location = new System.Drawing.Point(98, 262);
            this.Reservation_Show_Label.Name = "Reservation_Show_Label";
            this.Reservation_Show_Label.Size = new System.Drawing.Size(61, 13);
            this.Reservation_Show_Label.TabIndex = 6;
            this.Reservation_Show_Label.Text = "Voorstelling";
            this.Reservation_Show_Label.Click += new System.EventHandler(this.Reservation_Show_Label_Click);
            // 
            // Reservation_Chair_Label
            // 
            this.Reservation_Chair_Label.AutoSize = true;
            this.Reservation_Chair_Label.Location = new System.Drawing.Point(98, 339);
            this.Reservation_Chair_Label.Name = "Reservation_Chair_Label";
            this.Reservation_Chair_Label.Size = new System.Drawing.Size(31, 13);
            this.Reservation_Chair_Label.TabIndex = 7;
            this.Reservation_Chair_Label.Text = "Stoel";
            this.Reservation_Chair_Label.Click += new System.EventHandler(this.Reservation_Chair_Label_Click);
            // 
            // Reservation_Id_Text
            // 
            this.Reservation_Id_Text.AutoSize = true;
            this.Reservation_Id_Text.Location = new System.Drawing.Point(237, 197);
            this.Reservation_Id_Text.Name = "Reservation_Id_Text";
            this.Reservation_Id_Text.Size = new System.Drawing.Size(35, 13);
            this.Reservation_Id_Text.TabIndex = 8;
            this.Reservation_Id_Text.Text = "label1";
            this.Reservation_Id_Text.Click += new System.EventHandler(this.Reservation_Id_Text_Click);
            // 
            // Show_Text
            // 
            this.Show_Text.AutoSize = true;
            this.Show_Text.Location = new System.Drawing.Point(237, 262);
            this.Show_Text.Name = "Show_Text";
            this.Show_Text.Size = new System.Drawing.Size(35, 13);
            this.Show_Text.TabIndex = 9;
            this.Show_Text.Text = "label2";
            this.Show_Text.Click += new System.EventHandler(this.Show_Text_Click);
            // 
            // Chair_Text
            // 
            this.Chair_Text.AutoSize = true;
            this.Chair_Text.Location = new System.Drawing.Point(237, 339);
            this.Chair_Text.Name = "Chair_Text";
            this.Chair_Text.Size = new System.Drawing.Size(35, 13);
            this.Chair_Text.TabIndex = 10;
            this.Chair_Text.Text = "label3";
            this.Chair_Text.Click += new System.EventHandler(this.Chair_Text_Click);
            // 
            // ReservationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 654);
            this.Controls.Add(this.Chair_Text);
            this.Controls.Add(this.Show_Text);
            this.Controls.Add(this.Reservation_Id_Text);
            this.Controls.Add(this.Reservation_Chair_Label);
            this.Controls.Add(this.Reservation_Show_Label);
            this.Controls.Add(this.Reservation_Id_Label);
            this.Controls.Add(this.Delete_Reservation_button);
            this.Controls.Add(this.Confirm_Changes_Button);
            this.Controls.Add(this.Reservation_Detail_Label);
            this.Name = "ReservationDetail";
            this.Text = "/";
            this.Controls.SetChildIndex(this.Reservation_Detail_Label, 0);
            this.Controls.SetChildIndex(this.Confirm_Changes_Button, 0);
            this.Controls.SetChildIndex(this.Delete_Reservation_button, 0);
            this.Controls.SetChildIndex(this.Reservation_Id_Label, 0);
            this.Controls.SetChildIndex(this.Reservation_Show_Label, 0);
            this.Controls.SetChildIndex(this.Reservation_Chair_Label, 0);
            this.Controls.SetChildIndex(this.Reservation_Id_Text, 0);
            this.Controls.SetChildIndex(this.Show_Text, 0);
            this.Controls.SetChildIndex(this.Chair_Text, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Reservation_Detail_Label;
        private System.Windows.Forms.Button Confirm_Changes_Button;
        private System.Windows.Forms.Button Delete_Reservation_button;
        private System.Windows.Forms.Label Reservation_Id_Label;
        private System.Windows.Forms.Label Reservation_Show_Label;
        private System.Windows.Forms.Label Reservation_Chair_Label;
        private System.Windows.Forms.Label Reservation_Id_Text;
        private System.Windows.Forms.Label Show_Text;
        private System.Windows.Forms.Label Chair_Text;
    }
}