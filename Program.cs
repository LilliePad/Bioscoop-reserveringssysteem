using System;
using Project_Data;

namespace Bioscoop_reserveringssysteem {

    class Program {

        // Program instance
        private static Program instance;

        // Services
        public Database database;

        static void Main(string[] args) {
            instance = new Program();
        }

        public Program() {
            database = new Database();
            database.Load();
        }
    }

}
