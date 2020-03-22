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
            string Movie = AskQuestion("wat is de naam van de film");
            string Room = AskQuestion("wat is de room");
            string Time = AskQuestion("welke tijd is de film");


            // Try to register
            Show show = new Show(Movie, Room, Time);

            // Login if registration successful
            if (showManager.SaveShow(show)) {
                ConsoleHelper.Print(PrintType.Info, "show succesvol aangemaakt.");
            }
            else {
                ConsoleHelper.Print(PrintType.Info, "Kon show niet aanmaken. Errors:");
            }
        }
    }

}
