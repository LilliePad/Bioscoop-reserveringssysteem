using Project.Base;
using Project.Data;
using Project.Enums;
using Project.Helpers;
using Project.Models;

namespace Project.Services {

    class UserManager : Service {

        // Database
        private UserDatabase database;

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

        public bool RegisterUser(string fullName, string username, string password, bool admin) {
            int id = database.GetNewId("users");
            User user = new User(id, fullName, username, password, admin);

            // Validate
            if(!user.Validate()) {
                return false;
            }

            // Add and return
            database.AddUser(user);
            return true;
        }

    }

}
