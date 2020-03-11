namespace Project.Base {

    class StorageFile {

        // The file directory
        public string directory;

        // The file name
        public string fileName;

        // The location (directory and file name)
        public string location;

        public StorageFile(string category, string fileName) {
            this.directory =  @"storage/" + category + "/";
            this.fileName = fileName + (fileName.EndsWith(".json") ? "" : ".json");
            this.location = this.directory + this.fileName;
        }

    }

}