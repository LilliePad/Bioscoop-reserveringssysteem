using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class RoomList : Command {

        public override string GetCategory() {
            return "room";
        }

        public override string GetName() {
            return "list";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            RoomService roomService = app.GetService<RoomService>("rooms");

            ConsoleHelper.Print(PrintType.Info, "Zalen (Id - Nummer):");

            // Print rooms
            foreach (Room room in roomService.GetRooms()) {
                ConsoleHelper.Print(PrintType.Info, room.id + " - " + room.number);
            }
        }

    }

}
