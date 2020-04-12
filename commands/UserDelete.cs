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

        public override string GetUsage() {
            return "user/delete <id>";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");

            // Check args length
            if (args.Length != 1) {
                throw new ArgumentException("Gebruik: " + GetUsage());
            }

            // Find room
            int id = ConsoleHelper.ParseInt(args[0], "id");
            User user = userService.GetUserById(id);

            if (user == null) {
                throw new ArgumentException("Ongeldige gebruiker");
            }

            // Try to delete
            if (userService.DeleteUser(user)) {
                ConsoleHelper.Print(PrintType.Info, "Gebruiker succesvol verwijderd");
            } else {
                ConsoleHelper.Print(PrintType.Error, "Kon gebruiker niet verwijderen");
            }
        }

    }

}
