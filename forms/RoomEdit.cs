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
using Project.Models;
using Project.Services;
using Project.Helpers;

namespace Project.Forms {
    public partial class RoomEdit : BaseLayout {
        private Panel panel1;
        private Label Create_a_movie_text;
        private TextBox Room_input;
        private Label Name_text;
        private Label label2;

        private int RoomNumber;
        private int RoomId;
        private int Row;
        private int Colum;
        private double Price;
        private string Type;

        public RoomEdit() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "roomEdit";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Create_a_movie_text = new System.Windows.Forms.Label();
            this.Room_input = new System.Windows.Forms.TextBox();
            this.Name_text = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Create_a_movie_text);
            this.panel1.Controls.Add(this.Room_input);
            this.panel1.Controls.Add(this.Name_text);
            this.panel1.Location = new System.Drawing.Point(40, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 534);
            this.panel1.TabIndex = 20;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(10, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 22;
            // 
            // Create_a_movie_text
            // 
            this.Create_a_movie_text.AutoSize = true;
            this.Create_a_movie_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Create_a_movie_text.Location = new System.Drawing.Point(3, 0);
            this.Create_a_movie_text.Name = "Create_a_movie_text";
            this.Create_a_movie_text.Size = new System.Drawing.Size(280, 58);
            this.Create_a_movie_text.TabIndex = 3;
            this.Create_a_movie_text.Text = "Edit a room";
            this.Create_a_movie_text.Click += new System.EventHandler(this.Create_a_movie_text_Click);
            // 
            // Room_input
            // 
            this.Room_input.Location = new System.Drawing.Point(125, 82);
            this.Room_input.Name = "Room_input";
            this.Room_input.Size = new System.Drawing.Size(495, 22);
            this.Room_input.TabIndex = 14;
            this.Room_input.TextChanged += new System.EventHandler(this.Room_input_TextChanged);
            // 
            // Name_text
            // 
            this.Name_text.AutoSize = true;
            this.Name_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name_text.Location = new System.Drawing.Point(10, 82);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(114, 20);
            this.Name_text.TabIndex = 4;
            this.Name_text.Text = "Room number";
            // 
            // RoomEdit
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel1);
            this.Name = "RoomEdit";
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

        private void label6_Click(object sender, EventArgs e) {

        }

        private void Colum_input_TextChanged(object sender, EventArgs e) {
            try {
                

            }
            catch (FormatException) {
                MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Row_input_TextChanged(object sender, EventArgs e) {
            try {
                

            }
            catch (FormatException) {
                MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Room_input_TextChanged(object sender, EventArgs e) {
            try {
                RoomNumber = int.Parse(Room_input.Text);

            }
            catch (FormatException) {
                MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ChairService chairManager = app.GetService<ChairService>("chairs");
            RoomService roomManager = app.GetService<RoomService>("rooms");
            Room room = new Room(RoomNumber);

            if (!roomManager.SaveRoom(room)) {
                MessageBox.Show("Error: " + ValidationHelper.GetErrorList(room), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RoomId = room.id;
            Type = "default";
        
            for (int i = 1; i <= Row; i++) {
                for(int j = 1; j <= Colum; j++) {
                    Chair chair = new Chair(RoomId, i, j, Price, Type);
                    if (!chairManager.SaveChair(chair)) {
                        MessageBox.Show("Error: " + ValidationHelper.GetErrorList(room), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            
            // Go back to list view
            MovieList listScreen = app.GetScreen<MovieList>("movieList");
            app.ShowScreen(listScreen);
        }

        private void Price_Input_TextChanged(object sender, EventArgs e) {

            try {
                

            }
            catch (FormatException) {
                MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
