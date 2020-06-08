using Project.Forms.Layouts;
using Project.Helpers;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Project.Forms {
    public partial class ReservationCreate : BaseLayout {
        private Room room;
        private Show show;
        private Chair chair;
        private List<Chair> chairs = new List<Chair>();


        public ReservationCreate() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "reservationCreate";
        }

        public void SetRoom(Room room) {
            this.room = room;
        }

        public void Setchair(Chair chair) {
            this.chair = chair;
        }

        public void GetShow(Show show) {
            this.show = show;
        }

        public void GetSelectedChairs(List<Chair> chairs) {
            this.chairs = chairs;
        }

        public override void OnShow() {
            base.OnShow();
            Movie_Name_Label.Text = show.GetMovie().name;
            Movie_Picture.Image = show.GetMovie().GetImage();
            container.Items.Clear();
            Program app = Program.GetInstance();
            ChairSelect chairSelect = new ChairSelect();
            if (chair != null) {
                chairs.Add(chair);
                for (int i = 0; i < chairs.Count; i++) {
                    Chair chair = chairs[i];
                    ListViewItem item = new ListViewItem("rij: " + chair.row + " " + "nummer: " + chair.number, i);

                    item.Tag = "rij: " + chair.row + " " + "nummer: " + chair.number;
                    container.Items.Add(item);
                }
            }
        }

        private void Select_Chair_Button_Click(object sender, EventArgs e) {
                Program app = Program.GetInstance();
                ChairSelect ChairSelectScreen = app.GetScreen<ChairSelect>("chairSelect");
                ChairSelectScreen.SetShow(show);
                ChairSelectScreen.SetMovie(show.GetMovie());
                app.ShowScreen(ChairSelectScreen);
            }

            private void Reserve_Tickets_Button_Click(object sender, EventArgs e) {

                Program app = Program.GetInstance();
                ReservationService reservationService = app.GetService<ReservationService>("reservations");
                UserService userService = app.GetService<UserService>("users");
                ChairService chairService = app.GetService<ChairService>("chairs");

                User currentUser = userService.GetCurrentUser();
            if (currentUser == null) {
                MessageBox.Show("U moet ingelogd zijn om tickets te kunnen reserveren");
            }
            else {
                bool reservationSucces = true;
                foreach (Chair chair in chairs) {
                    Reservation reservation = new Reservation(show.id, currentUser.id, chair.id);
                    if (!reservationService.SaveReservation(reservation)) {
                        reservationSucces = false;
                    }

                }

                if (reservationSucces) {
                        MessageBox.Show("tickets succesvol gereserveerd");
                    MovieListUser movieListUserScreen = Program.GetInstance().GetScreen<MovieListUser>("movieListUser");
                    Program.GetInstance().ShowScreen(movieListUserScreen);
                }
                else {
                    MessageBox.Show("kon de tickets niet reserveren");
                    MovieListUser movieListUserScreen = Program.GetInstance().GetScreen<MovieListUser>("movieListUser");
                    Program.GetInstance().ShowScreen(movieListUserScreen);
                }
                
                chairs.Clear();

            }
        }

            private void ReservationCreate_Load(object sender, EventArgs e) {

            }

            private void label1_Click(object sender, EventArgs e) {

            }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void Selected_Chairs_list_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void Selected_Chairs_List_SelectedIndexChanged_1(object sender, EventArgs e) {

        }
    }
}
