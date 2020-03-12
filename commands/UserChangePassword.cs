using System;
using System.Collections.Generic;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;


namespace Project.Commands {

    class UserChangePassword : InteractiveCommand {

        public override string GetCategory() {
            return "user";
        }

        public override string GetName() {
            return "change-password";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserManager userManager = app.GetService<UserManager>("users");
            User currentUser = userManager.GetCurrentUser();

            // Find the user to edit
            User user = currentUser;

            if (currentUser.admin && args.Length == 1) {
                user = userManager.GetUserByUsername(args[0]);

                if (user == null) {
                    throw new Exception("Ongeldige gebruikersnaam");
                }
            }

            // Ask for the current password unless its an admin changing another user
            if (currentUser.id == user.id) {
                string currentPassword = AskQuestion("Wat is het huidige wachtwoord?");

                if (!user.Authenticate(currentPassword)) {
                    ConsoleHelper.Print(PrintType.Error, "Ongeldig wachtwoord.");
                    return;
                }
            }

            // Ask for the new password
            string newPassword = AskQuestion("Wat moet het nieuwe wachtwoord worden?");
            string confirmNewPassword = AskQuestion("Bevestig het nieuwe wachtwoord.");

            // Make sure the new passwords match
            if(newPassword != confirmNewPassword) {
                ConsoleHelper.Print(PrintType.Error, "Het nieuwe wachtwoord en de bevestiging komen niet overeen.");
                return;
            }

            // Encrypt and set password
            user.password = EncryptionHelper.CreateHash(newPassword);

            // Try to save
            if (userManager.SaveUser(user)) {
                ConsoleHelper.Print(PrintType.Info, "Wachtwoord succesvol aangepast.");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon wachtwoord niet aanpassen. Errors:");
            }
        }

    }

}
