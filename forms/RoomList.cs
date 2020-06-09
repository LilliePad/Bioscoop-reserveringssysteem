using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class RoomList : BaseLayout {

        // Frontend
        private Label title;

        private ListView container;
        
        private Button newButton;

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
            this.newButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
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
            this.container.Click += new System.EventHandler(this.ListItem_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(40, 638);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(140, 23);
            this.newButton.TabIndex = 3;
            this.newButton.Text = "Nieuw";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // title
            // 
            this.title.AutoEllipsis = true;
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.Control;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(32, 103);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(167, 46);
            this.title.TabIndex = 5;
            this.title.Text = "Zaal lijst";
            // 
            // RoomList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.title);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.container);
            this.Name = "RoomList";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.Controls.SetChildIndex(this.container, 0);
            this.Controls.SetChildIndex(this.newButton, 0);
            this.Controls.SetChildIndex(this.title, 0);
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

        private void ListItem_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomService roomService = app.GetService<RoomService>("rooms");
            RoomEdit editScreen = app.GetScreen<RoomEdit>("roomEdit");

            // Get the clicked item
            ListViewItem item = container.SelectedItems[0];

            if(item == null) {
                GuiHelper.ShowError("Error: Geen item geselecteerd");
                return;
            }

            // Find the movie
            int id = (int) item.Tag;
            Room room = roomService.GetRoomById(id);

            if(room == null) {
                GuiHelper.ShowError("Error: Kon geen zaal vinden voor dit item");
                return;
            }

            editScreen.SetRoom(room);
            app.ShowScreen(editScreen);
        }

    }

}
