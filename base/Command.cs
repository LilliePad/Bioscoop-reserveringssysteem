namespace Project.Base {

    abstract class Command {

        // The category (part before the slash)
        public virtual string GetCategory() {
            return null;
        }

        // The command name
        public abstract string GetName();

        // Returns the command usage
        public virtual string GetUsage() {
            return GetKey();
        }

        // The code that is executed when running the command
        public abstract void RunCommand(string[] args);

        // Whether this command requires the user to be logged in
        public virtual bool RequireLogin() {
            return true;
        }

        // Whether this command requires the user to be an admin
        public virtual bool RequireAdmin() {
            return false;
        }

        // Returns the command key
        public string GetKey() {
            return (GetCategory() != null ? (GetCategory() + "/") : "") + GetName();
        }

    }

}
