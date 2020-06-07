namespace Project.Forms {
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
            this.Select_Chair_Button = new System.Windows.Forms.Button();
            this.Reserve_Tickets_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Select_Chair_Button
            // 
            this.Select_Chair_Button.Location = new System.Drawing.Point(82, 159);
            this.Select_Chair_Button.Name = "Select_Chair_Button";
            this.Select_Chair_Button.Size = new System.Drawing.Size(139, 89);
            this.Select_Chair_Button.TabIndex = 2;
            this.Select_Chair_Button.Text = "Stoel kiezen";
            this.Select_Chair_Button.UseVisualStyleBackColor = true;
            this.Select_Chair_Button.Click += new System.EventHandler(this.Select_Chair_Button_Click);
            // 
            // Reserve_Tickets_Button
            // 
            this.Reserve_Tickets_Button.Location = new System.Drawing.Point(820, 462);
            this.Reserve_Tickets_Button.Name = "Reserve_Tickets_Button";
            this.Reserve_Tickets_Button.Size = new System.Drawing.Size(420, 159);
            this.Reserve_Tickets_Button.TabIndex = 3;
            this.Reserve_Tickets_Button.Text = "Reserveren";
            this.Reserve_Tickets_Button.UseVisualStyleBackColor = true;
            this.Reserve_Tickets_Button.Click += new System.EventHandler(this.Reserve_Tickets_Button_Click);
            // 
            // ReservationCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 648);
            this.Controls.Add(this.Reserve_Tickets_Button);
            this.Controls.Add(this.Select_Chair_Button);
            this.Name = "ReservationCreate";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.Select_Chair_Button, 0);
            this.Controls.SetChildIndex(this.Reserve_Tickets_Button, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Select_Chair_Button;
        private System.Windows.Forms.Button Reserve_Tickets_Button;
    }
}