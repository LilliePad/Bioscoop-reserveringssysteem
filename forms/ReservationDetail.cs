using System;
using Project.Forms.Layouts;
using System.Windows.Forms;
using Project;
using Project.Models;
using Project.Services;
using Project.Forms;
using Project.Helpers;

namespace Projects.Forms {

    public class ReservationDetail : BaseLayout {

        // Frontend
        private Panel panel;
        private Label title;

        private Label movieLabel;
        private Label movieValue;

        private Label roomLabel;
        private Label roomValue;
        
        private Label chairLabel;
        private Label chairValue;
        
        private Label datetimeLabel;
        private Label datetimeValue;

        private Button deleteButton;

        // Backend
        private Reservation reservation;

        public ReservationDetail() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "reservationDetail";
        }

        public override void OnShow() {
            base.OnShow();

            // Show reservation info
            Show show = reservation.GetShow();
            Movie movie = show.GetMovie();
            Room room = show.GetRoom();
            Chair chair = reservation.GetChair();

            movieValue.Text = movie.name;
            roomValue.Text = "Zaal" + room.number;
            chairValue.Text = "Rij: " + chair.row + " Nummer: " + chair.row;
            datetimeValue.Text = "Starttijd: " + show.startTime.ToString(Program.DATETIME_FORMAT);
        }

        private void InitializeComponent() {
            this.title = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.movieLabel = new System.Windows.Forms.Label();
            this.roomLabel = new System.Windows.Forms.Label();
            this.chairLabel = new System.Windows.Forms.Label();
            this.movieValue = new System.Windows.Forms.Label();
            this.roomValue = new System.Windows.Forms.Label();
            this.chairValue = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.datetimeLabel = new System.Windows.Forms.Label();
            this.datetimeValue = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(345, 46);
            this.title.TabIndex = 2;
            this.title.Text = "Reservation Detail";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(0, 358);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(140, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Verwijderen";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // movieLabel
            // 
            this.movieLabel.AutoSize = true;
            this.movieLabel.Location = new System.Drawing.Point(2, 102);
            this.movieLabel.Name = "movieLabel";
            this.movieLabel.Size = new System.Drawing.Size(25, 13);
            this.movieLabel.TabIndex = 5;
            this.movieLabel.Text = "Film";
            // 
            // roomLabel
            // 
            this.roomLabel.AutoSize = true;
            this.roomLabel.Location = new System.Drawing.Point(2, 167);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(28, 13);
            this.roomLabel.TabIndex = 6;
            this.roomLabel.Text = "Zaal";
            // 
            // chairLabel
            // 
            this.chairLabel.AutoSize = true;
            this.chairLabel.Location = new System.Drawing.Point(2, 244);
            this.chairLabel.Name = "chairLabel";
            this.chairLabel.Size = new System.Drawing.Size(31, 13);
            this.chairLabel.TabIndex = 7;
            this.chairLabel.Text = "Stoel";
            // 
            // movieValue
            // 
            this.movieValue.AutoSize = true;
            this.movieValue.Location = new System.Drawing.Point(170, 102);
            this.movieValue.Name = "movieValue";
            this.movieValue.Size = new System.Drawing.Size(47, 13);
            this.movieValue.TabIndex = 8;
            this.movieValue.Text = "<movie>";
            // 
            // roomValue
            // 
            this.roomValue.AutoSize = true;
            this.roomValue.Location = new System.Drawing.Point(170, 167);
            this.roomValue.Name = "roomValue";
            this.roomValue.Size = new System.Drawing.Size(42, 13);
            this.roomValue.TabIndex = 9;
            this.roomValue.Text = "<room>";
            // 
            // chairValue
            // 
            this.chairValue.AutoSize = true;
            this.chairValue.Location = new System.Drawing.Point(170, 244);
            this.chairValue.Name = "chairValue";
            this.chairValue.Size = new System.Drawing.Size(42, 13);
            this.chairValue.TabIndex = 10;
            this.chairValue.Text = "<chair>";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.datetimeLabel);
            this.panel.Controls.Add(this.datetimeValue);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.deleteButton);
            this.panel.Controls.Add(this.movieLabel);
            this.panel.Controls.Add(this.roomLabel);
            this.panel.Controls.Add(this.chairLabel);
            this.panel.Controls.Add(this.movieValue);
            this.panel.Controls.Add(this.roomValue);
            this.panel.Controls.Add(this.chairValue);
            this.panel.Location = new System.Drawing.Point(21, 111);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(993, 534);
            this.panel.TabIndex = 11;
            // 
            // datetimeLabel
            // 
            this.datetimeLabel.AutoSize = true;
            this.datetimeLabel.Location = new System.Drawing.Point(2, 306);
            this.datetimeLabel.Name = "datetimeLabel";
            this.datetimeLabel.Size = new System.Drawing.Size(69, 13);
            this.datetimeLabel.TabIndex = 11;
            this.datetimeLabel.Text = "Datum en tijd";
            // 
            // datetimeValue
            // 
            this.datetimeValue.AutoSize = true;
            this.datetimeValue.Location = new System.Drawing.Point(170, 306);
            this.datetimeValue.Name = "datetimeValue";
            this.datetimeValue.Size = new System.Drawing.Size(59, 13);
            this.datetimeValue.TabIndex = 12;
            this.datetimeValue.Text = "<datetime>";
            // 
            // ReservationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 678);
            this.Controls.Add(this.panel);
            this.Name = "ReservationDetail";
            this.Text = "/";
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
        }

        public void SetReservation(Reservation reservation) {
            this.reservation = reservation;
        }

        private void DeleteButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            ReservationService reservationService = app.GetService<ReservationService>("reservations");

            // Ask for confirmation
            if (!GuiHelper.ShowConfirm("Weet je zeker dat je deze reservering wilt verwijderen?")) {
                return;
            }

            if (!reservationService.DeleteReservation(reservation)) {
                GuiHelper.ShowError("Kon reservering niet verwijderen");
                return;
            }

            // Redirect to screen
            ReservationList reservationListScreen = app.GetScreen<ReservationList>("reservationList");

            app.ShowScreen(reservationListScreen);
            GuiHelper.ShowInfo("Reservering succesvol verwijderd");
        }

    }
}
