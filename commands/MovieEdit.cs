using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class MovieEdit : InteractiveCommand {

        public override string GetCategory() {
            return "movie";
        }

        public override string GetName() {
            return "edit";
        }

        public override string GetUsage() {
            return "movie/edit <id>";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            MovieService movieManager = app.GetService<MovieService>("movies");

            // Check args length
            if (args.Length != 1) {
                throw new ArgumentException("Gebruik: " + GetUsage());
            }

            // Find movie
            int movieId = ConsoleHelper.ParseInt(args[0]);
            Movie movie = movieManager.GetMovieById(movieId);

            if (movie == null) {
                throw new ArgumentException("Ongeldig film");
            }

            // Get input
            movie.name = AskQuestion("Wat is de naam?", null, movie.name);
            movie.genre = AskQuestion("Wat is het genre?", null, movie.genre);
            movie.duration = ConsoleHelper.ParseInt(AskQuestion("Hoelang duurt de film in minuten?", null, movie.duration.ToString()), "duration");

            // Try to save
            if (movieManager.SaveMovie(movie)) {
                ConsoleHelper.Print(PrintType.Info, "Film succesvol aangepast");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon film niet aanpassen. Errors:");
                ConsoleHelper.PrintErrors(movie);
            }
        }

    }

}
