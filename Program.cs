using System;
using Project.Base;
using Project.Commands;
using Project.Data;
using Project.Enums;
using Project.Helpers;
using Project.Managers;

namespace Project {

    class Program : Application {

        // Services
        private Database database;
        private CommandManager commandManager;

        static void Main(string[] args) {
            Program.Run(new Program());
        }

        protected override void Load() {
            database = new Database();

            // Try to load
            if(!database.Load()) {
                LogHelper.Log(LogType.Error, "Failed to load database");
            }

            commandManager = new CommandManager();
            commandManager.RegisterCommand(new Stop());
            commandManager.RegisterCommand(new CreateUser());
            commandManager.Start();
        }

        protected override void Unload() {
            // Try to save
            if (!database.Save()) {
                LogHelper.Log(LogType.Error, "Failed to save database");
            }
        }

        public Database GetDatabase() {
            return database;
        }

    }

}
