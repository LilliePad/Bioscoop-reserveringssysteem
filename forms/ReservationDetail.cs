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

        public void SetReservation(Reservation reservation) {
            this.reservation = reservation;
        }

        private void Delete_Reservation_button_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            ReservationService reservationService = app.GetService<ReservationService>("reservations");

            Reservation reservation = reservationService.GetReservationById(id);

            reservationService.DeleteReservation(reservation)
        }
    }
}
