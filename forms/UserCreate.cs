using System;
using System.Windows.Forms;
using Project.Forms;
using Project.Forms.Layouts;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.forms {

    public class UserCreate : BaseLayout {

        private Panel content;

        private Label fullNameLabel;
        private TextBox fullNameInput;

        private TextBox usernameInput;
        private Label usernameLabel;

        private Label adminLabel;
        private CheckBox adminInput;

        private Label passwordLabel;
        private TextBox passwordInput;

        private Button saveButton;

        public UserCreate() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "userCreate";
        }

        public override void OnShow() {
            UserService userService = Program.GetInstance().GetService<UserService>("users");
            User user = userService.GetCurrentUser();
            bool allowAdmin = user != null && user.admin;

            base.OnShow();

            // Show admin checkbox if the user is an admin
            adminLabel.Visible = allowAdmin;
            adminInput.Visible = allowAdmin;

            // Reset values
            fullNameInput.Text = "";
            usernameInput.Text = "";
            passwordInput.Text = "";
            adminInput.Checked = false;
        }

        private void InitializeComponent() {
            this.content = new System.Windows.Forms.Panel();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.fullNameInput = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.adminLabel = new System.Windows.Forms.Label();
            this.adminInput = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.content.SuspendLayout();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.Controls.Add(this.passwordInput);
            this.content.Controls.Add(this.passwordLabel);
            this.content.Controls.Add(this.fullNameLabel);
            this.content.Controls.Add(this.fullNameInput);
            this.content.Controls.Add(this.usernameLabel);
            this.content.Controls.Add(this.usernameInput);
            this.content.Controls.Add(this.adminLabel);
            this.content.Controls.Add(this.adminInput);
            this.content.Controls.Add(this.saveButton);
            this.content.Location = new System.Drawing.Point(180, 127);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(715, 443);
            this.content.TabIndex = 2;
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(258, 157);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.PasswordChar = '*';
            this.passwordInput.Size = new System.Drawing.Size(272, 20);
            this.passwordInput.TabIndex = 13;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(137, 160);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(68, 13);
            this.passwordLabel.TabIndex = 12;
            this.passwordLabel.Text = "Wachtwoord";
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.AutoSize = true;
            this.fullNameLabel.Location = new System.Drawing.Point(137, 84);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(79, 13);
            this.fullNameLabel.TabIndex = 9;
            this.fullNameLabel.Text = "Volledige naam";
            // 
            // fullNameInput
            // 
            this.fullNameInput.Location = new System.Drawing.Point(258, 81);
            this.fullNameInput.Name = "fullNameInput";
            this.fullNameInput.Size = new System.Drawing.Size(272, 20);
            this.fullNameInput.TabIndex = 8;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(137, 123);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(84, 13);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Gebruikersnaam";
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(258, 120);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(272, 20);
            this.usernameInput.TabIndex = 0;
            // 
            // adminLabel
            // 
            this.adminLabel.AutoSize = true;
            this.adminLabel.Location = new System.Drawing.Point(137, 198);
            this.adminLabel.Name = "adminLabel";
            this.adminLabel.Size = new System.Drawing.Size(36, 13);
            this.adminLabel.TabIndex = 10;
            this.adminLabel.Text = "Admin";
            // 
            // adminInput
            // 
            this.adminInput.AutoSize = true;
            this.adminInput.Location = new System.Drawing.Point(258, 197);
            this.adminInput.Name = "adminInput";
            this.adminInput.Size = new System.Drawing.Size(15, 14);
            this.adminInput.TabIndex = 11;
            this.adminInput.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(140, 232);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Opslaan";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UserCreate
            // 
            this.ClientSize = new System.Drawing.Size(1916, 1173);
            this.Controls.Add(this.content);
            this.Name = "UserCreate";
            this.Controls.SetChildIndex(this.content, 0);
            this.content.ResumeLayout(false);
            this.content.PerformLayout();
            this.ResumeLayout(false);

        }

        private void SaveButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            User currentUser = userService.GetCurrentUser();

            // Save user
            User user = new User(fullNameInput.Text, usernameInput.Text, passwordInput.Text, adminInput.Checked);

            if(!userService.SaveUser(user)) {
                MessageBox.Show("Error: " + ValidationHelper.GetErrorList(user), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Login if not logged in already
            if(currentUser == null) {
                userService.SetCurrentUser(user);
                currentUser = user;
            }

            // Redirect depending on permission
            UserList userList = app.GetScreen<UserList>("userList");
            ShowList showList = app.GetScreen<ShowList>("showList");

            if (currentUser.admin) {
                app.ShowScreen(userList);
            } else {
                app.ShowScreen(showList);
            }
        }

    }

}
