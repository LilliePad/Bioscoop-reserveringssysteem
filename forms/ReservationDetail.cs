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
        private Show show;

        private Reservation reservation;
        public ReservationDetail() {
            InitializeComponent();
        }

        public void SetReservation(Reservation reservation) {
            this.reservation = reservation;
        }

        private void Delete_Reservation_button_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            ReservationService reservationService = app.GetService<ReservationService>("reservations");

            //Reservation reservation = reservationService.GetReservationById(id);

            reservationService.DeleteReservation(reservation);
        }

        public override void OnShow() {
            base.OnShow();
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            Reservation_Id_Text.Text = reservation.id;
            show = reservation.GetShow(reservation.showId);
            Show_Text.Text = reservation.Get;
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
