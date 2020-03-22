using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;
using System;

namespace Project.Commands {

    class UserDelete : Command {

        public override string GetCategory() {
            return "user";
        }

        public override string GetName() {
            return "delete";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserManager userManager = app.GetService<UserManager>("users");

            // Check args length
            if (args.Length != 1) {
                ConsoleHelper.Print(PrintType.Error, "Usage: user/delete <id>");
                return;
            }

            // Find room
            int id = ConsoleHelper.ParseInt(args[0], "id");
            User user = userManager.GetUserById(id);

            if (user == null) {
                throw new ArgumentException("id moet een bestaand gebruiker-id zijn.");
            }

            if (userManager.DeleteUser(user)) {
                ConsoleHelper.Print(PrintType.Info, "Gebruiker succesvol verwijderd.");
            } else {
                ConsoleHelper.Print(PrintType.Error, "Kon gebruiker niet verwijderen.");
            }
        }

    }

}
