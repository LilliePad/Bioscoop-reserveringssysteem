using Project.Forms.Layouts;
using System.Windows.Forms;
using System;
using Project.Base;
using Project.Models;
using Project.Services;
using Project.Helpers;
using Project;
using Project.Forms;

namespace Project.Forms {
    public partial class ReservationCreate : BaseLayout {
        private Room room;
        private int row;
        private int column;
        private int id;
        private Show show;
        private Chair chair;


        public ReservationCreate() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "reservationCreate";
        }

        public void SetRoom(Room room) {
            this.room = room;
        }

        public void SetRow(int row) {
            this.row = row;

        }

        public void SetColum(int column) {
            this.column = column;

        }

        public void GetShow(Show show) {
            this.show = show;
        }

        public void GetChairbyId(int id) {
            this.id = id;
        }

        private void Select_Chair_Button_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ChairSelect ChairSelectScreen = app.GetScreen<ChairSelect>("chairSelect");
            app.ShowScreen(ChairSelectScreen);
        }

        private void Reserve_Tickets_Button_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            UserService userService = app.GetService<UserService>("users");
            ChairService chairService = app.GetService<ChairService>("chairs");

            chair = chairService.GetChairByRoomAndPosition(room, row, column);
            User currentUser = userService.GetCurrentUser();

            Reservation reservation = new Reservation(show.id, currentUser.id, chair.id);
        }
    }
}
