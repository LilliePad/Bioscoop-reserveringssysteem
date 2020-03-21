using Project.Base;
using Project.Helpers;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class Movie : Model {

        public int id = -1;s
        public string movieName;
        public string minage;
        public string time;
        public bool admin;

        public Movie(UserRecord record) {
            this.id = record.id;
            this.movieName = record.movieName;
            this.minage = record.minage;
            this.time = record.time;
        }

        public Movie(string movieName, string minage, string time) {
            this.movieName = movieName;
            this.minage = minage;
            this.time = time;
        }

        private Movie(int id, string movieName, string minage, string time) {
            this.id = id;
            this.movieName = movieName;
            this.minage = username;
            this.time = time;
        }

        public override bool Validate() {
            MovieManager movieManager = Program.GetInstance().GetService<MovieManager>("users");

            if (movieName == null || movieName.Length == 0) {
                this.AddError("fullName", "Volledige naam mag niet leeg zijn.");
                return false;
            }

            if (minage == null || minage.Length == 0) {
                this.AddError("username", "Username mag niet leeg zijn.");
                return false;
            }

            User existing = movieManager.GetMovieByMoviename(movieName);

            if (existing != null && existing.id != id) {
                this.AddError("moviename", "FIlm is al in gebruik.");
                return false;
            }

            if (time == null || time.Length == 0) {
                this.AddError("time", "Wachtwoord mag niet leeg zijn.");
                return false;
            }

            return true;
        }

        // Returns whether the specified password is correct
        public bool Authenticate(string password) {
            string hash = EncryptionHelper.CreateHash(password);
            return this.time.Equals(hash);
        }

    }

}
