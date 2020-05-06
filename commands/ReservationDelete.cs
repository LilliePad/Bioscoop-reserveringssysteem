using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Services;
using Project.Models;

namespace Project {

    class ReservationDelete : Command {

        public override string GetCategory() {
            return "reservation";
        }

        public override string GetName() {
            return "delete";
        }

        public override string GetUsage() {
            return "reservation/delete <id>";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            ReservationService reservationService = app.GetService<ReservationService>("reservations");

            // Check args length
            if (args.Length != 1) {
                throw new ArgumentException("Gebruik: " + GetUsage());
            }

            // Find reservation
            int id = ConsoleHelper.ParseInt(args[0], "id");
            Reservation reservation = reservationService.GetReservationById(id);

            if (reservation == null) {
                throw new ArgumentException("Ongeldige reservering");
            }

            // Check permission
            User currentUser = userService.GetCurrentUser();

            if(reservation.userId != currentUser.id && !currentUser.admin) {
                throw new UnauthorizedAccessException("Je hebt onvoldoende rechten om deze reservering te verwijderen");
            }

            // Try to delete
            if (reservationService.DeleteReservation(reservation)) {
                ConsoleHelper.Print(PrintType.Info, "Reservering succesvol verwijderd");
            } else {
                ConsoleHelper.Print(PrintType.Error, "Kon reservering niet verwijderen");
            }
        }

    }
}
