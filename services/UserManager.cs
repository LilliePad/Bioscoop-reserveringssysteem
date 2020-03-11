using System;
using System.Collections.Generic;
using System.Linq;
using Project.Base;
using Project.Data;
using Project.Enums;
using Project.Helpers;
using Project.Models;

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
                User admin = this.RegisterUser("Admin user", "admin", "admin", true);

                if (admin == null) {
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
            return database.users;
        }

        // Returns a user by its username
        public User GetUserByUsername(string username) {
            try {
                return GetUsers().Where(user => user.username.Equals(username)).First();
            } catch(InvalidOperationException) {
                return null;
            }
        }

        // Tries to create a new user with the specified params 
        public User RegisterUser(string fullName, string username, string password, bool admin) {
            int id = database.GetNewId("users");
            string hashedPassword = EncryptionHelper.CreateHash(password);
            User user = new User(id, fullName, username, hashedPassword, admin);

            // Validate and add if valid
            if(user.Validate()) {
                database.users.Add(user);
            }

            // Return user
            return user;
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
