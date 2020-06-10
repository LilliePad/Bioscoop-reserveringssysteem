using System;
using System.IO;
using System.Text.RegularExpressions;
using Project.Base;
using Project.Data;
using Project.Forms;
using Project.Services;
using Projects.Forms;
using Project.Models;

namespace Project {

    public class Program : BaseApplication {

        // Constants
        public static readonly string DATE_FORMAT = "dd-MM-yyyy";
        public static readonly Regex DATE_REGEX = new Regex(@"^([0-2][0-9]|(3)[0-1])(\-)(((0)[0-9])|((1)[0-2]))(\-)\d{4}$");
        public static readonly string TIME_FORMAT = "HH:mm";
        public static readonly Regex TIME_REGEX = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");
        public static readonly string DATETIME_FORMAT = DATE_FORMAT + " " + TIME_FORMAT;

        // Program instance & database
        private static Program instance;
        private Database database;

        [STAThread]
        static void Main() {
            instance = new Program();
            instance.Start();
        }

        protected override void Load() {
            database = new Database();

            // Stop if loading failed
            if (!database.Load()) {
                throw new InvalidDataException("Failed to load database");
            }

            // Register services
            RegisterService(new UserService());
            RegisterService(new MovieService());
            RegisterService(new RoomService());
            RegisterService(new ChairService());
            RegisterService(new ShowService());
            RegisterService(new ReservationService());

            // Screens
            RegisterScreen(new MovieList());
            RegisterScreen(new MovieCreate());
            RegisterScreen(new MovieDetail());

            RegisterScreen(new RoomList());
            RegisterScreen(new RoomCreate());
            RegisterScreen(new RoomDetail());

            RegisterScreen(new ChairEdit());

            RegisterScreen(new ShowList());
            RegisterScreen(new ShowCreate());
            RegisterScreen(new ShowDetail());

            RegisterScreen(new ReservationList());
            RegisterScreen(new ReservationCreate());
            RegisterScreen(new ReservationDetail());

            RegisterScreen(new UserList());
            RegisterScreen(new UserCreate());
            RegisterScreen(new UserEdit());
            RegisterScreen(new UserChangePassword());

            RegisterScreen(new MovieListUser());
            RegisterScreen(new MovieDetailUser());
            RegisterScreen(new ChairSelect());
        }

        protected override void Unload() {

        }

        // Returns the main class instance
        public static Program GetInstance() {
            return instance;
        }

        // Return the database instance
        public Database GetDatabase() {
            return database;
        }

    }

}
