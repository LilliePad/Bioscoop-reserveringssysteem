namespace Project_Base {

    class StorageFile {

        public string directory;
        public string fileName;
        public string location;

        public StorageFile(string category, string fileName) {
            this.directory =  @"storage/" + category + "/";
            this.fileName = fileName + (fileName.EndsWith(".json") ? "" : ".json");
            this.location = this.directory + this.fileName;
        }

    }

}