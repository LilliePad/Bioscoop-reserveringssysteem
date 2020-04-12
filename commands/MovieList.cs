using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class MovieList : Command {

        public override string GetCategory() {
            return "movie";
        }

        public override string GetName() {
            return "list";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            MovieService movieManager = app.GetService<MovieService>("movies");

            ConsoleHelper.Print(PrintType.Info, "Movie list (id - film - genre - duur):");

            // Print movies
            foreach(Movie movie in movieManager.GetMovies()) {
                ConsoleHelper.Print(PrintType.Info, movie.id + " - " + movie.name + " - " + movie.genre + " - " + movie.duration);
            }
        }

    }

}
