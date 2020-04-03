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

    class ShowSerice : Service {

        // Database
        private ShowDatabase database;

        
        public override string getHandle() {
            return "shows";
        }

        // Returns all shows
        public List<Show> GetShows() {
            List<Show> models = new List<Show>();

            foreach (ShowRecord record in database.shows) {
                models.Add(new Show(record));
            }

            return models;
        }

        // Returns a show by its id
        public Show GetRoomById(int id) {
            Database database = Program.GetInstance().GetDatabase();

            try {
                return new Show(database.shows.Where(i => i.id == id).First());
            }
            catch (InvalidOperationException) {
                return null;
            }
                // Saves the specified room
                public bool SaveShow(Show show) {
                Program app  = Program.GetInstance();
                Database database = app.GetDatabase();
                bool isNew = show.id == -1;

                // Validate and add if valid
                if (!show.Validate()) {
                    return false;
                }

                // Set id if its a new room
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
                record.DateTime = show.DateTime;
                record.Movie = show.Movie;

                // Try to save
                database.TryToSave();

                return true;
            }

            // Deletes the specified room
            public bool DeleteShow(Show show) {
                Program app = Program.GetInstance();
                Database database = app.GetDatabase();
                ShowRecord record = database.shows.SingleOrDefault(i => i.id == show.id);

                // Return false if room doesn't exist
                if (record == null) {
                    return false;
                }

                // Remove record and chairs
                database.shows.Remove(record);
                 // Try to save
                 database.TryToSave();

                return true;

    }


