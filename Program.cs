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
            this.database = new Database();

            // Try to load
            if(!this.database.Load()) {
                LogHelper.log(LogType.Error, "Failed to load database");
            }

            Console.WriteLine("Loaded data: " + this.database.test);

            // Set random value
            Random random = new Random();
            this.database.test = random.Next(1, 100);
            Console.WriteLine("Set data: " + this.database.test);

            // Try to save
            if(!this.database.Save()) {
                LogHelper.log(LogType.Error, "Failed to save database");
            }
        }

        public Database GetDatabase() {
            return this.database;
        }

    }

}
