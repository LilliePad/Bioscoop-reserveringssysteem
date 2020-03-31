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
            RoomService roomService = app.GetService<RoomService>("rooms");

            // Check args length
            if (args.Length != 1) {
                throw new ArgumentException("Gebruik: room/create <number>");
            }

            // Try to save
            int number = ConsoleHelper.ParseInt(args[0], "number");
            Room room = new Room(number);

            if (roomService.SaveRoom(room)) {
                ConsoleHelper.Print(PrintType.Info, "Zaal succesvol aangemaakt");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon zaal niet aanmaken. Errors:");
                ConsoleHelper.PrintErrors(room);
            }
        }

    }

}
