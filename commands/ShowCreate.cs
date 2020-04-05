using System.Collections.Generic;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

using System;
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
            string Date = AskQuestion("wat is de datum van de film      (dd-MM-yyyy) ");
            string Time = AskQuestion("op welke tijd begint de film     (HH:mm)");
            
            //convert input into right type
            int RoomId = int.Parse(RoomIdstring);
            string dateWithTime = Date + " " + Time;
            DateTime dateTimeShow = DateTime.ParseExact(dateWithTime, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            



            // Try to register
            Show show = new Show(Movie, RoomId, dateTimeShow);

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