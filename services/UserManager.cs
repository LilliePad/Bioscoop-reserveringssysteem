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

        // Current user
        private User currentUser;

        public override string getHandle() {
            return "users";
        }

        public override void Load() {
            database = new UserDatabase();

            LogHelper.Log(LogType.Info, "Loading user database...");

            // Try to load
            if (!database.Load()) {
                LogHelper.Log(LogType.Error, "Failed to load users");
                return;
            }

            LogHelper.Log(LogType.Info, "Loaded user database.");
        }

        public override void Unload() {
            LogHelper.Log(LogType.Info, "Saving user database...");

            // Try to save
            if (!database.Save()) {
                LogHelper.Log(LogType.Error, "Failed to save user database.");
                return;
            }

            LogHelper.Log(LogType.Info, "Saved user database.");
        }

        public IList<User> GetUsers() {
            return database.users;
        }

        public User GetUserByUsername(string username) {
            try {
                return GetUsers().Where(user => user.username.Equals(username)).First();
            } catch(InvalidOperationException) {
                return null;
            }
        }

        public User RegisterUser(string fullName, string username, string password, bool admin) {
            int id = database.GetNewId("users");
            User user = new User(id, fullName, username, password, admin);

            // Validate
            if(!user.Validate()) {
                return null;
            }

            // Add and return
            database.users.Add(user);
            return user;
        }

        public User GetCurrentUser() {
            return currentUser;
        }

        public void SetCurrentUser(User currentUser) {
            this.currentUser = currentUser;
        }

    }

}
