using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;


namespace Project.Commands {

    class LoginUser : Command {

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
            
            if(args.Length != 2) {
                LogHelper.Log(LogType.Error, "Usage: user/login <username> <password>");
                return;
            }

            // Find user
            User user = userManager.GetUserByUsername(args[0]);

            if(user == null || !user.Authenticate(args[1])) {
                LogHelper.Log(LogType.Error, "Ongeldige gebruikersnaam en wachtwoord combinatie.");
                return;
            }

            // Everything ok, login
            userManager.SetCurrentUser(user);
            LogHelper.Log(LogType.Info, "Succesvol ingelogd.");
        }

    }

}
