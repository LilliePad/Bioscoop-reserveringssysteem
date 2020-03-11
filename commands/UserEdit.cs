using System;
using System.Collections.Generic;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;


namespace Project.Commands {

    class UserEdit : InteractiveCommand {

        public override string GetCategory() {
            return "user";
        }

        public override string GetName() {
            return "edit";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserManager userManager = app.GetService<UserManager>("users");
            User currentUser = userManager.GetCurrentUser();

            // Find the user to edit
            User user = currentUser;

            if(currentUser.admin && args.Length == 1) {
                user = userManager.GetUserByUsername(args[0]);

                if(user == null) {
                    throw new Exception("Ongeldige gebruikersnaam");
                }
            }

            // Get input
            user.fullName = AskQuestion("Wat is uw volledige naam?", null, user.fullName);
            user.username = AskQuestion("Welke username wilt u gebruiken?", null, user.username);

            // Get extra input if the current user is an admin
            if (currentUser.admin) {
                string adminValue = AskQuestion("Moet deze gebruiker een admin worden?", Question.OPTIONS_BOOL, user.admin ? Question.OPTION_YES : Question.OPTION_NO);
                user.admin = adminValue == Question.OPTION_YES ? true : false;
            }

            // Try to save
            if (userManager.SaveUser(user)) {
                ConsoleHelper.Print(PrintType.Info, "Gebruiker succesvol aangepast.");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon gebruiker niet aanpassen. Errors:");

                // Print errors
                foreach (KeyValuePair<string, List<string>> attribute in user.GetErrors()) {
                    foreach (string error in attribute.Value) {
                        ConsoleHelper.Print(PrintType.Error, attribute.Key + " -> " + error);
                    }
                }
            }
        }

    }

}
