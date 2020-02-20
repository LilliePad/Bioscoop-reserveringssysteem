using System;
using Project_Data;
using Project_Enums;
using Project_Helpers;

namespace Bioscoop_reserveringssysteem {

    class Program {

        // Program instance
        private static Program instance;

        // Services
        private Database database;

        static void Main(string[] args) {
            instance = new Program();
        }

        public Program() {
            database = new Database();

            // Try to load
            if(!database.Load()) {
                LogHelper.log(LogType.Error, "Failed to load database");
            }

            Console.WriteLine("Loaded data: " + database.test);

            // Set random value
            Random random = new Random();
            database.test = random.Next(1, 100);
            Console.WriteLine("Set data: " + database.test);

            // Try to save
            if(!database.Save()) {
                LogHelper.log(LogType.Error, "Failed to save database");
            }
        }

        public Program getInstance() {
            return instance;
        }

        public Database GetDatabase() {
            return database;
        }

    }

}
