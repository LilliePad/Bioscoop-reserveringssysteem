namespace Project.Base {

    class StorageFile {

        // The file directory
        public string directory;

        // The file name
        public string fileName;

        // The location (directory and file name)
        public string location;

        public StorageFile(string category, string fileName) {
            directory =  @"storage/" + (category != null ? (category + "/") : "");
            this.fileName = fileName;
            location = directory + this.fileName;
        }

    }

}