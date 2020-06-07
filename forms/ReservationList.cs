using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class ReservationList : BaseLayout {

        private ListView container;
        private Button movieCreateButton;

        public ReservationList() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "reservationList";
        }


        public override void OnShow() {
            Program app = Program.GetInstance();
            ReservationService ReservationService = app.GetService<ReservationService>("reservations");
            List<Reservation> reservations = ReservationService.GetReservations();

            base.OnShow();

            container.Items.Clear();

            for (int i = 0; i < reservations.Count; i++) {
                Reservation reservation = reservations[i];
                ListViewItem item = new ListViewItem(reservation.userId + "", i);

                item.Tag = reservation.showId;
                container.Items.Add(item);
                item.SubItems.Add(reservation.showId + "");
                item.SubItems.Add(reservation.chairId + "");

            }

        }
        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.movieCreateButton = new System.Windows.Forms.Button();
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
            // movieCreateButton
            // 
            this.movieCreateButton.Location = new System.Drawing.Point(0, 0);
            this.movieCreateButton.Name = "movieCreateButton";
            this.movieCreateButton.Size = new System.Drawing.Size(75, 23);
            this.movieCreateButton.TabIndex = 2;
            // 
            // ReservationList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.movieCreateButton);
            this.Controls.Add(this.container);
            this.Name = "ReservationList";
            this.Load += new System.EventHandler(this.ReservationList_Load);
            this.Controls.SetChildIndex(this.container, 0);
            this.Controls.SetChildIndex(this.movieCreateButton, 0);
            this.ResumeLayout(false);

        }

        private void ReservationList_Load(object sender, System.EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("User", 100);
            container.Columns.Add("Movie", 100);
            container.Columns.Add("Chair", 100);
        }

       

        private void container_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }

}
