using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class Help : Command {

        public override string GetName() {
            return "help";
        }

        public override bool RequireLogin() {
            return false;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            ConsoleService consoleService = app.GetService<ConsoleService>("console");
            User currentUser = userService.GetCurrentUser();

            ConsoleHelper.Print(PrintType.Info, "Commando's waar je toegang tot hebt:");

            foreach (Command command in consoleService.GetCommands()) {
                bool requireLogin = command.RequireLogin() || command.RequireAdmin();

                // Skip if not logged in
                if (requireLogin && currentUser == null) {
                    continue;
                }

                // Skip if not an admin
                if(command.RequireAdmin() && !currentUser.admin) {
                    continue;
                }

                ConsoleHelper.Print(PrintType.Info, command.GetUsage());
            }
        }

    }

}
