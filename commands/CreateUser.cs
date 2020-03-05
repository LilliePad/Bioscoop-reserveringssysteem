using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Services;


namespace Project.Commands {

    class CreateUser : Command {

        public override string GetCategory() {
            return "user";
        }

        public override string GetName() {
            return "create";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserManager userManager = app.getService<UserManager>("users");

            if(args.Length < 3) {
                LogHelper.Log(LogType.Error, "Usage: user/create <fullName> <username> <password>");
                return;
            }

            string answer = askQuestion("test 123?");
            LogHelper.Log(LogType.Info, "Answer: " + answer);

            if (userManager.RegisterUser(args[0], args[1], args[2], false)) {
                LogHelper.Log(LogType.Info, "Gebruiker succesvol aangemaakt.");
            } else {
                LogHelper.Log(LogType.Info, "Kon gebruiker niet aanmaken.");
            }
        }

    }

}
