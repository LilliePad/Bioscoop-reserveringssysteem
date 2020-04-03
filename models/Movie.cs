using Project.Base;
using Project.Helpers;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class Movie : Model {

        public int id = -1;
        public string name;
        public string time;
        public string genre;

        public Movie(MovieRecord record) {
            this.id = record.id;
            this.name = record.name;
            this.time = record.time;
            this.genre = record.genre;
        }

        public Movie(string movieName, string movieTime, string genre) {
            this.name = movieName;
            this.time = movieTime;
            this.genre = genre;
        }

        private Movie(int id, string name, string time, string genre) {
            this.id = id;
            this.name = name;
            this.time = time;
            this.genre = genre;
        }

        public override bool Validate() {
            MovieManager movieManager = Program.GetInstance().GetService<MovieManager>("films");

            if (name == null || name.Length == 0) {
                this.AddError("movieName", "titel mag niet leeg zijn.");
                return false;
            }

            if (time == null || time.Length == 0) {
                this.AddError("time", "moveTime mag niet leeg zijn.");
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
