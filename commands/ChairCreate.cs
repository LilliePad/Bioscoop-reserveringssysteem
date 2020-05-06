using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Services;
using Project.Models;

namespace Project.Commands {

    class ChairCreate : Command {

        public override string GetCategory() {
            return "chair";
        }

        public override string GetName() {
            return "create";
        }

        public override string GetUsage() {
            return "chair/create <roomId> <row> <number> <price> <type>";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");

            // Check args length
            if (args.Length != 5) {
                throw new ArgumentException("Gebruik: " + GetUsage());
            }

            // Parse params
            int roomId = ConsoleHelper.ParseInt(args[0], "roomId");
            int row = ConsoleHelper.ParseInt(args[1], "row");
            int number = ConsoleHelper.ParseInt(args[2], "number");
            double price = ConsoleHelper.ParseDouble(args[3], "price");

            // Create chair object
            Chair chair = new Chair(roomId, row, number, price, args[4]);

            // Try to save it
            if (chairService.SaveChair(chair)) {
                ConsoleHelper.Print(PrintType.Info, "Stoel succesvol aangemaakt");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon stoel niet aanmaken. Errors:");
                ConsoleHelper.PrintErrors(chair);
            }
        }

    }
}
