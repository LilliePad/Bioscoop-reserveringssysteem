using Project_Helpers;

namespace Project_Base {

    abstract class BaseDatabase {

        public abstract string GetFileName();

        public void Load() {
            string path = this.BuildPath(this.GetFileName());
            StorageHelper.LoadFile(path, this.GetType());
        }

        public void Save() {
            string path = this.BuildPath(this.GetFileName());
            StorageHelper.SaveFile(path, this);
        }

        private string BuildPath(string fileName) {
            return @"storage/data/" + fileName + ".json";
        }

    }

}