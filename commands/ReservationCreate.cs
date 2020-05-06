using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Services;
using Project.Models;

namespace Project.Commands {

    class ReservationCreate : Command {

        public override string GetCategory() {
            return "reservation";
        }

        public override string GetName() {
            return "create";
        }

        public override string GetUsage() {
            return "reservation/create <chairId> <showId>";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            UserService userService = app.GetService<UserService>("users");

            // Check args length
            if (args.Length != 2) {
                throw new ArgumentException("Gebruik: " + GetUsage());
            }

            // Parse params
            int showId = ConsoleHelper.ParseInt(args[1], "showId");
            User user = userService.GetCurrentUser();
            int chairId = ConsoleHelper.ParseInt(args[0], "chairId");
            
            // Create reservation object
            Reservation reservation = new Reservation(showId, user.id, chairId);

            // Try to save it
            if (reservationService.SaveReservation(reservation)) {
                ConsoleHelper.Print(PrintType.Info, "Reservering succesvol aangemaakt");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon reservering niet aanmaken. Errors:");
                ConsoleHelper.PrintErrors(reservation);
            }
        }

    }
}