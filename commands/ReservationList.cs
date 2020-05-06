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

        public override bool RequireAdmin() {
            return true;
        }
                    public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");

            ConsoleHelper.Print(PrintType.Info, "Reservation list (id - chair - show - userId):");

            // Print reservations
            foreach (Reservation reservation in reservationService.GetReservation()) {
                ConsoleHelper.Print(PrintType.Info, reservation.id + " - " + reservation.chair + " - " + reservation.show + " - " + reservation.userId);
            }
        }
    }
}