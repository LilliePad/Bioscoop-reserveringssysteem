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
        private Label title;
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
                ListViewItem item = new ListViewItem(user.fullName + " - " + user.username + " - " + (user.admin ? "Ja" : "Nee"), i);

                item.Tag = user.id;
                container.Items.Add(item);
            }
        }

        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.userCreateButton = new System.Windows.Forms.Button();
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
            // userCreateButton
            // 
            this.userCreateButton.Location = new System.Drawing.Point(40, 638);
            this.userCreateButton.Name = "userCreateButton";
            this.userCreateButton.Size = new System.Drawing.Size(140, 23);
            this.userCreateButton.TabIndex = 4;
            this.userCreateButton.Text = "Nieuw";
            this.userCreateButton.UseVisualStyleBackColor = true;
            this.userCreateButton.Click += new System.EventHandler(this.UserCreateButton_Click);
            // 
            // title
            // 
            this.title.AutoEllipsis = true;
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.Control;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(34, 112);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(237, 46);
            this.title.TabIndex = 6;
            this.title.Text = "Account lijst";
            // 
            // UserList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.title);
            this.Controls.Add(this.userCreateButton);
            this.Controls.Add(this.container);
            this.Name = "UserList";
            this.Load += new System.EventHandler(this.UserList_Load);
            this.Controls.SetChildIndex(this.container, 0);
            this.Controls.SetChildIndex(this.userCreateButton, 0);
            this.Controls.SetChildIndex(this.title, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void UserList_Load(object sender, System.EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("Gebruikers (volledige naam - gebruikersnaam - admin)", 600);
        }

        private void ListItem_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");

            // Get the clicked item
            ListViewItem item = container.SelectedItems[0];

            if (item == null) {
                GuiHelper.ShowError("Geen item geselecteerd");
                return;
            }

            // Find the movie
            int id = (int)item.Tag;
            User user = userService.GetUserById(id);

            if (user == null) {
                GuiHelper.ShowError("Kon geen gebruiker vinden voor dit item");
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
