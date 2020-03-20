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

        // Current user (logged in user)
        private User currentUser;

        public override string getHandle() {
            return "users";
        }

        public override void Load() {
            database = new ChairDatabase();

            ConsoleHelper.Print(PrintType.Info, "Loading user database...");

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

        // Returns current user
        public User GetCurrentUser() {
            return currentUser;
        }

        // Sets the current user
        public void SetCurrentUser(User currentUser) {
            this.currentUser = currentUser;
        }

    }

}
