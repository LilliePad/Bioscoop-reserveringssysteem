using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Project.Base;
using Project.Data;
using Project.Forms;
using Project.Services;

namespace Project {

    class Program : BaseApplication {

        // Constants
        public static readonly string DATE_FORMAT = "dd-MM-yyyy";
        public static readonly Regex DATE_REGEX = new Regex(@"^([0-2][0-9]|(3)[0-1])(\-)(((0)[0-9])|((1)[0-2]))(\-)\d{4}$");
        public static readonly string TIME_FORMAT = "HH:mm";
        public static readonly Regex TIME_REGEX = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");

        // Program instance & database
        private static Program instance;
        private Database database;

        [STAThread]
        static void Main() {
            instance = new Program();
            instance.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MovieCreate());
        }

        protected override void Load() {
            database = new Database();

            // Stop if loading failed
            if (!database.Load()) {
                throw new InvalidDataException("Failed to load database");
            }

            // Register users service
            RegisterService(new UserService());

            RegisterService(new MovieService());

            // Register rooms service
            RegisterService(new RoomService());

            // Register chairs manager
            RegisterService(new ChairService());

            // Register shows service
            RegisterService(new ShowService());

            //Register Reservation service
            RegisterService(new ReservationService());
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
