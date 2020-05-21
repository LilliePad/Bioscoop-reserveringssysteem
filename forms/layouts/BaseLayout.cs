using System.Windows.Forms;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;
using System;

namespace Project.Forms.Layouts {

    public partial class BaseLayout : Form {

        private Panel navBar;

        private Button navLink1;
        private Button navLink2;
        private Button navLink3;
        private Button navLink4;
        private Button navLink5;

        private TextBox navLoginUsername;
        private TextBox navLoginPassword;
        private Button navLoginButton;

        private string usernameValue;
        private string passwordValue;

        public BaseLayout() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.navBar = new System.Windows.Forms.Panel();
            this.navLink1 = new System.Windows.Forms.Button();
            this.navLink2 = new System.Windows.Forms.Button();
            this.navLink3 = new System.Windows.Forms.Button();
            this.navLink4 = new System.Windows.Forms.Button();
            this.navLink5 = new System.Windows.Forms.Button();
            this.navLoginUsername = new System.Windows.Forms.TextBox();
            this.navLoginPassword = new System.Windows.Forms.TextBox();
            this.navLoginButton = new System.Windows.Forms.Button();
            this.navBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBar
            // 
            this.navBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navBar.BackColor = System.Drawing.Color.Black;
            this.navBar.Controls.Add(this.navLink1);
            this.navBar.Controls.Add(this.navLink2);
            this.navBar.Controls.Add(this.navLink3);
            this.navBar.Controls.Add(this.navLink4);
            this.navBar.Controls.Add(this.navLink5);
            this.navBar.Controls.Add(this.navLoginUsername);
            this.navBar.Controls.Add(this.navLoginPassword);
            this.navBar.Controls.Add(this.navLoginButton);
            this.navBar.Location = new System.Drawing.Point(0, 0);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(1261, 100);
            this.navBar.TabIndex = 1;
            // 
            // navLink1
            // 
            this.navLink1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navLink1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navLink1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLink1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLink1.Location = new System.Drawing.Point(40, 55);
            this.navLink1.Name = "navLink1";
            this.navLink1.Size = new System.Drawing.Size(110, 30);
            this.navLink1.TabIndex = 0;
            this.navLink1.UseVisualStyleBackColor = false;
            // 
            // navLink2
            // 
            this.navLink2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navLink2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navLink2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLink2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLink2.Location = new System.Drawing.Point(180, 55);
            this.navLink2.Name = "navLink2";
            this.navLink2.Size = new System.Drawing.Size(110, 30);
            this.navLink2.TabIndex = 1;
            this.navLink2.UseVisualStyleBackColor = false;
            // 
            // navLink3
            // 
            this.navLink3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navLink3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navLink3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLink3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLink3.Location = new System.Drawing.Point(320, 55);
            this.navLink3.Name = "navLink3";
            this.navLink3.Size = new System.Drawing.Size(110, 30);
            this.navLink3.TabIndex = 4;
            this.navLink3.UseVisualStyleBackColor = false;
            // 
            // navLink4
            // 
            this.navLink4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navLink4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navLink4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLink4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLink4.Location = new System.Drawing.Point(460, 55);
            this.navLink4.Name = "navLink4";
            this.navLink4.Size = new System.Drawing.Size(110, 30);
            this.navLink4.TabIndex = 3;
            this.navLink4.UseVisualStyleBackColor = false;
            // 
            // navLink5
            // 
            this.navLink5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navLink5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navLink5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLink5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLink5.Location = new System.Drawing.Point(600, 55);
            this.navLink5.Name = "navLink5";
            this.navLink5.Size = new System.Drawing.Size(110, 30);
            this.navLink5.TabIndex = 2;
            this.navLink5.UseVisualStyleBackColor = false;
            // 
            // navLoginUsername
            // 
            this.navLoginUsername.Location = new System.Drawing.Point(1035, 12);
            this.navLoginUsername.Name = "navLoginUsername";
            this.navLoginUsername.Size = new System.Drawing.Size(100, 29);
            this.navLoginUsername.TabIndex = 7;
            this.navLoginUsername.TextChanged += new System.EventHandler(this.NavLoginUsername_TextChanged);
            // 
            // navLoginPassword
            // 
            this.navLoginPassword.Location = new System.Drawing.Point(1035, 38);
            this.navLoginPassword.Name = "navLoginPassword";
            this.navLoginPassword.PasswordChar = '*';
            this.navLoginPassword.Size = new System.Drawing.Size(100, 29);
            this.navLoginPassword.TabIndex = 8;
            this.navLoginPassword.TextChanged += new System.EventHandler(this.NavLoginPassword_TextChanged);
            // 
            // navLoginButton
            // 
            this.navLoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navLoginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.navLoginButton.BackColor = System.Drawing.Color.White;
            this.navLoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLoginButton.Location = new System.Drawing.Point(1151, 37);
            this.navLoginButton.Name = "navLoginButton";
            this.navLoginButton.Size = new System.Drawing.Size(99, 30);
            this.navLoginButton.TabIndex = 5;
            this.navLoginButton.Text = "Login";
            this.navLoginButton.UseVisualStyleBackColor = false;
            this.navLoginButton.Click += new System.EventHandler(this.NavLoginButton_Click);
            // 
            // BaseLayout
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.navBar);
            this.Name = "BaseLayout";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.navBar.ResumeLayout(false);
            this.navBar.PerformLayout();
            this.ResumeLayout(false);

        }

        private void MovieList_Load(object sender, System.EventArgs e) {

        }

        private void NavLoginUsername_TextChanged(object sender, EventArgs e) {
            usernameValue = navLoginUsername.Text;

        }

        private void NavLoginPassword_TextChanged(object sender, EventArgs e) {
            passwordValue = navLoginPassword.Text;
        }

        private void NavLoginButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");

            // Find user
            User user = userService.GetUserByUsername(usernameValue);

            // Error if user or password invalid
            if (user == null || !user.Authenticate(passwordValue)) {
                MessageBox.Show("Invalid username or password");
                return;
            }

            // Everything ok, login
            userService.SetCurrentUser(user);
            MessageBox.Show("Succesvol ingelogd, welkom " + user.fullName);
        }
    }

}
