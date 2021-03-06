﻿using System;
using System.Windows.Forms;
using Project.Base;
using Project.Models;
using Project.Services;
using Project.Forms.Components;
using Project.Helpers;

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
        private RoundedButton userReservationButton;
        private RoundedButton userShowButton;
        private Label navAccountName;
        
        public BaseLayout() {
            InitializeComponent();
        }

        public override void OnShow() {
            UpdateUserControls();
        }

        private void InitializeComponent() {
            this.navBar = new System.Windows.Forms.Panel();
            this.userReservationButton = new Project.Forms.Components.RoundedButton();
            this.userShowButton = new Project.Forms.Components.RoundedButton();
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
            this.navBar.Controls.Add(this.userReservationButton);
            this.navBar.Controls.Add(this.userShowButton);
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
            this.navBar.Size = new System.Drawing.Size(1684, 100);
            this.navBar.TabIndex = 1;
            // 
            // userReservationButton
            // 
            this.userReservationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userReservationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.userReservationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userReservationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userReservationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userReservationButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userReservationButton.Location = new System.Drawing.Point(316, 58);
            this.userReservationButton.Name = "userReservationButton";
            this.userReservationButton.Size = new System.Drawing.Size(249, 30);
            this.userReservationButton.TabIndex = 16;
            this.userReservationButton.Text = "Mijn reserveringen";
            this.userReservationButton.UseVisualStyleBackColor = false;
            this.userReservationButton.Click += new System.EventHandler(this.UserReservationButton_Click);
            // 
            // userShowButton
            // 
            this.userShowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userShowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.userShowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userShowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userShowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userShowButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userShowButton.Location = new System.Drawing.Point(42, 58);
            this.userShowButton.Name = "userShowButton";
            this.userShowButton.Size = new System.Drawing.Size(246, 30);
            this.userShowButton.TabIndex = 15;
            this.userShowButton.Text = "Bekijk films";
            this.userShowButton.UseVisualStyleBackColor = false;
            this.userShowButton.Click += new System.EventHandler(this.UserShowButton_Click);
            // 
            // navAccountName
            // 
            this.navAccountName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navAccountName.AutoSize = true;
            this.navAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.navAccountName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.navAccountName.Location = new System.Drawing.Point(1445, 16);
            this.navAccountName.Name = "navAccountName";
            this.navAccountName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.navAccountName.Size = new System.Drawing.Size(132, 20);
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
            this.navLink1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.navLink1.Location = new System.Drawing.Point(42, 14);
            this.navLink1.Name = "navLink1";
            this.navLink1.Size = new System.Drawing.Size(130, 30);
            this.navLink1.TabIndex = 0;
            this.navLink1.Text = "Films";
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
            this.navLink2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.navLink2.Location = new System.Drawing.Point(194, 14);
            this.navLink2.Name = "navLink2";
            this.navLink2.Size = new System.Drawing.Size(130, 30);
            this.navLink2.TabIndex = 1;
            this.navLink2.Text = "Zalen";
            this.navLink2.UseVisualStyleBackColor = false;
            this.navLink2.Click += new System.EventHandler(this.navLink2_Click);
            // 
            // navLink3
            // 
            this.navLink3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navLink3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navLink3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLink3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLink3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.navLink3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.navLink3.Location = new System.Drawing.Point(348, 14);
            this.navLink3.Name = "navLink3";
            this.navLink3.Size = new System.Drawing.Size(130, 30);
            this.navLink3.TabIndex = 4;
            this.navLink3.Text = "Voorstellingen";
            this.navLink3.UseVisualStyleBackColor = false;
            this.navLink3.Click += new System.EventHandler(this.navLink3_Click);
            // 
            // navLink4
            // 
            this.navLink4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navLink4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navLink4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLink4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLink4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.navLink4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.navLink4.Location = new System.Drawing.Point(504, 14);
            this.navLink4.Name = "navLink4";
            this.navLink4.Size = new System.Drawing.Size(136, 30);
            this.navLink4.TabIndex = 3;
            this.navLink4.Text = "Reserveringen";
            this.navLink4.UseVisualStyleBackColor = false;
            this.navLink4.Click += new System.EventHandler(this.navLink4_Click);
            // 
            // navLink5
            // 
            this.navLink5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navLink5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navLink5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navLink5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.navLink5.FlatAppearance.BorderSize = 0;
            this.navLink5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navLink5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.navLink5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.navLink5.Location = new System.Drawing.Point(659, 14);
            this.navLink5.Name = "navLink5";
            this.navLink5.Size = new System.Drawing.Size(130, 30);
            this.navLink5.TabIndex = 2;
            this.navLink5.Text = "Gebruikers";
            this.navLink5.UseVisualStyleBackColor = false;
            this.navLink5.Click += new System.EventHandler(this.navLink5_Click);
            // 
            // navLoginUsername
            // 
            this.navLoginUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navLoginUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.navLoginUsername.Location = new System.Drawing.Point(1424, 16);
            this.navLoginUsername.Name = "navLoginUsername";
            this.navLoginUsername.Size = new System.Drawing.Size(132, 26);
            this.navLoginUsername.TabIndex = 7;
            this.navLoginUsername.Text = "Gebruikersnaam";
            this.navLoginUsername.Enter += new System.EventHandler(this.LoginUsernameRemoveText);
            this.navLoginUsername.Leave += new System.EventHandler(this.LoginUsernameAddText);
            // 
            // navLoginPassword
            // 
            this.navLoginPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.navLoginPassword.Location = new System.Drawing.Point(1424, 58);
            this.navLoginPassword.Name = "navLoginPassword";
            this.navLoginPassword.Size = new System.Drawing.Size(132, 26);
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
            this.navLoginButton.Location = new System.Drawing.Point(1565, 16);
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
            this.navRegisterButton.Location = new System.Drawing.Point(1565, 51);
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
            this.navAccountButton.Location = new System.Drawing.Point(1565, 16);
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
            this.navLogoutButton.Location = new System.Drawing.Point(1565, 51);
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
            this.AcceptButton = this.navLoginButton;
            this.ClientSize = new System.Drawing.Size(1684, 1031);
            this.Controls.Add(this.navBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BaseLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
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
                GuiHelper.ShowError("Invalid username or password");
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
            bool isAdmin = loggedIn && user.admin;

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

            // Update nav item visibillity
            navLink1.Visible = isAdmin;
            navLink2.Visible = isAdmin;
            navLink3.Visible = isAdmin;
            navLink4.Visible = isAdmin;
            navLink5.Visible = isAdmin;

            userReservationButton.Visible = loggedIn;
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
            ShowList showList = app.GetScreen<ShowList>("showList");
            app.ShowScreen(showList);
        }

        private void navLink4_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ReservationList reservationList = app.GetScreen<ReservationList>("reservationList");
            app.ShowScreen(reservationList);
        }

        private void navLink5_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserList userList = app.GetScreen<UserList>("userList");
            app.ShowScreen(userList);
        }

        private void UserShowButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieListUser movieListUser = app.GetScreen<MovieListUser>("movieListUser");
            app.ShowScreen(movieListUser);
        }

        private void UserReservationButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ReservationList reservationList = app.GetScreen<ReservationList>("reservationList");
            app.ShowScreen(reservationList);
        }

        private void Form_Closed(object sender, FormClosedEventArgs e) {
            Program app = Program.GetInstance();

            // Stop app if  still running
            if (app.IsRunning()) {
                app.Stop();
            }
        }

    }

}




        
            
       
    
