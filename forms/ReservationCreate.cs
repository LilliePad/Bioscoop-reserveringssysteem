using Project.Forms.Layouts;
using System.Windows.Forms;
using System;
using Project.Base;
using Project.Models;
using Project.Services;
using Project.Helpers;
using Project;

namespace Bioscoop_reserveringssysteem.forms {
    public partial class ReservationCreate : BaseLayout {
        public ReservationCreate() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "reservation";
        }

        private Movie movie;
        public void SetMovie(Movie movie) {
            this.movie = movie;
        }

        private void username_placeholder_text_Click(object sender, EventArgs e) {

        }

        private void chose_chair_button_Click(object sender, EventArgs e) {

        }

        private void Create_reservation_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            UserService userService = app.GetService<UserService>("users");


        }


        private void ReservationCreate_Load(object sender, EventArgs e) {

        }

        private void chose_chair_button_Click_1(object sender, EventArgs e) {

        }
    }
}
