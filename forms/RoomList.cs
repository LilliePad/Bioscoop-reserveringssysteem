using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class RoomList : BaseLayout {

        private ListView container;
        private Label Movie_list_text;
        private Button movieCreateButton;

        public RoomList() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "roomList";
        }

  

        public override void OnShow() {
            Program app = Program.GetInstance();
            RoomService roomService = app.GetService<RoomService>("rooms");
            List<Room> rooms = roomService.GetRooms();

            base.OnShow();
            container.Items.Clear();
            
            for (int i = 0; i < rooms.Count; i++) {
                Room room = rooms[i];
                ListViewItem item = new ListViewItem("Zaal " + room.number, i);
                item.Tag = room.id;
                container.Items.Add(item);
            }
        }

        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.movieCreateButton = new System.Windows.Forms.Button();
            this.Movie_list_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(40, 174);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(670, 430);
            this.container.TabIndex = 2;
            this.container.UseCompatibleStateImageBehavior = false;
            this.container.SelectedIndexChanged += new System.EventHandler(this.container_SelectedIndexChanged);
            this.container.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // movieCreateButton
            // 
            this.movieCreateButton.Location = new System.Drawing.Point(40, 638);
            this.movieCreateButton.Name = "movieCreateButton";
            this.movieCreateButton.Size = new System.Drawing.Size(140, 23);
            this.movieCreateButton.TabIndex = 3;
            this.movieCreateButton.Text = "Nieuw";
            this.movieCreateButton.UseVisualStyleBackColor = true;
            this.movieCreateButton.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // Movie_list_text
            // 
            this.Movie_list_text.AutoEllipsis = true;
            this.Movie_list_text.AutoSize = true;
            this.Movie_list_text.BackColor = System.Drawing.SystemColors.Control;
            this.Movie_list_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Movie_list_text.Location = new System.Drawing.Point(32, 103);
            this.Movie_list_text.Name = "Movie_list_text";
            this.Movie_list_text.Size = new System.Drawing.Size(167, 46);
            this.Movie_list_text.TabIndex = 5;
            this.Movie_list_text.Text = "Zaal lijst";
            // 
            // RoomList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.Movie_list_text);
            this.Controls.Add(this.movieCreateButton);
            this.Controls.Add(this.container);
            this.Name = "RoomList";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.Controls.SetChildIndex(this.container, 0);
            this.Controls.SetChildIndex(this.movieCreateButton, 0);
            this.Controls.SetChildIndex(this.Movie_list_text, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MovieList_Load(object sender, System.EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("Zalen", 100);
        }

        private void ButtonNew_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomCreateDesign newScreen = app.GetScreen<RoomCreateDesign>("roomCreate");

            app.ShowScreen(newScreen);
        }

        private void ButtonEdit_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomService roomService = app.GetService<RoomService>("rooms");
            RoomEdit editScreen = app.GetScreen<RoomEdit>("roomEdit");

            // Get the clicked item
            ListViewItem item = container.SelectedItems[0];

            if(item == null) {
                MessageBox.Show("Error: Geen item geselecteerd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Find the movie
            int id = (int) item.Tag;
            Room room = roomService.GetRoomById(id);

            if(room == null) {
                MessageBox.Show("Error: Kon geen film vinden voor dit item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            editScreen.SetRoom(room);
            app.ShowScreen(editScreen);
        }

        private void container_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }

}
