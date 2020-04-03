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
        private MovieDatabase database;

        public override string getHandle() {
            return "movies";
        }

        public override void Load() {
            database = new MovieDatabase();

            ConsoleHelper.Print(PrintType.Info, "Loading movie database...");

            // Try to load
            if (!database.Load()) {
                ConsoleHelper.Print(PrintType.Error, "Failed to load movie");
                return;
            }

            ConsoleHelper.Print(PrintType.Info, "Loaded movie database.");


            }
        

        public override void Unload() {
            ConsoleHelper.Print(PrintType.Info, "Saving movie database...");

            // Try to save
            if (!database.Save()) {
                ConsoleHelper.Print(PrintType.Error, "Failed to save movie database.");
                return;
            }

            ConsoleHelper.Print(PrintType.Info, "Saved movie database.");
        }

        // Returns all movies
        public List<Movie> GetMovies() {
            List<Movie> models = new List<Movie>();

            foreach (MovieRecord record in database.movies) {
                models.Add(new Movie(record));
            }

            return models;
        }
        // Returns a movie by its id
        public Movie GetMovieById(int id) {
            try {
                return GetMovies().Where(i => i.id == id).First();
            }
            catch (InvalidOperationException) {
                return null;

            }
        }

                // Returns a movie by its moveName
                 public Movie GetMovieByMoviename(string movieName) {
                    try {
                        return GetMovies().Where(i => i.time.Equals(movieName)).First();
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
                    MovieRecord record = database.movies.SingleOrDefault(i => i.id == movie.id);

                    // Add if no record exists
                    if (record == null) {
                        record = new MovieRecord();
                        database.movies.Add(record);
                    }

                    // Update record
                    record.id = movie.id;
                    record.name = movie.name;
                    record.time = movie.time;
                    record.genre = movie.genre;

                    return true;
                }

                // Deletes the specified user
                 public bool DeleteMovie(Movie movie) {
                    MovieRecord record = database.movies.SingleOrDefault(i => i.id == movie.id);

                // Return false if room doesn't exist
                if (record == null) {
                    return false;
                }

                // Remove record
                database.movies.Remove(record);

                // Try to save
                database.TryToSave();

                return true;

        }
            }
        }
