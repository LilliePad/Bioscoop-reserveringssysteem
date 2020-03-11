using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class UserList : Command {

        public override string GetCategory() {
            return "user";
        }

        public override string GetName() {
            return "list";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserManager userManager = app.GetService<UserManager>("users");

            ConsoleHelper.Print(PrintType.Info, "User list (id - username - fullname - admin):");

            // Print users
            foreach(User user in userManager.GetUsers()) {
                ConsoleHelper.Print(PrintType.Info, user.id + " - " + user.username + " - " + user.fullName + " - " + user.admin);
            }
        }

    }

}
