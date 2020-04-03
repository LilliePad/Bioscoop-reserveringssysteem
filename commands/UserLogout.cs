using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Services;

namespace Project.Commands {

    class UserLogout : Command {

        public override string GetCategory() {
            return "user";
        }

        public override string GetName() {
            return "logout";
        }

        public override void RunCommand(string[] args) {
            UserService userService = Program.GetInstance().GetService<UserService>("users");

            userService.SetCurrentUser(null);
            ConsoleHelper.Print(PrintType.Info, "Succesvol uitgelogd");
        }

    }

}
