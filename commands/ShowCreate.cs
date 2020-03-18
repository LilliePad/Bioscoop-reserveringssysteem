using System.Collections.Generic;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;


namespace Project.Commands {

    class ShowCreate : InteractiveCommand {

        public override string GetCategory() {
            return "show";
        }

        public override bool RequireLogin() {
            return true;
        }

        public override string GetName() {
            return "create";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ShowManager showManager = app.GetService<ShowManager>("shows");


            // Get input
            string fullName = AskQuestion("Wat is uw volledige naam?");
            string username = AskQuestion("Welke username wilt u gebruiken?");
            string password = AskQuestion("Welk wachtwoord wilt u gebruiken?");
            bool admin = false;


            User show = new User(fullName, username, hashedPassword, admin);

            // Login if registration successful
            if (ShowManager.SaveShow(show)) {
                ConsoleHelper.Print(PrintType.Info, "Gebruiker succesvol aangemaakt en ingelogd.");
            } else {
                ConsoleHelper.Print(PrintTpe.Info, "Kon gebruiker niet aanmaken. Errors:");

                // Print errors
                foreach(KeyValuePair<string, List<string>> attribute in show.GetErrors()) {
                    foreach(string error in attribute.Value) {
                        ConsoleHelper.Print(PrintType.Error, attribute.Key + " -> " + error);
                    }
                }
            }
        }

    }

}
