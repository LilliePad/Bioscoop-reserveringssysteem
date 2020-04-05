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
            ShowService showService = app.GetService<ShowService>("shows");

            ConsoleHelper.Print(PrintType.Info, "Show list (id - Movie - RoomID - DateTime):");

            // Print users
            foreach(Show show in showService.GetShows()) {
                ConsoleHelper.Print(PrintType.Info, show.id + " - " + show.Movie + " - " + show.RoomId + " - " + show.dateTimeShow);
            }
        }

    }

}
