using Project.Base;

namespace Project.Records {

    public class MovieRecord : Record {

        public int id;
        public string name;
        public string description;
        public string genre;
        public int duration;
        public StorageFile image;

    }

}