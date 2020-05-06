using System.IO;
using System.Text.RegularExpressions;
using Project.Base;
using Project.Commands;
using Project.Data;
using Project.Services;

namespace Project {

    class Program : Application {

        // Constants
        public static readonly string DATE_FORMAT = "dd-MM-yyyy";
        public static readonly Regex DATE_REGEX = new Regex(@"^([0-2][0-9]|(3)[0-1])(\-)(((0)[0-9])|((1)[0-2]))(\-)\d{4}$");
        public static readonly string TIME_FORMAT = "HH:mm";
        public static readonly Regex TIME_REGEX = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");

        // Program instance & database
        private static Program instance;
        private Database database;

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

            // Register commands service
            ConsoleService commandService = new ConsoleService();

            commandService.RegisterCommand(new Help());
            commandService.RegisterCommand(new Stop());

            commandService.RegisterCommand(new UserList());
            commandService.RegisterCommand(new UserCreate());
            commandService.RegisterCommand(new UserEdit());
            commandService.RegisterCommand(new UserChangePassword());
            commandService.RegisterCommand(new UserDelete());
            commandService.RegisterCommand(new UserLogin());
            commandService.RegisterCommand(new UserLogout());

            commandService.RegisterCommand(new MovieList());
            commandService.RegisterCommand(new MovieCreate());
            commandService.RegisterCommand(new MovieEdit());
            commandService.RegisterCommand(new MovieDelete());

            commandService.RegisterCommand(new RoomList());
            commandService.RegisterCommand(new RoomCreate());
            commandService.RegisterCommand(new RoomDelete());

            commandService.RegisterCommand(new ChairList());
            commandService.RegisterCommand(new ChairCreate());
            commandService.RegisterCommand(new ChairDelete());

            commandService.RegisterCommand(new ShowList());
            commandService.RegisterCommand(new ShowCreate());
            commandService.RegisterCommand(new ShowDelete());

            commandService.RegisterCommand(new ReservationList());
            commandService.RegisterCommand(new ReservationCreate());
            commandService.RegisterCommand(new ReservationDelete());

            RegisterService(commandService);
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
