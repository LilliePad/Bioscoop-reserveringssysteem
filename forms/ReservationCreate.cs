using Project.Forms.Layouts;
using System.Windows.Forms;
using System;
using Project.Base;
using Project.Models;
using Project.Services;
using Project.Helpers;
using Project;
using Project.Forms;

namespace Bioscoop_reserveringssysteem.forms {
    public partial class ReservationCreate : BaseLayout {

        private string userNameValue;

        private string LogedInUser;
        public ReservationCreate() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "reservationCreate";
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
            Program app = Program.GetInstance();
            ChairSelect chairSelectScreen = app.GetScreen<ChairSelect>("chairSelect");
            app.ShowScreen(chairSelectScreen);
        }
    }
}
