using Project.Forms.Layouts;
using System.Windows.Forms;
using System;
using Project.Base;
using Project.Models;
using Project.Services;
using Project.Helpers;
using Project;
using Project.Forms;

namespace Projects.Forms {
    public partial class ReservationDetail : BaseLayout {

        private Reservation reservation;
        public ReservationDetail() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "reservationDetail";
        }

        public void SetReservation(Reservation reservation) {
            this.reservation = reservation;
        }

        private void Delete_Reservation_button_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            reservationService.DeleteReservation(reservation);
            ReservationList reservationListScreen = Program.GetInstance().GetScreen<ReservationList>("reservationList");
            Program.GetInstance().ShowScreen(reservationListScreen);
        }

        public override void OnShow() {
            base.OnShow();
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");

            Show show = reservation.GetShow();
            Chair chair = reservation.GetChair();
            Movie movie = show.GetMovie();
            Reservation_Id_Text.Text = "ID: " + reservation.id;
            Show_Text.Text = "Film: " + movie.name + " Starttijd: " + show.startTime;
            Chair_Text.Text = "Rij: " + chair.row + " Nummer: " + chair.row + " Stoel ID:" + chair.id; 

        }

        private void Reservation_Id_Label_Click(object sender, EventArgs e) {

        }

        private void Reservation_Show_Label_Click(object sender, EventArgs e) {

        }

        private void Reservation_Chair_Label_Click(object sender, EventArgs e) {

        }

        private void Reservation_Id_Text_Click(object sender, EventArgs e) {

        }

        private void Show_Text_Click(object sender, EventArgs e) {

        }

        private void Chair_Text_Click(object sender, EventArgs e) {

        }
    }
}
