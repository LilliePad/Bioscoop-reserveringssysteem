using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;
using System;

namespace Project.Commands {

    class ChairDelete : Command {

        public override string GetCategory() {
            return "chair";
        }

        public override string GetName() {
            return "delete";
        }

        public override string GetUsage() {
            return "chair/delete <id>";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");

            // Check args length
            if (args.Length != 1) {
                throw new ArgumentException("Gebruik: " + GetUsage());
            }

            // Find room
            int id = ConsoleHelper.ParseInt(args[0], "id");
            Chair chair = chairService.GetChairById(id);

            if (chair == null) {
                throw new ArgumentException("Ongeldige stoel");
            }

            // Try to delete
            if (chairService.DeleteChair(chair)) {
                ConsoleHelper.Print(PrintType.Info, "Stoel succesvol verwijderd");
            } else {
                ConsoleHelper.Print(PrintType.Error, "Kon stoel niet verwijderen");
            }
        }

    }

}
