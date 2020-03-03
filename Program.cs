using System;
using Project_Commands;
using Project_Data;
using Project_Enums;
using Project_Helpers;
using Project_Managers;

namespace Project {

    class Program {

        // Program variables
        private static Program instance;
        private bool running = false;

        // Services
        private Database database;
        private CommandManager commandManager;

        static void Main(string[] args) {
            instance = new Program();
            instance.Start();
        }

        public Program() {
            database = new Database();

            // Try to load
            if(!database.Load()) {
                LogHelper.Log(LogType.Error, "Failed to load database");
            }

            Console.WriteLine("Loaded data: " + database.test);

            // Set random value
            Random random = new Random();
            database.test = random.Next(1, 100);
            Console.WriteLine("Set data: " + database.test);

            // Try to save
            if(!database.Save()) {
                LogHelper.Log(LogType.Error, "Failed to save database");
            }

            commandManager = new CommandManager();
            commandManager.RegisterCommand(new Stop());
            commandManager.RegisterCommand(new CreateUser());
        }

        public static Program GetInstance() {
            return instance;
        }

        public bool IsRunning() {
            return running;
        }

        private void Start() {
            if (IsRunning()) {
                throw new Exception("Application is already running.");
            }

            // Set running to true
            running = true;

            // Start services
            commandManager.Start();
        }

        public void Stop() {
            if (!IsRunning()) {
                throw new Exception("Application is not running.");
            }

            running = false;
            System.Environment.Exit(1);
        }

        public Database GetDatabase() {
            return database;
        }

    }

}
