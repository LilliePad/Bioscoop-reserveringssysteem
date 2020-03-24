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
            UserService userService = app.GetService<UserService>("users");
            User currentUser = userService.GetCurrentUser();

            // Get input
            string fullName = AskQuestion("Wat is uw volledige naam?");
            string username = AskQuestion("Welke username wilt u gebruiken?");
            string password = AskQuestion("Welk wachtwoord wilt u gebruiken?");
            bool admin = false;

            // Get extra input if the user is an admin
            if(currentUser != null && currentUser.admin) {
                string adminValue = AskQuestion("Moet deze gebruiker een admin worden?", Question.OPTIONS_BOOL, Question.OPTION_NO);
                admin = ConsoleHelper.ParseBoolean(adminValue);
            }

            // Try to register
            string hashedPassword = EncryptionHelper.CreateHash(password);
            User user = new User(fullName, username, hashedPassword, admin);

            // Login if registration successful
            if (userService.SaveUser(user)) {
                userService.SetCurrentUser(user);
                ConsoleHelper.Print(PrintType.Info, "Gebruiker succesvol aangemaakt en ingelogd");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon gebruiker niet aanmaken. Errors:");
                ConsoleHelper.PrintErrors(user);
            }
        }

    }

}
