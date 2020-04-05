using System;
using Project.Base;
using Project.Commands.Validation;
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

        public override string GetUsage() {
            UserService userService = Program.GetInstance().GetService<UserService>("users");
            User currentUser = userService.GetCurrentUser();
            return "user/edit" + (currentUser != null && currentUser.admin ? " (userId)" : "");
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            User currentUser = userService.GetCurrentUser();

            // Find the user to edit
            User user = currentUser;

            if(currentUser.admin && args.Length == 1) {
                int id = ConsoleHelper.ParseInt(args[0]);
                user = userService.GetUserById(id);

                if(user == null) {
                    throw new Exception("Ongeldige gebruiker");
                }
            }

            // Get input
            user.fullName = AskQuestion("Wat is uw volledige naam?", null, user.fullName);
            user.username = AskQuestion("Welke username wilt u gebruiken?", null, user.username);

            // Get extra input if the current user is an admin
            if (currentUser.admin) {
                string adminValue = AskQuestion("Moet deze gebruiker een admin worden?", new BooleanValidator(), user.admin ? "ja" : "nee");
                user.admin = ConsoleHelper.ParseBoolean(adminValue);
            }

            // Try to save
            if (userService.SaveUser(user)) {
                ConsoleHelper.Print(PrintType.Info, "Gebruiker succesvol aangepast");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon gebruiker niet aanpassen. Errors:");
                ConsoleHelper.PrintErrors(user);
            }
        }

    }

}
