namespace Project.Base {

    abstract class Service {

        public abstract string getHandle();

        public virtual void Load() {  }
        public virtual void Unload() {  }

    }

}
