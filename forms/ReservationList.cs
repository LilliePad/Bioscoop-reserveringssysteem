﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Helpers;
using Project.Models;
using Project.Services;
using Projects.Forms;

namespace Project.Forms {

    public class ReservationList : BaseLayout {

        // Frontend
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
            UserService userService = app.GetService<UserService>("users");
            List<Reservation> reservations = reservationService.GetReservations();
            User currentUser = userService.GetCurrentUser();

            base.OnShow();

            container.Items.Clear();

            for (int i = 0; i < reservations.Count; i++) {
                Reservation reservation = reservations[i];
                Show show = reservation.GetShow();
                Movie movie = show.GetMovie();
                User user = reservation.GetUser();

                // Make sure the user is allowed to see it
                if(!currentUser.admin && currentUser.id != user.id) {
                    continue;
                }

                // Create item
                ListViewItem item = new ListViewItem(user.username + " - " + movie.name + " - " + show.startTime.ToString(Program.DATETIME_FORMAT), i);

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
            this.container.SelectedIndexChanged += new System.EventHandler(this.ListItem_Click);
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
            container.Columns.Add("Reserveringen (gebruiker - film - starttijd)", 600);

        }

        private void ListItem_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");

            // Get the clicked item
            ListViewItem item = container.SelectedItems[0];

            if (item == null) {
                GuiHelper.ShowError("Geen item geselecteerd");
                return;
            }

            // Find the movie
            int id = (int) item.Tag;
            Reservation reservation = reservationService.GetReservationById(id);

            if (reservation == null) {
                GuiHelper.ShowError("Kon geen reservering vinden voor dit item");
                return;
            }

            // Show screen
            ReservationDetail reservationDetail = app.GetScreen<ReservationDetail>("reservationDetail");

            reservationDetail.SetReservation(reservation);
            app.ShowScreen(reservationDetail);
        }

    }

}
