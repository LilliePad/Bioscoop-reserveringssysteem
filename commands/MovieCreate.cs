using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;


namespace Project.Commands {

    class MovieCreate : InteractiveCommand {

        public override string GetCategory() {
            return "movie";
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

            // Get input
            string movieName = AskQuestion("Wat is uw film naam?");
            string movieTime = AskQuestion("leeftijdsclassificatie?");
            string genre = AskQuestion("hoe lang duurt de film?");
            
            // Try to registers
            Movie movie = new Movie(movieName, movieTime, genre);

            // Login if registration successful
            if (movieManager.SaveMovie(movie)) {
                ConsoleHelper.Print(PrintType.Info, "Film succesvol aangemaakt.");
            }
            else {
                ConsoleHelper.Print(PrintType.Info, "Kon film niet aanmaken. Errors:");

                // Print errors
                ConsoleHelper.PrintErrors(movie);
            }

          }

       }

    }
