using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Services;
using Project.Models;

namespace Project.Commands {

    class ReservationCreate : Command {

        public override string GetName() {
            return "create";
        }

        public override string GetCategory() {
            return "reservation";
        }

        public override bool RequireLogin() {
            return true;
        }

        public override string GetUsage() {
            return "reservation/create <id> <chair> <room> <show>";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservation");
            UserService userService = app.GetService<UserService>("user");

            // Check args length
            if (args.Length != 4) {
                throw new ArgumentException("Gebruik: " + GetUsage());
            }

            // Parse params
            int id = ConsoleHelper.ParseInt(args[0], "id");
            int chair = ConsoleHelper.ParseInt(args[1], "chair");
            int room = ConsoleHelper.ParseInt(args[2], "room");

            // Gets current user
            int userId = userService.GetCurrentUserId();
            

            // Create chair object
            Reservation reservation = new Reservation(id, chair, room, userId, args[3]);

            // Try to save it
            if (reservationService.SaveReservation(reservation)) {
                ConsoleHelper.Print(PrintType.Info, "Tickets succesvol gereserveerd");
            }
            else {
                ConsoleHelper.Print(PrintType.Info, "Kon reservering niet aanmaken. Errors:");
                ConsoleHelper.PrintErrors(reservation);
            }
        }
    }
}