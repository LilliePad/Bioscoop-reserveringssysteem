namespace Project.Base {

    abstract class Service {

        // The handle of this service
        public abstract string getHandle();

        // Called after loading the app
        public virtual void Load() {  }

        // Called before unloading the app
        public virtual void Unload() {  }

    }

}
