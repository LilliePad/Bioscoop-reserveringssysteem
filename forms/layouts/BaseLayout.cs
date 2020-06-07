using System;
using System.Windows.Forms;
using Project.Base;
using Project.Models;
using Project.Services;
using System.Runtime.InteropServices;
using Project.Forms.Components;

namespace Project.Forms.Layouts {

    public class BaseLayout : BaseScreen {

        private Panel navBar;

        private RoundedButton navLink1;
        private RoundedButton navLink2;
        private RoundedButton navLink3;
        private RoundedButton navLink4;
        private RoundedButton navLink5;

        private TextBox navLoginUsername;
        private TextBox navLoginPassword;
        private Button navLoginButton;
        private Button navRegisterButton;

        private Button navAccountButton;
        private Button navLogoutButton;
        private Label navAccountName;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        
        public BaseLayout() {
            InitializeComponent();
        }

        public override void OnShow() {
            UpdateUserControls();
        }

        private void InitializeComponent() {
            this.navBar = new System.Windows.Forms.Panel();
            this.navAccountName = new System.Windows.Forms.Label();
            this.navLink1 = new Project.Forms.Components.RoundedButton();
            this.navLink2 = new Project.Forms.Components.RoundedButton();
            this.navLink3 = new Project.Forms.Components.RoundedButton();
            this.navLink4 = new Project.Forms.Components.RoundedButton();
            this.navLink5 = new Project.Forms.Components.RoundedButton();
            this.navLoginUsername = new System.Windows.Forms.TextBox();
            this.navLoginPassword = new System.Windows.Forms.TextBox();
            this.navLoginButton = new System.Windows.Forms.Button();
            this.navRegisterButton = new System.Windows.Forms.Button();
            this.navAccountButton = new System.Windows.Forms.Button();
            this.navLogoutButton = new System.Windows.Forms.Button();
            this.navBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBar
            // 
            this.navBar.BackColor = System.Drawing.Color.Black;
            this.navBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navBar.Controls.Add(this.navAccountName);
            this.navBar.Controls.Add(this.navLink1);
            this.navBar.Controls.Add(this.navLink2);
            this.navBar.Controls.Add(this.navLink3);
            this.navBar.Controls.Add(this.navLink4);
            this.navBar.Controls.Add(this.navLink5);
            this.navBar.Controls.Add(this.navLoginUsername);
            this.navBar.Controls.Add(this.navLoginPassword);
            this.navBar.Controls.Add(this.navLoginButton);
            this.navBar.Controls.Add(this.navRegisterButton);
            this.navBar.Controls.Add(this.navAccountButton);
            this.navBar.Controls.Add(this.navLogoutButton);
            this.navBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.navBar.Location = new System.Drawing.Point(0, 0);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(1902, 100);
            this.navBar.TabIndex = 1;
            // 
            // navAccountName
            // 
            this.navAccountName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navAccountName.AutoSize = true;
            this.navAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.navAccountName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.navAccountName.Location = new System.Drawing.Point(1663, 16);
            this.navAccountName.Name = "navAccountName";
            this.navAccountName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.navAccountName.Size = new System.Drawing.Size(111, 17);
            this.navAccountName.TabIndex = 14;
            this.navAccountName.Text = "<accountName>";
            this.navAccountName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // navLink1
            // 
            this.navLink1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navLink1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navLink1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLink1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLink1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navLink1.Location = new System.Drawing.Point(40, 55);
            this.navLink1.Name = "navLink1";
            this.navLink1.Size = new System.Drawing.Size(110, 30);
            this.navLink1.TabIndex = 0;
            this.navLink1.Text = "Movie";
            this.navLink1.UseVisualStyleBackColor = false;
            this.navLink1.Click += new System.EventHandler(this.navLink1_Click);
            // 
            // navLink2
            // 
            this.navLink2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navLink2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navLink2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLink2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLink2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navLink2.Location = new System.Drawing.Point(180, 55);
            this.navLink2.Name = "navLink2";
            this.navLink2.Size = new System.Drawing.Size(110, 30);
            this.navLink2.TabIndex = 1;
            this.navLink2.Text = "Room";
            this.navLink2.UseVisualStyleBackColor = false;
            this.navLink2.Click += new System.EventHandler(this.navLink2_Click);
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
            this.navLink3.Text = "Gebruikers";
            this.navLink3.UseVisualStyleBackColor = false;
            this.navLink3.Click += new System.EventHandler(this.navLink3_Click);
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
            this.navLink5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.navLink5.FlatAppearance.BorderSize = 0;
            this.navLink5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLink5.Location = new System.Drawing.Point(600, 55);
            this.navLink5.Name = "navLink5";
            this.navLink5.Size = new System.Drawing.Size(110, 30);
            this.navLink5.TabIndex = 2;
            this.navLink5.Text = "show";
            this.navLink5.UseVisualStyleBackColor = false;
            this.navLink5.Click += new System.EventHandler(this.navLink5_Click);
            // 
            // navLoginUsername
            // 
            this.navLoginUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navLoginUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.navLoginUsername.Location = new System.Drawing.Point(1642, 16);
            this.navLoginUsername.Name = "navLoginUsername";
            this.navLoginUsername.Size = new System.Drawing.Size(132, 23);
            this.navLoginUsername.TabIndex = 7;
            this.navLoginUsername.Text = "Gebruikersnaam";
            this.navLoginUsername.Enter += new System.EventHandler(this.LoginUsernameRemoveText);
            this.navLoginUsername.Leave += new System.EventHandler(this.LoginUsernameAddText);
            // 
            // navLoginPassword
            // 
            this.navLoginPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.navLoginPassword.Location = new System.Drawing.Point(1642, 58);
            this.navLoginPassword.Name = "navLoginPassword";
            this.navLoginPassword.Size = new System.Drawing.Size(132, 23);
            this.navLoginPassword.TabIndex = 8;
            this.navLoginPassword.Text = "Wachtwoord";
            this.navLoginPassword.Enter += new System.EventHandler(this.LoginPasswordRemoveText);
            this.navLoginPassword.Leave += new System.EventHandler(this.LoginPasswordAddText);
            // 
            // navLoginButton
            // 
            this.navLoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navLoginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.navLoginButton.BackColor = System.Drawing.Color.White;
            this.navLoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.navLoginButton.Location = new System.Drawing.Point(1783, 16);
            this.navLoginButton.Name = "navLoginButton";
            this.navLoginButton.Padding = new System.Windows.Forms.Padding(0, 2, 2, 0);
            this.navLoginButton.Size = new System.Drawing.Size(99, 30);
            this.navLoginButton.TabIndex = 5;
            this.navLoginButton.Text = "Inloggen";
            this.navLoginButton.UseVisualStyleBackColor = false;
            this.navLoginButton.Click += new System.EventHandler(this.NavLoginButton_Click);
            // 
            // navRegisterButton
            // 
            this.navRegisterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navRegisterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.navRegisterButton.BackColor = System.Drawing.Color.White;
            this.navRegisterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navRegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navRegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.navRegisterButton.Location = new System.Drawing.Point(1783, 51);
            this.navRegisterButton.Name = "navRegisterButton";
            this.navRegisterButton.Padding = new System.Windows.Forms.Padding(0, 2, 2, 0);
            this.navRegisterButton.Size = new System.Drawing.Size(99, 30);
            this.navRegisterButton.TabIndex = 10;
            this.navRegisterButton.Text = "Registreren";
            this.navRegisterButton.UseVisualStyleBackColor = false;
            this.navRegisterButton.Click += new System.EventHandler(this.NavRegisterButton_Click);
            // 
            // navAccountButton
            // 
            this.navAccountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navAccountButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.navAccountButton.BackColor = System.Drawing.Color.White;
            this.navAccountButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.navAccountButton.Location = new System.Drawing.Point(1783, 16);
            this.navAccountButton.Name = "navAccountButton";
            this.navAccountButton.Padding = new System.Windows.Forms.Padding(0, 2, 2, 0);
            this.navAccountButton.Size = new System.Drawing.Size(99, 30);
            this.navAccountButton.TabIndex = 13;
            this.navAccountButton.Text = "Account";
            this.navAccountButton.UseVisualStyleBackColor = false;
            this.navAccountButton.Click += new System.EventHandler(this.AccountButton_Click);
            // 
            // navLogoutButton
            // 
            this.navLogoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navLogoutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.navLogoutButton.BackColor = System.Drawing.Color.White;
            this.navLogoutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLogoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.navLogoutButton.Location = new System.Drawing.Point(1783, 51);
            this.navLogoutButton.Name = "navLogoutButton";
            this.navLogoutButton.Padding = new System.Windows.Forms.Padding(0, 2, 2, 0);
            this.navLogoutButton.Size = new System.Drawing.Size(99, 30);
            this.navLogoutButton.TabIndex = 12;
            this.navLogoutButton.Text = "Uitloggen";
            this.navLogoutButton.UseVisualStyleBackColor = false;
            this.navLogoutButton.Click += new System.EventHandler(this.NavLogoutButton_Click);
            // 
            // BaseLayout
            // 
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.navBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BaseLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.navBar.ResumeLayout(false);
            this.navBar.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoginUsernameRemoveText(object sender, EventArgs e) {
            if (navLoginUsername.Text == "Gebruikersnaam")
                navLoginUsername.Text = "";
        }

        public void LoginUsernameAddText(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(navLoginUsername.Text))
                navLoginUsername.Text = "Gebruikersnaam";
        }

        public void LoginPasswordRemoveText(object sender, EventArgs e) {
            if (navLoginPassword.Text == "Wachtwoord") {
                navLoginPassword.Text = "";
                navLoginPassword.PasswordChar = '*';
            }
        }

        public void LoginPasswordAddText(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(navLoginPassword.Text)) {
                navLoginPassword.Text = "Wachtwoord";
                navLoginPassword.PasswordChar = '\0';
            }
        }

        private void NavLoginButton_Click(object sender, EventArgs e) {
            UserService userService = Program.GetInstance().GetService<UserService>("users");

            // Find user
            User user = userService.GetUserByUsername(navLoginUsername.Text);

            // Error if user or password invalid
            if (user == null || !user.Authenticate(navLoginPassword.Text)) {
                MessageBox.Show("Invalid username or password");
                return;
            }

            // Clear fields
            navLoginUsername.Text = "Gebruikersnaam";
            navLoginPassword.Text = "Wachtwoord";
            navLoginPassword.PasswordChar = '\0';

            // Everything ok, login
            userService.SetCurrentUser(user);
            UpdateUserControls();
            OnLogin(user);
        }

        private void NavRegisterButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserCreate userCreate = app.GetScreen<UserCreate>("userCreate");
            app.ShowScreen(userCreate);
        }

        private void AccountButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            UserEdit userEdit = app.GetScreen<UserEdit>("userEdit");

            userEdit.SetUser(userService.GetCurrentUser());
            app.ShowScreen(userEdit);
        }

        private void NavLogoutButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            User user = userService.GetCurrentUser();

            // Logout
            userService.SetCurrentUser(null);
            UpdateUserControls();
            OnLogout(user);

            // Check whether they need to be moved
            BaseScreen currentScreen = app.GetCurrentScreen();

            if (currentScreen.RequireLogin() || currentScreen.RequireAdmin()) {
                app.ShowScreen(app.GetDefaultScreen());
            }
        }

        protected void OnLogin(User user) { }
        protected void OnLogout(User user) { }

        private void UpdateUserControls() {
            UserService userService = Program.GetInstance().GetService<UserService>("users");
            User user = userService.GetCurrentUser();
            bool loggedIn = user != null;

            // Update login visibillity
            navLoginUsername.Visible = !loggedIn;
            navLoginPassword.Visible = !loggedIn;
            navLoginButton.Visible = !loggedIn;
            navRegisterButton.Visible = !loggedIn;

            // Update account visibillity
            navAccountName.Visible = loggedIn;
            navAccountButton.Visible = loggedIn;
            navLogoutButton.Visible = loggedIn;

            if(loggedIn) {
                navAccountName.Text = user.fullName;
            }
        }

        private void navLink1_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieList newScreen = app.GetScreen<MovieList>("movieList");
            app.ShowScreen(newScreen);
        }

        private void navLink2_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomList newScreen = app.GetScreen<RoomList>("roomList");
            app.ShowScreen(newScreen);
        }

        private void navLink3_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserList userList = app.GetScreen<UserList>("userList");
            app.ShowScreen(userList);
        }

        private void navLink4_Click(object sender, EventArgs e) {

        }

        private void navLink5_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ShowList newScreen = app.GetScreen<ShowList>("showList");
            app.ShowScreen(newScreen);
        }

    }

}




        
            
       
    
