using Project.Base;
using Project.Helpers;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class Movie : Model {

        public int id = -1;
        public string movieName;
        public string movieTime;
        public string genre;

        public Movie(MovieRecord record) {
            this.id = record.id;
            this.movieName = record.movieName;
            this.movieTime = record.movieTime;
            this.genre = record.genre;
        }

        public Movie(string movieName, string movieTime, string genre) {
            this.movieName = movieName;
            this.movieTime = movieTime;
            this.genre = genre;
        }

        private Movie(int id, string movieName, string movieTime, string genre) {
            this.id = id;
            this.movieName = movieName;
            this.movieTime = movieTime;
            this.genre = genre;
        }

        public override bool Validate() {
            MovieManager movieManager = Program.GetInstance().GetService<MovieManager>("films");

            if (movieName == null || movieName.Length == 0) {
                this.AddError("movieName", "titel mag niet leeg zijn.");
                return false;
            }

            if (movieTime == null || movieTime.Length == 0) {
                this.AddError("movieTime", "moveTime mag niet leeg zijn.");
                return false;
            }

            if (genre == null || genre.Length == 0) {
                this.AddError("genre", "genre mag niet leeg zijn.");
                return false;
            }

            return true;
        }

    }

}
