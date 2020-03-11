namespace Project.Base {

    abstract class Command {

        // The command name
        public abstract string GetName();

        // The code that is executed when running the command
        public abstract void RunCommand(string[] args);
        
        // The category (part before the slash)
        public virtual string GetCategory() {
            return null;
        }

        // Whether this command requires the user to be logged in
        public virtual bool RequireLogin() {
            return true;
        }

        // Whether this command requires the user to be an admin
        public virtual bool RequireAdmin() {
            return false;
        }

    }

}
