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
    public partial class RoomCreateDesign : BaseLayout {
        private Panel panel1;
        private Label Create_a_movie_text;
        private Label Playtime_text;
        private TextBox Room_input;
        private TextBox Row_input;
        private TextBox Colum_input;
        private Label label6;
        private Label Name_text;
        private Button CreateButton;
        private Label label2;

        private int RoomNumber;
        private int RoomId;
        private int Row;
        private int Colum;
        private double Price;
        private Button Back_button;
        private string Type;

        public RoomCreateDesign() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "roomCreate";
        }


        public override void OnShow() {
            base.OnShow();
            Room_input.Text = "";
            Row_input.Text = "";
            Colum_input.Text = "";
        }

        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.Create_a_movie_text = new System.Windows.Forms.Label();
            this.Playtime_text = new System.Windows.Forms.Label();
            this.Room_input = new System.Windows.Forms.TextBox();
            this.Row_input = new System.Windows.Forms.TextBox();
            this.Colum_input = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Name_text = new System.Windows.Forms.Label();
            this.Back_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Back_button);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CreateButton);
            this.panel1.Controls.Add(this.Create_a_movie_text);
            this.panel1.Controls.Add(this.Playtime_text);
            this.panel1.Controls.Add(this.Room_input);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(10, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 22;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(125, 221);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(90, 23);
            this.CreateButton.TabIndex = 19;
            this.CreateButton.Text = "Aanmaken";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // Create_a_movie_text
            // 
            this.Create_a_movie_text.AutoSize = true;
            this.Create_a_movie_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Create_a_movie_text.Location = new System.Drawing.Point(3, 0);
            this.Create_a_movie_text.Name = "Create_a_movie_text";
            this.Create_a_movie_text.Size = new System.Drawing.Size(371, 58);
            this.Create_a_movie_text.TabIndex = 3;
            this.Create_a_movie_text.Text = "Zaal aanmaken";
            this.Create_a_movie_text.Click += new System.EventHandler(this.Create_a_movie_text_Click);
            // 
            // Playtime_text
            // 
            this.Playtime_text.AutoSize = true;
            this.Playtime_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Playtime_text.Location = new System.Drawing.Point(9, 125);
            this.Playtime_text.Name = "Playtime_text";
            this.Playtime_text.Size = new System.Drawing.Size(47, 20);
            this.Playtime_text.TabIndex = 6;
            this.Playtime_text.Text = "Rijen";
            this.Playtime_text.Click += new System.EventHandler(this.Playtime_text_Click);
            // 
            // Room_input
            // 
            this.Room_input.Location = new System.Drawing.Point(125, 82);
            this.Room_input.Name = "Room_input";
            this.Room_input.Size = new System.Drawing.Size(495, 22);
            this.Room_input.TabIndex = 14;
            this.Room_input.TextChanged += new System.EventHandler(this.Room_input_TextChanged);
            // 
            // Row_input
            // 
            this.Row_input.Location = new System.Drawing.Point(125, 125);
            this.Row_input.Name = "Row_input";
            this.Row_input.Size = new System.Drawing.Size(495, 22);
            this.Row_input.TabIndex = 16;
            this.Row_input.TextChanged += new System.EventHandler(this.Row_input_TextChanged);
            // 
            // Colum_input
            // 
            this.Colum_input.Location = new System.Drawing.Point(125, 171);
            this.Colum_input.Name = "Colum_input";
            this.Colum_input.Size = new System.Drawing.Size(495, 22);
            this.Colum_input.TabIndex = 17;
            this.Colum_input.TextChanged += new System.EventHandler(this.Colum_input_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(10, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Colommen";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Name_text
            // 
            this.Name_text.AutoSize = true;
            this.Name_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name_text.Location = new System.Drawing.Point(10, 82);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(106, 20);
            this.Name_text.TabIndex = 4;
            this.Name_text.Text = "Zaal nummer";
            // 
            // Back_button
            // 
            this.Back_button.Location = new System.Drawing.Point(281, 221);
            this.Back_button.Name = "Back_button";
            this.Back_button.Size = new System.Drawing.Size(90, 23);
            this.Back_button.TabIndex = 23;
            this.Back_button.Text = "Annuleer";
            this.Back_button.UseVisualStyleBackColor = true;
            this.Back_button.Click += new System.EventHandler(this.Back_button_Click);
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

        private void label6_Click(object sender, EventArgs e) {

        }

        private void Colum_input_TextChanged(object sender, EventArgs e) {
            try {
                Colum = int.Parse(Colum_input.Text);

            }
            catch (FormatException) {
                if (Colum_input.Text == "") {
                }
                else {
                    MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Row_input_TextChanged(object sender, EventArgs e) {
            try {
                Row = int.Parse(Row_input.Text);

            }
            catch (FormatException) {
                if (Row_input.Text == "") {
                }
                else {
                    MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Room_input_TextChanged(object sender, EventArgs e) {
            try {
                RoomNumber = int.Parse(Room_input.Text);

            }
            catch (FormatException) {
                if (Room_input.Text == "") {
                }
                else {
                    MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            Price = 7.50;
        
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
            RoomList listScreen = app.GetScreen<RoomList>("roomList");
            app.ShowScreen(listScreen);
        }

        private void Playtime_text_Click(object sender, EventArgs e) {

        }

        private void Back_button_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomList editScreen = app.GetScreen<RoomList>("roomList");
            app.ShowScreen(editScreen);
        }
    }
}
