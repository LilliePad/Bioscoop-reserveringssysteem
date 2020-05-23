using System;
using System.Collections.Generic;
using System.Linq;
using Project.Base;
using Project.Data;
using Project.Models;
using Project.Records;

namespace Project.Services {

    class MovieService : Service {

        public override string GetHandle() {
            return "movies";
        }

        // Returns all movies
        public List<Movie> GetMovies() {
            Database database = Program.GetInstance().GetDatabase();
            List<Movie> models = new List<Movie>();

            foreach (MovieRecord record in database.movies) {
                models.Add(new Movie(record));
            }

            return models;
        }

        // Returns a movie by its id
        public Movie GetMovieById(int id) {
            Database database = Program.GetInstance().GetDatabase();

            try {
                return new Movie(database.movies.Where(i => i.id == id).First());
            } catch (InvalidOperationException) {
                return null;
            }
        }

        // Saves the specified movie
        public bool SaveMovie(Movie movie) {
            Database database = Program.GetInstance().GetDatabase();
            bool isNew = movie.id == -1;

            // Validate and add if valid
            if (!movie.Validate()) {
                return false;
            }

            // Set id if its a new movie
            if (isNew) {
                movie.id = database.GetNewId("movies");
            }

            // Find existing record
            MovieRecord record = database.movies.SingleOrDefault(i => i.id == movie.id);

            // Add if no record exists
            if (record == null) {
                record = new MovieRecord();
                database.movies.Add(record);
            }

            // Update record
            record.id = movie.id;
            record.name = movie.name;
            record.duration = movie.duration;
            record.genre = movie.genre;
            record.image = movie.image;

            // Try to save
            database.TryToSave();

            return true;
        }

        // Deletes the specified movie
        public bool DeleteMovie(Movie movie) {
            Program app = Program.GetInstance();
            Database database = app.GetDatabase();
            ShowService showService = app.GetService<ShowService>("shows");

            // Find record
            MovieRecord record = database.movies.SingleOrDefault(i => i.id == movie.id);

            if (record == null) {
                return false;
            }

            // Remove record
            database.movies.Remove(record);

            // Remove related shows
            foreach (Show show in showService.GetShowsByMovie(movie)) {
                showService.DeleteShow(show);
            }

            // Try to save
            database.TryToSave();

            return true;
        }

    }
}
