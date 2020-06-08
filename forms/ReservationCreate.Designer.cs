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
            this.Movie_Picture = new System.Windows.Forms.PictureBox();
            this.Movie_Name_Text = new System.Windows.Forms.Label();
            this.Movie_Name_Label = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.Movie_Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Select_Chair_Button
            // 
            this.Select_Chair_Button.Location = new System.Drawing.Point(268, 391);
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
            // Movie_Picture
            // 
            this.Movie_Picture.Location = new System.Drawing.Point(40, 212);
            this.Movie_Picture.Name = "Movie_Picture";
            this.Movie_Picture.Size = new System.Drawing.Size(207, 268);
            this.Movie_Picture.TabIndex = 4;
            this.Movie_Picture.TabStop = false;
            this.Movie_Picture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Movie_Name_Text
            // 
            this.Movie_Name_Text.AutoSize = true;
            this.Movie_Name_Text.Location = new System.Drawing.Point(38, 118);
            this.Movie_Name_Text.Name = "Movie_Name_Text";
            this.Movie_Name_Text.Size = new System.Drawing.Size(0, 13);
            this.Movie_Name_Text.TabIndex = 5;
            // 
            // Movie_Name_Label
            // 
            this.Movie_Name_Label.AutoSize = true;
            this.Movie_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Movie_Name_Label.Location = new System.Drawing.Point(37, 141);
            this.Movie_Name_Label.Name = "Movie_Name_Label";
            this.Movie_Name_Label.Size = new System.Drawing.Size(631, 63);
            this.Movie_Name_Label.TabIndex = 6;
            this.Movie_Name_Label.Text = "Movie Name Placeholder";
            // 
            // container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(600, 228);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(182, 199);
            this.container.TabIndex = 7;
            this.container.UseCompatibleStateImageBehavior = false;
            this.container.SelectedIndexChanged += new System.EventHandler(this.Selected_Chairs_List_SelectedIndexChanged_1);
            // 
            // ReservationCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 648);
            this.Controls.Add(this.container);
            this.Controls.Add(this.Movie_Name_Label);
            this.Controls.Add(this.Movie_Name_Text);
            this.Controls.Add(this.Movie_Picture);
            this.Controls.Add(this.Reserve_Tickets_Button);
            this.Controls.Add(this.Select_Chair_Button);
            this.Name = "ReservationCreate";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ReservationCreate_Load);
            this.Controls.SetChildIndex(this.Select_Chair_Button, 0);
            this.Controls.SetChildIndex(this.Reserve_Tickets_Button, 0);
            this.Controls.SetChildIndex(this.Movie_Picture, 0);
            this.Controls.SetChildIndex(this.Movie_Name_Text, 0);
            this.Controls.SetChildIndex(this.Movie_Name_Label, 0);
            this.Controls.SetChildIndex(this.container, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Movie_Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Select_Chair_Button;
        private System.Windows.Forms.Button Reserve_Tickets_Button;
        private System.Windows.Forms.PictureBox Movie_Picture;
        private System.Windows.Forms.Label Movie_Name_Text;
        private System.Windows.Forms.Label Movie_Name_Label;
        private System.Windows.Forms.ListView container;
    }
}