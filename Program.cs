using Project.Base;
using Project.Commands;
using Project.Services;

namespace Project {

    class Program : Application {

        private static Program instance;

        static void Main(string[] args) {
            instance = new Program();
            instance.Start();
        }

        protected override void Load() {
            // Register users service
            RegisterService(new UserManager());

            // Register commands service
            CommandManager commandManager = new CommandManager();
            commandManager.RegisterCommand(new Stop());
            commandManager.RegisterCommand(new CreateUser());
            commandManager.RegisterCommand(new LoginUser());
            RegisterService(commandManager);
        }

        protected override void Unload() {

        }

        public static Program GetInstance() {
            return instance;
        }

    }

}
