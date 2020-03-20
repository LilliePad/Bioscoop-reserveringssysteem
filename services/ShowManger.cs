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

    class ShowManager : Service {

        // Database
        private ShowDatabase database;

        
        public override string getHandle() {
            return "shows";
        }

        public override void Load() {
            database = new ShowDatabase();

            ConsoleHelper.Print(PrintType.Info, "Loading user database...");

            // Try to load
            if (!database.Load()) {
                ConsoleHelper.Print(PrintType.Error, "Failed to load users");
                return;
            }

            ConsoleHelper.Print(PrintType.Info, "Loaded user database.");


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

        // Returns all shows
        public List<Show> GetShows() {
            List<Show> models = new List<Show>();

            foreach(ShowRecord record in database.shows){
                models.Add(new Show(record));
            }

            return models;
        }

        

        // Saves the specified user
        public bool SaveShow(Show show) {
            bool isNew = show.id == -1;

            // Set id if its a new user
            if (isNew) {
                show.id = database.GetNewId("shows");
            }


            // Find existing record
            ShowRecord record = database.shows.SingleOrDefault(i => i.id == show.id);
            
            // Add if no record exists
            if(record == null) {
                record = new ShowRecord();
                database.shows.Add(record);
            }

            // Update record
            record.id = show.id;
            record.Movie = show.Movie;
            record.Room = show.Room;
            record.Time = show.Time;
  

            return true;
        }
    }

}
