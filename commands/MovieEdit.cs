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

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            MovieManager movieManager = app.GetService<MovieManager>("movies");

            // find movie
            if (args.Length != 1) {
                throw new ArgumentException("ongeldig film");
            }

            int movieId = ConsoleHelper.ParseInt(args[0]);

            Movie movie = movieManager.GetMovieById(movieId);

            if (movie == null) {
                throw new ArgumentException("ongeldig film");
            }

            // Get input
            movie.name = AskQuestion("Wat is de films voledige naam?", null, movie.name);
            movie.time= AskQuestion("Hoe lang gaat de film duren?", null, movie.time);
            movie.time = AskQuestion("voor welke leeftijd is het?", null, movie.genre);
            // Try to save
            if (movieManager.SaveMovie(movie)) {
                ConsoleHelper.Print(PrintType.Info, "film succesvol aangepast.");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon film niet aanpassen. Errors:");
                ConsoleHelper.PrintErrors(movie);
            }
        }

    }

}
