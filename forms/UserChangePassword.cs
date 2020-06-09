using Project.Forms.Layouts;
using System.Windows.Forms;
using System;
using Project.Models;
using Project.Services;
using Project.Helpers;
using Project.Errors;

namespace Project.Forms {

    public class UserChangePassword : BaseLayout {

        // Frontend
        private Panel panel;

        private Label currentPasswordLabel;
        private TextBox currentPasswordInput;

        private Label newPasswordLabel;
        private TextBox newPasswordInput;
        
        private Button saveButton;
        private Button cancelButton;
        private Label title;

        // Backend
        private User user;

        public UserChangePassword() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "userChangePassword";
        }

        public override void OnShow() {
            UserService userService = Program.GetInstance().GetService<UserService>("users");
            User currentUser = userService.GetCurrentUser();

            base.OnShow();

            if (user.id != currentUser.id && !currentUser.admin) {
                throw new PermissionException("Je kunt alleen je eigen account bewerken");
            }
        }

        private void InitializeComponent() {
            this.panel = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.newPasswordInput = new System.Windows.Forms.TextBox();
            this.currentPasswordLabel = new System.Windows.Forms.Label();
            this.currentPasswordInput = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.saveButton);
            this.panel.Controls.Add(this.newPasswordLabel);
            this.panel.Controls.Add(this.newPasswordInput);
            this.panel.Controls.Add(this.currentPasswordLabel);
            this.panel.Controls.Add(this.currentPasswordInput);
            this.panel.Location = new System.Drawing.Point(42, 106);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(715, 443);
            this.panel.TabIndex = 2;
            // 
            // title
            // 
            this.title.AutoEllipsis = true;
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.Control;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(-8, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(445, 46);
            this.title.TabIndex = 8;
            this.title.Text = "wachtwoord veranderen";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(218, 186);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(44, 186);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(140, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Opslaan";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new System.Drawing.Point(-3, 142);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(98, 13);
            this.newPasswordLabel.TabIndex = 5;
            this.newPasswordLabel.Text = "Nieuw wachtwoord";
            // 
            // newPasswordInput
            // 
            this.newPasswordInput.Location = new System.Drawing.Point(118, 139);
            this.newPasswordInput.Name = "newPasswordInput";
            this.newPasswordInput.PasswordChar = '*';
            this.newPasswordInput.Size = new System.Drawing.Size(272, 20);
            this.newPasswordInput.TabIndex = 4;
            // 
            // currentPasswordLabel
            // 
            this.currentPasswordLabel.AutoSize = true;
            this.currentPasswordLabel.Location = new System.Drawing.Point(-3, 99);
            this.currentPasswordLabel.Name = "currentPasswordLabel";
            this.currentPasswordLabel.Size = new System.Drawing.Size(98, 13);
            this.currentPasswordLabel.TabIndex = 1;
            this.currentPasswordLabel.Text = "Huidig wachtwoord";
            // 
            // currentPasswordInput
            // 
            this.currentPasswordInput.Location = new System.Drawing.Point(118, 96);
            this.currentPasswordInput.Name = "currentPasswordInput";
            this.currentPasswordInput.PasswordChar = '*';
            this.currentPasswordInput.Size = new System.Drawing.Size(272, 20);
            this.currentPasswordInput.TabIndex = 0;
            // 
            // UserChangePassword
            // 
            this.ClientSize = new System.Drawing.Size(1217, 599);
            this.Controls.Add(this.panel);
            this.Name = "UserChangePassword";
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        public void SetUser(User user) {
            this.user = user;
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            User currentUser = userService.GetCurrentUser();

            // Get values
            string currentPassword = currentPasswordInput.Text;
            string newPassword = newPasswordInput.Text;

            if (!currentUser.Authenticate(currentPassword)) {
                GuiHelper.ShowError("Ongeldig wachtwoord");
                return;
            }
            
            // Update and save user
            user.SetPassword(newPassword);

            if (userService.SaveUser(user)) {
                UserEdit userEdit = app.GetScreen<UserEdit>("userEdit");

                userEdit.SetUser(user);
                app.ShowScreen(userEdit);

                currentPasswordInput.Text = "";
                newPasswordInput.Text = "";

                GuiHelper.ShowInfo("Wachtwoord succesvol aangepast");
            } else {
                GuiHelper.ShowError("Kon het wachtwoord niet aanpassen");
            } 
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserEdit userEdit = app.GetScreen<UserEdit>("userEdit");
            userEdit.SetUser(user);
            app.ShowScreen(userEdit);
        }

    }

}
