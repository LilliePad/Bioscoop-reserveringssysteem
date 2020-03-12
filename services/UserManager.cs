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

    class UserManager : Service {

        // Database
        private UserDatabase database;

        // Current user (logged in user)
        private User currentUser;

        public override string getHandle() {
            return "users";
        }

        public override void Load() {
            database = new UserDatabase();

            ConsoleHelper.Print(PrintType.Info, "Loading user database...");

            // Try to load
            if (!database.Load()) {
                ConsoleHelper.Print(PrintType.Error, "Failed to load users");
                return;
            }

            ConsoleHelper.Print(PrintType.Info, "Loaded user database.");

            // Creating default user if we need to
            if (database.users.Count == 0) {
                User admin = new User("Admin user", "admin", EncryptionHelper.CreateHash("admin"), true);

                if (!this.SaveUser(admin)) {
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
        public List<User> GetUsers() {
            List<User> models = new List<User>();

            foreach(UserRecord record in database.users) {
                models.Add(new User(record));
            }

            return models;
        }

        // Returns a user by its username
        public User GetUserByUsername(string username) {
            try {
                return GetUsers().Where(i => i.username.Equals(username)).First();
            } catch(InvalidOperationException) {
                return null;
            }
        }

        // Saves the specified user
        public bool SaveUser(User user) {
            bool isNew = user.id == -1;

            // Set id if its a new user
            if (isNew) {
                user.id = database.GetNewId("users");
            }

            // Validate and add if valid
            if(!user.Validate()) {
                return false;
            }

            // Find and remove existing object
            UserRecord current = database.users.SingleOrDefault(i => i.id == user.id);
            database.users.Remove(current);

            // Add new object
            database.users.Add(new UserRecord(user));

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
