using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;
using System;

namespace Project.Commands {

    class ShowDelete : Command {

        public override string GetCategory() {
            return "show";
        }

        public override string GetName() {
            return "delete";
        }

        public override string GetUsage() {
            return "show/delete <id>";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");

            // Check args length
            if (args.Length != 1) {
                throw new ArgumentException("Gebruik: " + GetUsage());
            }

            // Find room
            int id = ConsoleHelper.ParseInt(args[0], "id");
            Show show = showService.GetShowById(id);

            if(show == null) {
                throw new ArgumentException("Ongeldige show");
            }

            // Try to delete
            if (showService.DeleteShow(show)) {
                ConsoleHelper.Print(PrintType.Info, "Show succesvol verwijderd");
            } else {
                ConsoleHelper.Print(PrintType.Error, "Kon show niet verwijderen");
            }
        }

    }

}
