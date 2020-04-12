using System;
using Project.Base;
using Project.Commands.Validation;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class ShowCreate : InteractiveCommand {

        public override string GetCategory() {
            return "show";
        }

        public override string GetName() {
            return "create";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");

            // Get input
            int movieId = ConsoleHelper.ParseInt(AskQuestion("Wat is de id van de film?"));
            int roomId = ConsoleHelper.ParseInt(AskQuestion("Wat is de id van de zaal?"));
            string date = AskQuestion("Wat is de datum van de film?", new DateValidator());
            string time = AskQuestion("Op welke tijd begint de film?", new TimeValidator());
            DateTime dateTime = ConsoleHelper.ParseDatetime(date, time);
            
            // Create show model
            Show show = new Show(movieId, roomId, dateTime);

            // Try to save
            if (showService.SaveShow(show)) {
                ConsoleHelper.Print(PrintType.Info, "Show succesvol aangemaakt");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon show niet aanmaken. Errors:");
                ConsoleHelper.PrintErrors(show);
            }
        }

    }
}