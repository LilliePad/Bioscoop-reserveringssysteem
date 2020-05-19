using Project.Base;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class Reservation : Model {

        public int id = -1;
        public int showId;
        public int userId;
        public int chairId;

        public Reservation(ReservationRecord record) {
            id = record.id;
            showId = record.showId;
            userId = record.userId;
            chairId = record.chairId;
        }

        public Reservation(int showId, int userId, int chairId) {
            this.showId = showId;
            this.userId = userId;
            this.chairId = chairId;
        }

        public override bool Validate() {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");
            UserService userService = app.GetService<UserService>("users");
            ChairService chairService = app.GetService<ChairService>("chairs");
            ReservationService reservationService = app.GetService<ReservationService>("reservations");

            // Make sure the show exists
            Show show = showService.GetShowById(showId);

            if (show == null) {
                AddError("showId", "Ongeldige voorstelling");
                return false;
            }

            // Make sure the user exists
            User user = userService.GetUserById(userId);

            if (user == null) {
                AddError("userId", "Ongeldige gebruiker");
                return false;
            }

            // Make sure the chair exists
            Chair chair = chairService.GetChairById(chairId);

            if (chair == null) {
                AddError("chairId", "Ongeldige stoel");
                return false;
            }

            // Make sure the chair belongs to this room
            if(chair.roomId != show.roomId) {
                AddError("chairId", "De gekozen stoel hoort niet bij de gekozen zaal");
                return false;
            }

            // Make sure the chair hasn't been taken
            if (reservationService.IsChairTaken(chair, show)) {
                AddError("chairId", "De gekozen stoel is niet beschikbaar");
                return false;
            }

            return true;
        }

        // Returns the show
        public Show GetShow() {
            ShowService showService = Program.GetInstance().GetService<ShowService>("shows");
            return showService.GetShowById(showId);
        }

        // Returns the user
        public User GetUser() {
            UserService userService = Program.GetInstance().GetService<UserService>("users");
            return userService.GetUserById(userId);
        }

        // Returns the chair
        public Chair GetChair() {
            ChairService chairService = Program.GetInstance().GetService<ChairService>("chairs");
            return chairService.GetChairById(chairId);
        }

    }
}