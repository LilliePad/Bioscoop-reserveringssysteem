using Project.Base;
using Project.Helpers;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class Show: Model {

        public int id = -1;
        public string Movie;
        public string Room;
        public string Time;
        

        public Show(ShowRecord record) {
            this.id = record.id;
            this.Movie = record.Movie;
            this.Room = record.Room;
            this.Time = record.Time;
        }

        public Show(string Movie, string Room, string Time) {
            this.Movie = Movie;
            this.Room = Room;
            this.Time = Time;
        }

        private Show(int id, string Movie, string Room, string Time) {
            this.id = id;
            this.Movie = Movie;
            this.Room = Room;
            this.Time = Time;
        }



    }

}