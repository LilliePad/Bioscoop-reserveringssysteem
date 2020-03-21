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

    class ChairManager : Service {

        // Database
        private ChairDatabase database;


        public override string getHandle() {
            return "chairs";
        }

        public override void Load() {
            database = new ChairDatabase();
            if (!database.Load()) {
                ConsoleHelper.Print(PrintType.Error, "Failed to load chair database.");
                return;
            }
            ConsoleHelper.Print(PrintType.Info, "Loading chair database");
        }

        public override void Unload() {
            ConsoleHelper.Print(PrintType.Info, "Saving chair database...");

            // Try to save
            if (!database.Save()) {
                ConsoleHelper.Print(PrintType.Error, "Failed to save chair database.");
                return;
            }

            ConsoleHelper.Print(PrintType.Info, "Saved chair database.");
        }

        public List<Chair> GetChairs() {
            List<Chair> models = new List<Chair>();

            foreach (ChairRecord record in database.chairs) {
                models.Add(new Chair(record));
            }

            return models;
        }

        // Saves the specified user
        public bool SaveChair(Chair chair) {
            bool isNew = chair.id == -1;

            // Set id if its a new user
            if (isNew) {
                chair.id = database.GetNewId("Chairs");
            }

            // Validate and add if valid
            if (!chair.Validate()) {
                return false;
            }

            // Find existing record
            ChairRecord record = database.chairs.SingleOrDefault(i => i.id == chair.id);

            // Add if no record exists
            if (record == null) {
                record = new ChairRecord();
                database.chairs.Add(record);
            }


            // Update record
            record.id = chair.id;
            record.row = chair.row;
            record.number = chair.number;
            record.price = chair.price;
            record.type = chair.type;

            return true;
        }


    }

}
