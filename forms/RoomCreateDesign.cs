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
        private TextBox NameRoom_input;
        private TextBox Row_input;
        private TextBox Colum_input;
        private Label label6;
        private Button CreateRoomButton;
        private Label Name_text;

        private string RoomNumber;
        private string chairRows;
        private string chairColum;

        public RoomCreateDesign() {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.CreateRoomButton = new System.Windows.Forms.Button();
            this.Create_a_movie_text = new System.Windows.Forms.Label();
            this.Playtime_text = new System.Windows.Forms.Label();
            this.Movie_create_button = new System.Windows.Forms.Button();
            this.NameRoom_input = new System.Windows.Forms.TextBox();
            this.Row_input = new System.Windows.Forms.TextBox();
            this.Colum_input = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Name_text = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CreateRoomButton);
            this.panel1.Controls.Add(this.Create_a_movie_text);
            this.panel1.Controls.Add(this.Playtime_text);
            this.panel1.Controls.Add(this.Movie_create_button);
            this.panel1.Controls.Add(this.NameRoom_input);
            this.panel1.Controls.Add(this.Row_input);
            this.panel1.Controls.Add(this.Colum_input);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Name_text);
            this.panel1.Location = new System.Drawing.Point(40, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 534);
            this.panel1.TabIndex = 20;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CreateRoomButton
            // 
            this.CreateRoomButton.Location = new System.Drawing.Point(149, 212);
            this.CreateRoomButton.Name = "CreateRoomButton";
            this.CreateRoomButton.Size = new System.Drawing.Size(152, 34);
            this.CreateRoomButton.TabIndex = 19;
            this.CreateRoomButton.Text = "Create room";
            this.CreateRoomButton.UseVisualStyleBackColor = true;
            this.CreateRoomButton.Click += new System.EventHandler(this.CreateRoomButton_Click);
            // 
            // Create_a_movie_text
            // 
            this.Create_a_movie_text.AutoSize = true;
            this.Create_a_movie_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Create_a_movie_text.Location = new System.Drawing.Point(3, 0);
            this.Create_a_movie_text.Name = "Create_a_movie_text";
            this.Create_a_movie_text.Size = new System.Drawing.Size(345, 58);
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
            this.Playtime_text.Size = new System.Drawing.Size(42, 20);
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
            // NameRoom_input
            // 
            this.NameRoom_input.Location = new System.Drawing.Point(149, 84);
            this.NameRoom_input.Name = "NameRoom_input";
            this.NameRoom_input.Size = new System.Drawing.Size(495, 22);
            this.NameRoom_input.TabIndex = 14;
            this.NameRoom_input.TextChanged += new System.EventHandler(this.NameMovie_input_TextChanged);
            // 
            // Row_input
            // 
            this.Row_input.Location = new System.Drawing.Point(149, 125);
            this.Row_input.Name = "Row_input";
            this.Row_input.Size = new System.Drawing.Size(495, 22);
            this.Row_input.TabIndex = 16;
            this.Row_input.TextChanged += new System.EventHandler(this.Row_input_TextChanged);
            // 
            // Colum_input
            // 
            this.Colum_input.Location = new System.Drawing.Point(149, 169);
            this.Colum_input.Name = "Colum_input";
            this.Colum_input.Size = new System.Drawing.Size(495, 22);
            this.Colum_input.TabIndex = 17;
            this.Colum_input.TextChanged += new System.EventHandler(this.Colum_input_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(9, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Colum";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Name_text
            // 
            this.Name_text.AutoSize = true;
            this.Name_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name_text.Location = new System.Drawing.Point(9, 84);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(114, 20);
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

        private void NameMovie_input_TextChanged(object sender, EventArgs e) {
            RoomNumber = 
        }

        private void label6_Click(object sender, EventArgs e) {

        }

        private void CreateRoomButton_Click(object sender, EventArgs e) {
            
        }

        private void Colum_input_TextChanged(object sender, EventArgs e) {
            chairColum = Colum_input.Text;
        }

        private void Row_input_TextChanged(object sender, EventArgs e) {
            chairRows = Row_input.Text;
        }
    }
}
