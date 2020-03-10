using System.Collections.Generic;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;


namespace Project.Commands {

    class CreateUser : Command {

        public override string GetCategory() {
            return "user";
        }

        public override bool RequireLogin() {
            return false;
        }

        public override string GetName() {
            return "create";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserManager userManager = app.GetService<UserManager>("users");
            User currentUser = userManager.GetCurrentUser();

            // Get input
            string fullName = AskQuestion("Wat is uw volledige naam?");
            string username = AskQuestion("Welke username wilt u gebruiken?");
            string password = AskQuestion("Welk wachtwoord wilt u gebruiken?");
            bool admin = false;

            if(currentUser != null && currentUser.admin) {
                string adminValue = AskQuestion("Moet deze gebruiker een admin worden (ja/nee)?");
                admin = adminValue.ToLower() == "ja" ? true : false;
            }

            // Try to register
            User user = userManager.RegisterUser(fullName, username, password, admin);

            if (!user.HasErrors()) {
                userManager.SetCurrentUser(user);
                LogHelper.Log(LogType.Info, "Gebruiker succesvol aangemaakt en ingelogd.");
            } else {
                LogHelper.Log(LogType.Info, "Kon gebruiker niet aanmaken. Errors:");

                foreach(KeyValuePair<string, List<string>> attribute in user.GetErrors()) {
                    foreach(string error in attribute.Value) {
                        LogHelper.Log(LogType.Error, attribute.Key + " -> " + error);
                    }
                }
            }
        }

    }

}
