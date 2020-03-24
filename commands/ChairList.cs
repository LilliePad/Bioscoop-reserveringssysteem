using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class ChairList : Command {

        public override string GetCategory() {
            return "chair";
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
            ChairService chairService = app.GetService<ChairService>("chairs");

            // Check args length
            if (args.Length != 1) {
                throw new ArgumentException("Gebruik: chair/list <roomId>");
            }

            // Parse params
            int roomId = ConsoleHelper.ParseInt(args[0], "roomId");

            // Find room
            Room room = roomService.GetRoomById(roomId);

            if(room == null) {
                throw new ArgumentException("Ongeldige zaal");
            }

            // Print chairs
            ConsoleHelper.Print(PrintType.Info, "chair list (id - row - number - price - type):");

            // Print chairs
            foreach(Chair chair in chairService.GetChairsByRoom(room)) {
                ConsoleHelper.Print(PrintType.Info, chair.id + " - " + chair.row + " - " + chair.number + " - " + chair.price + " - " + chair.type);
            }
        }

    }
}
