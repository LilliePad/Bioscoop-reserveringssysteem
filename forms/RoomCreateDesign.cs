using Project.Forms.Layouts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Forms {
    public partial class RoomCreateDesign : BaseLayout {
        private Panel panel1;
        private Label Create_a_movie_text;
        private Label Playtime_text;
        private Button Movie_create_button;
        private TextBox NameMovie_input;
        private TextBox Duration_input;
        private TextBox Genre_input;
        private Label label6;
        private Label Name_text;

        public RoomCreateDesign() {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Create_a_movie_text = new System.Windows.Forms.Label();
            this.Playtime_text = new System.Windows.Forms.Label();
            this.Movie_create_button = new System.Windows.Forms.Button();
            this.NameMovie_input = new System.Windows.Forms.TextBox();
            this.Duration_input = new System.Windows.Forms.TextBox();
            this.Genre_input = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Name_text = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Create_a_movie_text);
            this.panel1.Controls.Add(this.Playtime_text);
            this.panel1.Controls.Add(this.Movie_create_button);
            this.panel1.Controls.Add(this.NameMovie_input);
            this.panel1.Controls.Add(this.Duration_input);
            this.panel1.Controls.Add(this.Genre_input);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Name_text);
            this.panel1.Location = new System.Drawing.Point(40, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 534);
            this.panel1.TabIndex = 20;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Create_a_movie_text
            // 
            this.Create_a_movie_text.AutoSize = true;
            this.Create_a_movie_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Create_a_movie_text.Location = new System.Drawing.Point(3, 0);
            this.Create_a_movie_text.Name = "Create_a_movie_text";
            this.Create_a_movie_text.Size = new System.Drawing.Size(275, 46);
            this.Create_a_movie_text.TabIndex = 3;
            this.Create_a_movie_text.Text = "Create a room";
            this.Create_a_movie_text.Click += new System.EventHandler(this.Create_a_movie_text_Click);
            // 
            // Playtime_text
            // 
            this.Playtime_text.AutoSize = true;
            this.Playtime_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Playtime_text.Location = new System.Drawing.Point(9, 125);
            this.Playtime_text.Name = "Playtime_text";
            this.Playtime_text.Size = new System.Drawing.Size(35, 17);
            this.Playtime_text.TabIndex = 6;
            this.Playtime_text.Text = "Row";
            // 
            // Movie_create_button
            // 
            this.Movie_create_button.Location = new System.Drawing.Point(125, 472);
            this.Movie_create_button.Name = "Movie_create_button";
            this.Movie_create_button.Size = new System.Drawing.Size(133, 39);
            this.Movie_create_button.TabIndex = 12;
            this.Movie_create_button.Text = "Create room";
            this.Movie_create_button.UseVisualStyleBackColor = true;
            this.Movie_create_button.Click += new System.EventHandler(this.Movie_create_button_Click);
            // 
            // NameMovie_input
            // 
            this.NameMovie_input.Location = new System.Drawing.Point(125, 82);
            this.NameMovie_input.Name = "NameMovie_input";
            this.NameMovie_input.Size = new System.Drawing.Size(495, 20);
            this.NameMovie_input.TabIndex = 14;
            // 
            // Duration_input
            // 
            this.Duration_input.Location = new System.Drawing.Point(125, 125);
            this.Duration_input.Name = "Duration_input";
            this.Duration_input.Size = new System.Drawing.Size(495, 20);
            this.Duration_input.TabIndex = 16;
            // 
            // Genre_input
            // 
            this.Genre_input.Location = new System.Drawing.Point(125, 159);
            this.Genre_input.Name = "Genre_input";
            this.Genre_input.Size = new System.Drawing.Size(495, 20);
            this.Genre_input.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(10, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Chairs";
            // 
            // Name_text
            // 
            this.Name_text.AutoSize = true;
            this.Name_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name_text.Location = new System.Drawing.Point(10, 82);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(97, 17);
            this.Name_text.TabIndex = 4;
            this.Name_text.Text = "Room number";
            // 
            // RoomCreateDesign
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel1);
            this.Name = "RoomCreateDesign";
            this.Load += new System.EventHandler(this.RoomCreateDesign_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void RoomCreateDesign_Load(object sender, EventArgs e) {

        }

        private void Create_a_movie_text_Click(object sender, EventArgs e) {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void Movie_create_button_Click(object sender, EventArgs e) {

        }
    }
}
