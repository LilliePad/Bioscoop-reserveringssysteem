using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class RoomCreate : Command {

        public override string GetCategory() {
            return "room";
        }

        public override string GetName() {
            return "create";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            RoomManager roomManager = app.GetService<RoomManager>("rooms");

            // Check args length
            if (args.Length != 1) {
                ConsoleHelper.Print(PrintType.Error, "Usage: room/create <number>");
                return;
            }

            // Try to save
            int number = ConsoleHelper.ParseInt(args[0], "number");
            Room room = new Room(number);

            if (roomManager.SaveRoom(room)) {
                ConsoleHelper.Print(PrintType.Info, "Zaal succesvol aangemaakt en ingelogd.");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon zaal niet aanmaken. Errors:");
                ConsoleHelper.PrintErrors(room);
            }
        }

    }

}
