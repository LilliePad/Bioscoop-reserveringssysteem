namespace Project_Base {

    abstract class Command {

        public abstract string GetName();
        public abstract void RunCommand(string[] args);
        
        public bool RequireAdmin() {
            return false;
        }

    }

}
