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
            UserManager userManager = app.GetService<UserManager>("chair");

            ConsoleHelper.Print(PrintType.Info, "chair list (id - row - number - price - type):");

            // Print chairs
            ChairManager chairManager = app.GetService<ChairManager>("chairs");
            foreach(Chair chair in chairManager.GetChairs()) {
                ConsoleHelper.Print(PrintType.Info, chair.id + " - " + chair.row + " - " + chair.number + " - " + chair.price + " - " + chair.type);
            }
        }
    }

}
