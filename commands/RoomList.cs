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
            RoomManager roomManager = app.GetService<RoomManager>("rooms");

            ConsoleHelper.Print(PrintType.Info, "Room list (id - number):");

            // Print rooms
            foreach (Room room in roomManager.GetRooms()) {
                ConsoleHelper.Print(PrintType.Info, room.id + " - " + room.number);
                ConsoleHelper.Print(PrintType.Info, "  Chairs:");

                foreach(string chair in room.GetChairs()) {
                    ConsoleHelper.Print(PrintType.Info, "  " + chair);
                }
            }
        }

    }

}
