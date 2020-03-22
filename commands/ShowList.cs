using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class ShowList : Command {

        public override string GetCategory() {
            return "show";
        }

        public override string GetName() {
            return "list";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ShowManager showManager = app.GetService<ShowManager>("shows");

            ConsoleHelper.Print(PrintType.Info, "Show list (id - Movie - Room - Date - Time):");

            // Print users
            foreach(Show show in showManager.GetShows()) {
                ConsoleHelper.Print(PrintType.Info, show.id + " - " + show.Movie + " - " + show.Room + " - " + show.Date + "-" + show.Time);
            }
        }

    }

}
