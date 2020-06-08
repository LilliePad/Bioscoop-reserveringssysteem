using Project.Forms.Layouts;
using System.Windows.Forms;
using System;
using Project.Base;
using Project.Models;
using Project.Services;
using Project.Helpers;

namespace Project.Forms {

    public class ChairEdit : BaseLayout {
        private Panel panel1;
        private Button Chair_edit_Button;
        private Button Delete_chair_button;

        private Label Chair_edit_text;
        private Label Row_text;
        private Label Colum_text;

        private Room room;
        private int row;
        private Button Back_button;
        private int colum;

        

        public ChairEdit() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "chairEdit";
        }

        public void SetRoom(Room room) {
            this.room = room;
        }

        public void SetRow(int row) {
            this.row = row;

        }

        public void SetColum(int colum) {
            this.colum = colum;

        }

        public override void OnShow() {
            base.OnShow();
            this.Colum_text.Text = "Collom  " + colum;
            this.Row_text.Text = "Row  " + row;
        }
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Back_button = new System.Windows.Forms.Button();
            this.Colum_text = new System.Windows.Forms.Label();
            this.Row_text = new System.Windows.Forms.Label();
            this.Delete_chair_button = new System.Windows.Forms.Button();
            this.Chair_edit_text = new System.Windows.Forms.Label();
            this.Chair_edit_Button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Back_button);
            this.panel1.Controls.Add(this.Colum_text);
            this.panel1.Controls.Add(this.Row_text);
            this.panel1.Controls.Add(this.Delete_chair_button);
            this.panel1.Controls.Add(this.Chair_edit_text);
            this.panel1.Controls.Add(this.Chair_edit_Button);
            this.panel1.Location = new System.Drawing.Point(40, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 534);
            this.panel1.TabIndex = 20;
            // 
            // Back_button
            // 
            this.Back_button.Location = new System.Drawing.Point(318, 171);
            this.Back_button.Name = "Back_button";
            this.Back_button.Size = new System.Drawing.Size(140, 23);
            this.Back_button.TabIndex = 22;
            this.Back_button.Text = "Annuleren";
            this.Back_button.UseVisualStyleBackColor = true;
            this.Back_button.Click += new System.EventHandler(this.Back_button_Click);
            // 
            // Colum_text
            // 
            this.Colum_text.AutoSize = true;
            this.Colum_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Colum_text.Location = new System.Drawing.Point(9, 126);
            this.Colum_text.Name = "Colum_text";
            this.Colum_text.Size = new System.Drawing.Size(0, 17);
            this.Colum_text.TabIndex = 21;
            this.Colum_text.Click += new System.EventHandler(this.Colum_Click);
            // 
            // Row_text
            // 
            this.Row_text.AutoSize = true;
            this.Row_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Row_text.Location = new System.Drawing.Point(9, 94);
            this.Row_text.Name = "Row_text";
            this.Row_text.Size = new System.Drawing.Size(0, 17);
            this.Row_text.TabIndex = 20;
            this.Row_text.Click += new System.EventHandler(this.Row_Click);
            // 
            // Delete_chair_button
            // 
            this.Delete_chair_button.Location = new System.Drawing.Point(168, 171);
            this.Delete_chair_button.Name = "Delete_chair_button";
            this.Delete_chair_button.Size = new System.Drawing.Size(140, 23);
            this.Delete_chair_button.TabIndex = 19;
            this.Delete_chair_button.Text = "stoel verwijderen";
            this.Delete_chair_button.UseVisualStyleBackColor = true;
            this.Delete_chair_button.Click += new System.EventHandler(this.Chair_delete_button_Click);
            // 
            // Chair_edit_text
            // 
            this.Chair_edit_text.AutoEllipsis = true;
            this.Chair_edit_text.AutoSize = true;
            this.Chair_edit_text.BackColor = System.Drawing.SystemColors.Control;
            this.Chair_edit_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Chair_edit_text.Location = new System.Drawing.Point(3, 0);
            this.Chair_edit_text.Name = "Chair_edit_text";
            this.Chair_edit_text.Size = new System.Drawing.Size(300, 46);
            this.Chair_edit_text.TabIndex = 3;
            this.Chair_edit_text.Text = "Stoel Bewerken";
            // 
            // Chair_edit_Button
            // 
            this.Chair_edit_Button.Location = new System.Drawing.Point(13, 171);
            this.Chair_edit_Button.Name = "Chair_edit_Button";
            this.Chair_edit_Button.Size = new System.Drawing.Size(140, 23);
            this.Chair_edit_Button.TabIndex = 12;
            this.Chair_edit_Button.Text = "Stoel aanmaken";
            this.Chair_edit_Button.UseVisualStyleBackColor = true;
            this.Chair_edit_Button.Click += new System.EventHandler(this.Chair_edit_button_Click);
            // 
            // ChairEdit
            // 
            this.ClientSize = new System.Drawing.Size(1260, 673);
            this.Controls.Add(this.panel1);
            this.Name = "ChairEdit";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

      
        private void Chair_edit_button_Click(object sender, EventArgs args) {
            Program app = Program.GetInstance();
            ChairService chairManager = app.GetService<ChairService>("chairs");

            Chair chair = new Chair(room.id, row, colum, 7.50, "default");
            chairManager.SaveChair(chair);
            RoomEdit newScreen = app.GetScreen<RoomEdit>("roomEdit");
            app.ShowScreen(newScreen);

        }

        private void Colum_Click(object sender, EventArgs e) {

        }

        private void Row_Click(object sender, EventArgs args) {

        }

        private void Chair_delete_button_Click(object sender, EventArgs args) {
            Program app = Program.GetInstance();
            ChairService chairManager = app.GetService<ChairService>("chairs");
            Chair chair = chairManager.GetChairByRoomAndPosition(room, row, colum);
            try {
                chairManager.DeleteChair(chair);
            }
            catch {
                MessageBox.Show("Error: kon stoel niet verwijderen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            RoomEdit newScreen = app.GetScreen<RoomEdit>("roomEdit");
            app.ShowScreen(newScreen);
        }

        private void Back_button_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomEdit newScreen = app.GetScreen<RoomEdit>("roomEdit");
            app.ShowScreen(newScreen);
        }
    }

}