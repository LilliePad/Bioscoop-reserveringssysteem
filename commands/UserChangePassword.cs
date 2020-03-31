using System;
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

        public override string GetUsage() {
            UserService userService = Program.GetInstance().GetService<UserService>("users");
            User currentUser = userService.GetCurrentUser();
            return "user/change-password" + (currentUser != null && currentUser.admin ? " (userId)" : "");
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            User currentUser = userService.GetCurrentUser();

            // Find the user to edit
            User user = currentUser;

            if (currentUser.admin && args.Length == 1) {
                int id = ConsoleHelper.ParseInt(args[0]);
                user = userService.GetUserById(id);

                if (user == null) {
                    throw new ArgumentException("Ongeldige gebruiker");
                }
            }

            // Ask for the current password unless its an admin changing another user
            if (currentUser.id == user.id) {
                string currentPassword = AskQuestion("Wat is het huidige wachtwoord?");

                if (!user.Authenticate(currentPassword)) {
                    throw new ArgumentException("Ongeldig wachtwoord");
                }
            }

            // Ask for the new password
            string newPassword = AskQuestion("Wat moet het nieuwe wachtwoord worden?");
            string confirmNewPassword = AskQuestion("Bevestig het nieuwe wachtwoord");

            // Make sure the new passwords match
            if(newPassword != confirmNewPassword) {
                throw new ArgumentException("Het nieuwe wachtwoord en de bevestiging komen niet overeen");
            }

            // Encrypt and set password
            user.password = EncryptionHelper.CreateHash(newPassword);

            // Try to save
            if (userService.SaveUser(user)) {
                ConsoleHelper.Print(PrintType.Info, "Wachtwoord succesvol aangepast");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon wachtwoord niet aanpassen. Errors:");
                ConsoleHelper.PrintErrors(user);
            }
        }

    }

}
