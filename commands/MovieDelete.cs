using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;
using System;

namespace Project.Commands {

    class MovieDelete : Command {

        public override string GetCategory() {
            return "movie";
        }

        public override string GetName() {
            return "delete";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            MovieManager movieManager = app.GetService<MovieManager>("movies");

            // Check args length
            if (args.Length != 1) {
                ConsoleHelper.Print(PrintType.Error, "Usage: movie/delete <id>");
                return;
            }

            // Find room
            int id = ConsoleHelper.ParseInt(args[0], "id");
            Movie movie = movieManager.GetMovieById(id);

            if (movie == null) {
                throw new ArgumentException("id moet een bestaand film-id zijn.");
            }

            if (movieManager.DeleteMovie(movie)) {
                ConsoleHelper.Print(PrintType.Info, "film succesvol verwijderd.");
            } else {
                ConsoleHelper.Print(PrintType.Error, "Kon film niet verwijderen.");
            }
        }

    }

}
