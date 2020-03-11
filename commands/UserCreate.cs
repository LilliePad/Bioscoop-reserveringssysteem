using System.Collections.Generic;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;


namespace Project.Commands {

    class UserCreate : InteractiveCommand {

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

            // Get extra input if the user is an admin
            if(currentUser != null && currentUser.admin) {
                string adminValue = AskQuestion("Moet deze gebruiker een admin worden (ja/nee)?");
                admin = adminValue.ToLower() == "ja" ? true : false;
            }

            // Try to register
            User user = userManager.RegisterUser(fullName, username, password, admin);

            // Login if registration successful
            if (!user.HasErrors()) {
                userManager.SetCurrentUser(user);
                ConsoleHelper.Print(PrintType.Info, "Gebruiker succesvol aangemaakt en ingelogd.");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon gebruiker niet aanmaken. Errors:");

                // Print errors
                foreach(KeyValuePair<string, List<string>> attribute in user.GetErrors()) {
                    foreach(string error in attribute.Value) {
                        ConsoleHelper.Print(PrintType.Error, attribute.Key + " -> " + error);
                    }
                }
            }
        }

    }

}
