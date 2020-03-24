using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;
using System;

namespace Project.Commands {

    class UserLogin : Command {

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
            UserService userService = app.GetService<UserService>("users");
            
            // Check args length
            if(args.Length != 2) {
                throw new ArgumentException("Gebruik: user/login <username> <password>");
            }

            // Find user
            User user = userService.GetUserByUsername(args[0]);

            // Error if user or password invalid
            if(user == null || !user.Authenticate(args[1])) {
                throw new ArgumentException("Ongeldige gebruikersnaam en wachtwoord combinatie");
            }

            // Everything ok, login
            userService.SetCurrentUser(user);
            ConsoleHelper.Print(PrintType.Info, "Succesvol ingelogd");
        }

    }

}
