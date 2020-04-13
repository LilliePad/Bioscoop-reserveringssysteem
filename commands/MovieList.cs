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
            MovieManager movieManager = app.GetService<MovieManager>("movies");

            ConsoleHelper.Print(PrintType.Info, "movie list (id - film - duur - genre):");

            // Print movies
            foreach(Movie movie in movieManager.GetMovies()) {
                ConsoleHelper.Print(PrintType.Info, movie.id + " - " + movie.name + " - " + movie.time + " - " + movie.genre);
            }
        }

    }

}
