using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;
using System;

namespace Project.Commands {

    class RoomDelete : Command {

        public override string GetCategory() {
            return "room";
        }

        public override string GetName() {
            return "delete";
        }

        public override string GetUsage() {
            return "room/delete <id>";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            RoomService roomService = app.GetService<RoomService>("rooms");

            // Check args length
            if (args.Length != 1) {
                throw new ArgumentException("Gebruik: " + GetUsage());
            }

            // Find room
            int id = ConsoleHelper.ParseInt(args[0], "id");
            Room room = roomService.GetRoomById(id);

            if(room == null) {
                throw new ArgumentException("Ongeldige zaal");
            }

            // Try to delete
            if (roomService.DeleteRoom(room)) {
                ConsoleHelper.Print(PrintType.Info, "Zaal succesvol verwijderd");
            } else {
                ConsoleHelper.Print(PrintType.Error, "Kon zaal niet verwijderen");
            }
        }

    }

}
