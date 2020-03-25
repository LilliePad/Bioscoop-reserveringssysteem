using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class MovieEdit : InteractiveCommand {

        public override string GetCategory() {
            return "film";
        }

        public override string GetName() {
            return "edit";
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            MovieManager movieManager = app.GetService<MovieManager>("movies");
           

            // Find the movie to edit
            Movie movie = movieName;

            if(currentUser.admin && args.Length == 1) {
                movie = movieManager.GetMovieByMoviename(args[0]);

                if(movie == null) {
                    throw new Exception("Ongeldige gebruikersnaam");
                }
            }

            // Get input
            movie.movieName = AskQuestion("Wat is uw volledige naam?", null, movie.movieName);
            movie.movieTime= AskQuestion("Welke username wilt u gebruiken?", null, movie.movieTime);

            // Try to save
            if (movieManager.SaveMovie(movie)) {
                ConsoleHelper.Print(PrintType.Info, "Gebruiker succesvol aangepast.");
            } else {
                ConsoleHelper.Print(PrintType.Info, "Kon gebruiker niet aanpassen. Errors:");
                ConsoleHelper.PrintErrors(movie);
            }
        }

    }

}
