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
            string Movie = AskQuestion("Wat is uw volledige naam?");
            string Room = AskQuestion("Welke username wilt u gebruiken?");
            string Time = AskQuestion("welke tijd is de film");


            Show show = new Show(Movie, Room, Time);


  
        }

    }

}
