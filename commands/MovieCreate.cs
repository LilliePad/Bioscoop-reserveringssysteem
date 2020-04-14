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

        public override string GetName() {
            return "create";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            MovieService movieManager = app.GetService<MovieService>("movies");

            // Get input
            string name = AskQuestion("Wat is de naam?");
            string genre = AskQuestion("Wat is het genre?");
            int duration = ConsoleHelper.ParseInt(AskQuestion("Hoelang duurt de film in minuten?"));

            // Create show model
            Movie movie = new Movie(name, genre, duration);

            // Try to save
            if (movieManager.SaveMovie(movie)) {
                ConsoleHelper.Print(PrintType.Info, "Film succesvol aangemaakt.");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon film niet aanmaken. Errors:");
                ConsoleHelper.PrintErrors(movie);
            }
        }

    }

}
