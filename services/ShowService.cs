using System;
using System.Collections.Generic;
using System.Linq;
using Project.Base;
using Project.Data;
using Project.Models;
using Project.Records;

namespace Project.Services {

    class ShowService : Service {

        public override string GetHandle() {
            return "shows";
        }

        // Returns all shows
        public List<Show> GetShows() {
            Database database = Program.GetInstance().GetDatabase();
            List<Show> models = new List<Show>();

            foreach (ShowRecord record in database.shows) {
                models.Add(new Show(record));
            }

            return models;
        }

        // Returns a show by its id
        public Show GetShowById(int id) {
            Database database = Program.GetInstance().GetDatabase();

            try {
                return new Show(database.shows.Where(i => i.id == id).First());
            } catch (InvalidOperationException) {
                return null;
            }
        }

        // Returns all shows by its movie
        public List<Show> GetShowsByMovie(Movie movie) {
            Database database = Program.GetInstance().GetDatabase();
            List<Show> models = new List<Show>();

            // Find records
            IEnumerable<ShowRecord> records = database.shows.Where(i => i.movieId == movie.id);

            // Create models
            foreach (ShowRecord record in records) {
                models.Add(new Show(record));
            }

            return models;
        }

        // Returns all shows by its room
        public List<Show> GetShowsByRoom(Room room) {
            Database database = Program.GetInstance().GetDatabase();
            List<Show> models = new List<Show>();

            // Find records
            IEnumerable<ShowRecord> records = database.shows.Where(i => i.roomId == room.id);

            // Create models
            foreach (ShowRecord record in records) {
                models.Add(new Show(record));
            }

            return models;
        }

        // Saves the specified room
        public bool SaveShow(Show show) {
            Program app = Program.GetInstance();
            Database database = app.GetDatabase();
            bool isNew = show.id == -1;

            // Validate show
            if (!show.Validate()) {
                return false;
            }

            // Set id if its a new show
            if (isNew) {
                show.id = database.GetNewId("shows");
            }

            // Find existing record
            ShowRecord record = database.shows.SingleOrDefault(i => i.id == show.id);

            // Add if no record exists
            if (record == null) {
                record = new ShowRecord();
                database.shows.Add(record);
            }

            // Update record
            record.id = show.id;
            record.roomId = show.roomId;
            record.movieId = show.movieId;
            record.startTime = show.startTime;

            // Try to save
            database.TryToSave();

            return true;
        }

        // Deletes the specified room
        public bool DeleteShow(Show show) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            Database database = app.GetDatabase();

            // Find record
            ShowRecord record = database.shows.SingleOrDefault(i => i.id == show.id);

            if (record == null) {
                return false;
            }

            // Remove record and related reservations
            database.shows.Remove(record);

            foreach (Reservation reservation in reservationService.GetReservationsByShow(show)) {
                reservationService.DeleteReservation(reservation);
            }

            // Try to save
            database.TryToSave();

            return true;
        }

    }

}



