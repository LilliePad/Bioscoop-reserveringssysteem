using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class UserList : BaseLayout {

        private ListView container;

        public UserList() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "userList";
        }


        public override void OnShow() {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            List<User> users = userService.GetUsers();

            base.OnShow();

            container.Items.Clear();

            for (int i = 0; i < users.Count; i++) {
                User user = users[i];
                ListViewItem item = new ListViewItem(user.username, i);
                ListViewItem itemid = new ListViewItem(user.id + "", i);
                item.Tag = user.username;
                itemid.Tag = user.id;
                container.Items.Add(item);
                item.SubItems.Add(user.id + "");
            }

        }
        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(40, 129);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(670, 452);
            this.container.TabIndex = 2;
            this.container.UseCompatibleStateImageBehavior = false;
            this.container.SelectedIndexChanged += new System.EventHandler(this.container_SelectedIndexChanged);
            // 
            // UserList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.container);
            this.Name = "UserList";
            this.Load += new System.EventHandler(this.UserList_Load);
            this.Controls.SetChildIndex(this.container, 0);
            this.ResumeLayout(false);

        }
        // Collums

        private void UserList_Load(object sender, System.EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("users", 100);
            container.Columns.Add("ID", 100);
        }

        private void ButtonNew_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomCreateDesign newScreen = app.GetScreen<RoomCreateDesign>("roomCreate");

            app.ShowScreen(newScreen);
        }

     

        private void container_SelectedIndexChanged(object sender, EventArgs e) {
            
        }
    }

}
