using System;
using System.Collections.Generic;
using System.Linq;
using Project.Base;
using Project.Data;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Records;

namespace Project.Services {

    class MovieManager : Service {

        // Database
        private MovieManager database;

        public override string getHandle() {
            return "movies";
        }

        public override void Load() {
            database = new MovieDatabase();

            ConsoleHelper.Print(PrintType.Info, "Loading movie database...");

            // Try to load
            if (!database.Load()) {
                ConsoleHelper.Print(PrintType.Error, "Failed to load movies");
                return;
            }

            ConsoleHelper.Print(PrintType.Info, "Loaded user database.");

            // Creating default user if we need to
            if (database.movies.Count == 0) {
                User admin = new User("Admin user", "admin", EncryptionHelper.CreateHash("admin"), true);

                if (!this.SaveMovies(admin)) {
                    ConsoleHelper.Print(PrintType.Error, "Failed to create default user");
                    return;
                }

                this.SetCurrentUser(admin);
                ConsoleHelper.Print(PrintType.Warning, "Created default admin user, please configure it.");
            }
        }

        public override void Unload() {
            ConsoleHelper.Print(PrintType.Info, "Saving user database...");

            // Try to save
            if (!database.Save()) {
                ConsoleHelper.Print(PrintType.Error, "Failed to save user database.");
                return;
            }

            ConsoleHelper.Print(PrintType.Info, "Saved user database.");
        }

        // Returns all users
        public List<Movie> GetUsers() {
            List<Movie> models = new List<Movie>();

            foreach (MovieRecord record in database.movies) {
                models.Add(new Movie(record));
            }

            return models;
        }

        // Returns a user by its username
        public Movie GetMovieByMoviename(string movieName) {
            try {
                return GetMovies().Where(i => i.movieTime.Equals(movieName)).First();
            }
            catch (InvalidOperationException) {
                return null;
            }
        }

        // Saves the specified movie
        public bool SaveMovie(Movie movie) {
            bool isNew = movie.id == -1;

            // Set id if its a new movie
            if (isNew) {
                movie.id = database.GetNewId("movies");
            }

            // Validate and add if valid
            if (!movie.Validate()) {
                return false;
            }

            // Find existing record
            UserRecord record = database.movies.SingleOrDefault(i => i.id == movie.id);

            // Add if no record exists
            if (record == null) {
                record = new movieRecord();
                database.movies.Add(record);
            }

            // Update record
            record.id = movie.id;
            record.movieName = movie.movieName;
            record.movieTime = movie.movieTime;
            record.genre = movie.genre;

            return true;
        }

        // Returns current user
        public Movie GetCurrentUser() {
            return currentMovie;
        }
        
        // Sets the current user
        public void SetCurrentUser(Movie currentmovie) {
            this.currentMovie = currentMovie;
        }

    }

}
