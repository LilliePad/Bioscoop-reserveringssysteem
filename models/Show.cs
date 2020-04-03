using Project.Base;
using Project.Helpers;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class Show: Model {

        public int id = -1;
        public string Movie;
        public string Room;
        public string Date;
        public string Time;
        

        public Show(ShowRecord record) {
            this.id = record.id;
            this.Movie = record.Movie;
            this.Room = record.Room;
            this.Date = record.Date;
            this.Time = record.Time;
        }

        public Show(string Movie, string Room, string Date, string Time) {
            this.Movie = Movie;
            this.Room = Room;
            this.Date = Date;
            this.Time = Time;
        }

        private Show(int id, string Movie, string Room, string Date, string Time) {
            this.id = id;
            this.Movie = Movie;
            this.Room = Room;
            this.Date = Date;
            this.Time = Time;
        }

        public override bool Validate() {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");
            RoomService roomService = app.GetService<RoomService>("rooms");

            // Make sure the room exists
            Room room = roomService.GetRoomById(roomId);
            Show show = showService.GetRoomById(showId);

            if (room == null) {
                AddError("roomId", "Ongeldige zaal");
                return false;
            }


            if (show != null && show.id != id) {
                AddError("number", "Nummer moet uniek zijn voor de gekozen rij");
                return false;
            }


            return true;
        }

    }
     
}


   