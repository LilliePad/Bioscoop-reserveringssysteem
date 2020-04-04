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
            return false;
        }

        public override string GetName() {
            return "create";
        }
        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");


            // Get input
            string Movie = AskQuestion("wat is de naam van de film");
            string RoomIdstring = AskQuestion("in welke room speelt de film");
            string DateTime = AskQuestion("wat is de datum van de film");


            int RoomId = int.Parse(RoomIdstring);
            
            



            // Try to register
            Show show = new Show(Movie, RoomId, DateTime);

            // Login if registration successful
            if (showService.SaveShow(show)) {
                ConsoleHelper.Print(PrintType.Info, "show succesvol aangemaakt.");
            }
            else {
                ConsoleHelper.Print(PrintType.Info, "Kon show niet aanmaken. Errors:");
            }
        }
  

    }

}