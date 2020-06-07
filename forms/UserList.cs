using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class UserList : BaseLayout {

        private Button userCreateButton;
        private ListView container;

        public UserList() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "userList";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void OnShow() {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            List<User> users = userService.GetUsers();

            base.OnShow();

            // Enforce permissions
            RequireAdmin();

            container.Items.Clear();

            for (int i = 0; i < users.Count; i++) {
                User user = users[i];
                ListViewItem item = new ListViewItem(user.id + " - " + user.username, i);

                item.Tag = user.id;
                container.Items.Add(item);
            }
        }

        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.userCreateButton = new System.Windows.Forms.Button();
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
            this.container.Click += new System.EventHandler(this.ListItem_Click);
            // 
            // userCreateButton
            // 
            this.userCreateButton.Location = new System.Drawing.Point(40, 601);
            this.userCreateButton.Name = "userCreateButton";
            this.userCreateButton.Size = new System.Drawing.Size(110, 51);
            this.userCreateButton.TabIndex = 4;
            this.userCreateButton.Text = "Nieuw";
            this.userCreateButton.UseVisualStyleBackColor = true;
            this.userCreateButton.Click += new System.EventHandler(this.UserCreateButton_Click);
            // 
            // UserList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.userCreateButton);
            this.Controls.Add(this.container);
            this.Name = "UserList";
            this.Load += new System.EventHandler(this.UserList_Load);
            this.Controls.SetChildIndex(this.container, 0);
            this.Controls.SetChildIndex(this.userCreateButton, 0);
            this.ResumeLayout(false);

        }

        private void UserList_Load(object sender, System.EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("Gebruikers", 250);
        }

        private void ListItem_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");

            // Get the clicked item
            ListViewItem item = container.SelectedItems[0];

            if (item == null) {
                GuiHelper.ShowError("Error: Geen item geselecteerd");
                return;
            }

            // Find the movie
            int id = (int)item.Tag;
            User user = userService.GetUserById(id);

            if (user == null) {
                GuiHelper.ShowError("Error: Kon geen gebruiker vinden voor dit item");
                return;
            }

            // Show screen
            UserEdit editScreen = app.GetScreen<UserEdit>("userEdit");

            editScreen.SetUser(user);
            app.ShowScreen(editScreen);
        }

        private void UserCreateButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserCreate userCreate = app.GetScreen<UserCreate>("userCreate");
            app.ShowScreen(userCreate);
        }

    }

}
