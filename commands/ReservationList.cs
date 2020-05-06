using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class ReservationList : Command {

        public override string GetCategory() {
            return "reservation";
        }

        public override string GetName() {
            return "list";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            UserService userService = app.GetService<UserService>("users");

            // Get current user
            User currentUser = userService.GetCurrentUser();

            ConsoleHelper.Print(PrintType.Info, "Reserveringen (Id - Voorstelling id - Gebruiker id - Stoel id):");

            // Print reservations
            foreach (Reservation reservation in reservationService.GetReservations()) {
                if(reservation.userId != currentUser.id && !currentUser.admin) {
                    continue;
                }

                ConsoleHelper.Print(PrintType.Info, reservation.id + " - " + reservation.showId + " - " + reservation.userId + " - " + reservation.chairId);
            }
        }
    }
}