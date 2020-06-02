using Project.Forms.Layouts;
using Project.Helpers;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.forms {
    public partial class UserChangePassword : BaseLayout {
        private Panel panel1;
        private Label Create_a_movie_text;
        private Label Discription_text;
        private Label Playtime_text;
        private Button Movie_create_button;
        private TextBox NameMovie_input;
        private TextBox Discription_input;
        private TextBox Duration_input;
        private TextBox Genre_input;
        private Label label6;
        private Panel panel2;
        private TextBox Old_password_input;
        private Label New_password_label;
        private TextBox New_password_input;
        private Label New_password_again_label;
        private TextBox New_password_again_input;
        private Label Old_password_label;
        private Button Confirm;
        private Label Name_text;
        private string oldPassword;
        private string newPassword1;
        private string newPassword2;

        public UserChangePassword() {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.panel2 = new System.Windows.Forms.Panel();
            this.Confirm = new System.Windows.Forms.Button();
            this.New_password_label = new System.Windows.Forms.Label();
            this.New_password_input = new System.Windows.Forms.TextBox();
            this.New_password_again_label = new System.Windows.Forms.Label();
            this.New_password_again_input = new System.Windows.Forms.TextBox();
            this.Old_password_label = new System.Windows.Forms.Label();
            this.Old_password_input = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Confirm);
            this.panel2.Controls.Add(this.New_password_label);
            this.panel2.Controls.Add(this.New_password_input);
            this.panel2.Controls.Add(this.New_password_again_label);
            this.panel2.Controls.Add(this.New_password_again_input);
            this.panel2.Controls.Add(this.Old_password_label);
            this.panel2.Controls.Add(this.Old_password_input);
            this.panel2.Location = new System.Drawing.Point(180, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 443);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(315, 227);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 6;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // New_password_label
            // 
            this.New_password_label.AutoSize = true;
            this.New_password_label.Location = new System.Drawing.Point(137, 101);
            this.New_password_label.Name = "New_password_label";
            this.New_password_label.Size = new System.Drawing.Size(77, 13);
            this.New_password_label.TabIndex = 5;
            this.New_password_label.Text = "New password";
            this.New_password_label.Click += new System.EventHandler(this.label3_Click);
            // 
            // New_password_input
            // 
            this.New_password_input.Location = new System.Drawing.Point(258, 98);
            this.New_password_input.Name = "New_password_input";
            this.New_password_input.PasswordChar = '*';
            this.New_password_input.Size = new System.Drawing.Size(272, 20);
            this.New_password_input.TabIndex = 4;
            this.New_password_input.TextChanged += new System.EventHandler(this.New_password_input_TextChanged);
            // 
            // New_password_again_label
            // 
            this.New_password_again_label.AutoSize = true;
            this.New_password_again_label.Location = new System.Drawing.Point(137, 140);
            this.New_password_again_label.Name = "New_password_again_label";
            this.New_password_again_label.Size = new System.Drawing.Size(106, 13);
            this.New_password_again_label.TabIndex = 3;
            this.New_password_again_label.Text = "New password again";
            this.New_password_again_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // New_password_again_input
            // 
            this.New_password_again_input.Location = new System.Drawing.Point(258, 137);
            this.New_password_again_input.Name = "New_password_again_input";
            this.New_password_again_input.PasswordChar = '*';
            this.New_password_again_input.Size = new System.Drawing.Size(272, 20);
            this.New_password_again_input.TabIndex = 2;
            this.New_password_again_input.TextChanged += new System.EventHandler(this.New_password_again_input_TextChanged);
            // 
            // Old_password_label
            // 
            this.Old_password_label.AutoSize = true;
            this.Old_password_label.Location = new System.Drawing.Point(137, 58);
            this.Old_password_label.Name = "Old_password_label";
            this.Old_password_label.Size = new System.Drawing.Size(71, 13);
            this.Old_password_label.TabIndex = 1;
            this.Old_password_label.Text = "Old password";
            // 
            // Old_password_input
            // 
            this.Old_password_input.Location = new System.Drawing.Point(258, 55);
            this.Old_password_input.Name = "Old_password_input";
            this.Old_password_input.PasswordChar = '*';
            this.Old_password_input.Size = new System.Drawing.Size(272, 20);
            this.Old_password_input.TabIndex = 0;
            this.Old_password_input.TextChanged += new System.EventHandler(this.Old_password_input_TextChanged);
            // 
            // UserChangePassword
            // 
            this.ClientSize = new System.Drawing.Size(1217, 599);
            this.Controls.Add(this.panel2);
            this.Name = "UserChangePassword";
            this.Load += new System.EventHandler(this.UserChangePassword_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        public override string GetHandle() {
            return "userChangePassword";
        }

        private void UserChangePassword_Load(object sender, EventArgs e) {

        }

        private void Create_a_movie_text_Click(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void panel2_Paint(object sender, PaintEventArgs e) {

        }

        private void Old_password_input_TextChanged(object sender, EventArgs e) {
            oldPassword = Old_password_input.Text;
        }

        private void Confirm_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            User currentUser = userService.GetCurrentUser();
            User user = currentUser;
            
            if (user.Authenticate(oldPassword) && (newPassword1 != newPassword2)) {
                MessageBox.Show("Een van de wachtwoorden komt niet overeen");
            }
            
            if (user.Authenticate(oldPassword) && newPassword1 == newPassword2) {                   
                user.password = EncryptionHelper.CreateHash(newPassword1);

               if (userService.SaveUser(user)) {
                    MessageBox.Show("Wachtwoord succesvol aangepast");
                }
               else {
                    MessageBox.Show("Kon het wachtwoord niet aanpassen");
                } 
                
            }

        }

        private void New_password_input_TextChanged(object sender, EventArgs e) {
            newPassword1 = New_password_input.Text;
        }

        private void New_password_again_input_TextChanged(object sender, EventArgs e) {
            newPassword2 = New_password_again_input.Text;
        }
    }
}
