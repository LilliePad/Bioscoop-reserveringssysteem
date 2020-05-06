﻿using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Services;
using Project.Models;
using Project.Data;
using Project.Records;

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
            return "reservation/create <chair> <room> <show>";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            UserService userService = app.GetService<UserService>("users");

            // Check args length
            if (args.Length != 3) {
                throw new ArgumentException("Gebruik: " + GetUsage());
            }

            // Parse params
            int chair = ConsoleHelper.ParseInt(args[0], "chair");
            int room = ConsoleHelper.ParseInt(args[1], "room");

            // Gets current user
            User user = userService.GetCurrentUser();
            

            // Create chair object
            Reservation reservation = new Reservation(chair, room, user.id, args[2]);

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