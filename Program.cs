using Project.Base;
using Project.Commands;
using Project.Services;

namespace Project {

    class Program : Application {

        // Main class instance
        private static Program instance;

        static void Main(string[] args) {
            instance = new Program();
            instance.Start();
        }

        protected override void Load() {
            // Register users service
            RegisterService(new UserManager());
            RegisterService(new MovieManager());

            // Register commands service
            CommandManager commandManager = new CommandManager();

            commandManager.RegisterCommand(new Stop());

            commandManager.RegisterCommand(new MovieList());
            commandManager.RegisterCommand(new MovieCreate());
            commandManager.RegisterCommand(new MovieEdit());
            commandManager.RegisterCommand(new MovieDelete());
            commandManager.RegisterCommand(new UserList());
            commandManager.RegisterCommand(new UserCreate());
            commandManager.RegisterCommand(new UserEdit());
            commandManager.RegisterCommand(new UserChangePassword());
            commandManager.RegisterCommand(new UserDelete());
            commandManager.RegisterCommand(new UserLogin());

            RegisterService(commandManager);
        }

        protected override void Unload() {

        }

        // Returns the main class instance
        public static Program GetInstance() {
            return instance;
        }

    }

}
