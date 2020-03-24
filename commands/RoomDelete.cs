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

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            RoomManager roomManager = app.GetService<RoomManager>("rooms");

            // Check args length
            if (args.Length != 1) {
                ConsoleHelper.Print(PrintType.Error, "Usage: room/delete <id>");
                return;
            }

            // Find room
            int id = ConsoleHelper.ParseInt(args[0], "id");
            Room room = roomManager.GetRoomById(id);

            if(room == null) {
                throw new ArgumentException("id moet een bestaand zaal-id zijn.");
            }

            if(roomManager.DeleteRoom(room)) {
                ConsoleHelper.Print(PrintType.Info, "Zaal succesvol verwijderd.");
            } else {
                ConsoleHelper.Print(PrintType.Error, "Kon zaal niet verwijderen.");
            }
        }

    }

}
