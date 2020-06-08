using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;
using Projects.Forms;

namespace Project.Forms {

    public class ReservationList : BaseLayout {

        private ListView container;

        public ReservationList() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "reservationList";
        }


        public override void OnShow() {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            List<Reservation> reservations = reservationService.GetReservations();
            UserService userService = app.GetService<UserService>("users");
            List<User> users = userService.GetUsers();
            MovieService movieService = app.GetService<MovieService>("movies");
            ImageList imgs = new ImageList();
            List<Movie> movies = movieService.GetMovies();

            base.OnShow();

            container.Items.Clear();

            for (int i = 0; i < reservations.Count; i++) {
                Reservation reservation = reservations[i];
                Movie movie = movies[i];
                User user = users[i];
                ListViewItem item = new ListViewItem(reservation.userId + " - " + user.username + " - " + movie.name + " - " + movie.duration, i);

                item.Tag = reservation.id;
                container.Items.Add(item);
                
            }

        }
        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(40, 129);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(670, 452);
            this.container.TabIndex = 2;
            this.container.UseCompatibleStateImageBehavior = false;
            this.container.SelectedIndexChanged += new System.EventHandler(this.container_SelectedIndexChanged);
            // 
            // ReservationList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.container);
            this.Name = "ReservationList";
            this.Load += new System.EventHandler(this.ReservationList_Load);
            this.Controls.SetChildIndex(this.container, 0);
            this.ResumeLayout(false);

        }

        private void ReservationList_Load(object sender, System.EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("User", 100);

        }

       

        private void container_SelectedIndexChanged(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            ListViewItem item = container.SelectedItems[0];
            int id = (int)item.Tag;
            Reservation reservation = reservationService.GetReservationById(id);

            ReservationDetail reservationDetailScreen = app.GetScreen<ReservationDetail>("reservationDetail");

            reservationDetailScreen.SetReservation(reservation);
            app.ShowScreen(reservationDetailScreen);
        }
    }

}
