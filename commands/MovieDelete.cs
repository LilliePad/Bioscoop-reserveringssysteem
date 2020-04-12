using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class MovieDelete : Command {

        public override string GetCategory() {
            return "movie";
        }

        public override string GetName() {
            return "delete";
        }

        public override string GetUsage() {
            return "movie/delete <id>";
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
            int id = ConsoleHelper.ParseInt(args[0], "id");
            Movie movie = movieManager.GetMovieById(id);

            if (movie == null) {
                throw new ArgumentException("Ongeldige film");
            }

            // Try to delete
            if (movieManager.DeleteMovie(movie)) {
                ConsoleHelper.Print(PrintType.Info, "film succesvol verwijderd");
            } else {
                ConsoleHelper.Print(PrintType.Error, "Kon film niet verwijderen");
            }
        }

    }

}
