namespace Project.Base {

    abstract class Command {

        public abstract string GetName();
        public abstract void RunCommand(string[] args);
        
        public virtual string GetCategory() {
            return null;
        }

        public virtual bool RequireAdmin() {
            return false;
        }

    }

}
