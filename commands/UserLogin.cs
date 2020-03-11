using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;


namespace Project.Commands {

    class UserLogin : Command {

        public override string GetCategory() {
            return "user";
        }

        public override bool RequireLogin() {
            return false;
        }

        public override string GetName() {
            return "login";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserManager userManager = app.GetService<UserManager>("users");
            
            // Check args length
            if(args.Length != 2) {
                ConsoleHelper.Print(LogType.Error, "Usage: user/login <username> <password>");
                return;
            }

            // Find user
            User user = userManager.GetUserByUsername(args[0]);

            // Error if user or password invalid
            if(user == null || !user.Authenticate(args[1])) {
                ConsoleHelper.Print(LogType.Error, "Ongeldige gebruikersnaam en wachtwoord combinatie.");
                return;
            }

            // Everything ok, login
            userManager.SetCurrentUser(user);
            ConsoleHelper.Print(LogType.Info, "Succesvol ingelogd.");
        }

    }

}
