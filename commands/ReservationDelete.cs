using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Services;
using Project.Models;


namespace Bioscoop_reserveringssysteem.commands {
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

        public override bool RequireAdmin() {
            return true;
        }
        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("s");

            // Check args length
            if (args.Length != 1) {
                throw new ArgumentException("Gebruik: " + GetUsage());
            }

            // Find room
            int id = ConsoleHelper.ParseInt(args[0], "id");
            Reservation reservation = reservationService.GetReservationById(id);

            if (reservation == null) {
                throw new ArgumentException("Ongeldige boeking");
            }

            // Try to delete
            if (reservationService.DeleteReservation(reservation)) {
                ConsoleHelper.Print(PrintType.Info, "Zaal succesvol verwijderd");
            }
            else {
                ConsoleHelper.Print(PrintType.Error, "Kon zaal niet verwijderen");
            }
        }


    }
}
