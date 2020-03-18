using System.Collections.Generic;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;


namespace Project.Commands {

    class MovieCreate : InteractiveCommand {

        public override string GetCategory() {
            return "film";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override string GetName() {
            return "create";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            MovieManager movieManager = app.GetService<MovieManager>("movies");
            Movie currentMvoie = movieManager.GetCurrentMovie();

            // Get input
            string movieName = AskQuestion("Wat is uw film naam?");
            string minage = AskQuestion("leeftijdsclassificatie?");
            string time = AskQuestion("hoe lang duurt de film?");
            
            // Try to registers
            Movie movie = new movie(movieName, minage, time);

            // Login if registration successful
            if (movieManager.SaveMovie(movie)) {
                movieManager.SetCurrentMovie(movie);
                ConsoleHelper.Print(PrintType.Info, "Film succesvol aangemaakt.");
            }
            else {
                ConsoleHelper.Print(PrintType.Info, "Kon film niet aanmaken. Errors:");

                // Print errors
                foreach (KeyValuePair<string, List<string>> attribute in movies.GetErrors()) {
                    foreach (string error in attribute.Value) {
                        ConsoleHelper.Print(PrintType.Error, attribute.Key + " -> " + error);
                    }

                }

            }

        }

    }

}
