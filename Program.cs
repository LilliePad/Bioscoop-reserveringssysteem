using System.IO;
using Project.Base;
using Project.Commands;
using Project.Data;
using Project.Services;

namespace Project {

    class Program : Application {

        // Main class instance
        private static Program instance;

        // Database
        private Database database;

        static void Main(string[] args) {
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

            // Register chairs manager
            RegisterService(new ChairService());

            // Register rooms service
            RegisterService(new RoomService());

            // Register commands service
            ConsoleService commandService = new ConsoleService();

            commandService.RegisterCommand(new Stop());

            commandService.RegisterCommand(new UserList());
            commandService.RegisterCommand(new UserCreate());
            commandService.RegisterCommand(new UserEdit());
            commandService.RegisterCommand(new UserChangePassword());
            commandService.RegisterCommand(new UserDelete());
            commandService.RegisterCommand(new UserLogin());

            commandService.RegisterCommand(new RoomList());
            commandService.RegisterCommand(new RoomCreate());
            commandService.RegisterCommand(new RoomDelete());

            commandService.RegisterCommand(new ChairList());
            commandService.RegisterCommand(new ChairCreate());
            commandService.RegisterCommand(new ChairDelete());

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
