using Project.Base;
using Project.Helpers;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class Show: Model {

        public int id = -1;
        public string Movie;
        public int RoomId;
        public string DateTime;
        
        

        public Show(ShowRecord record) {
            this.id = record.id;
            this.Movie = record.Movie;
            this.RoomId = record.RoomId;
            this.DateTime = record.DateTime;
            
        }

        public Show(string Movie, int RoomId, string DateTime) {
            this.Movie = Movie;
            this.RoomId = RoomId;
            this.DateTime = DateTime;
            
        }

        private Show(int id, string Movie, int RoomId, string DateTime) {
            this.id = id;
            this.Movie = Movie;
            this.RoomId = RoomId;
            this.DateTime = DateTime;
            
        }

        public override bool Validate() {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");

          
            Show show = showService.GetShowById(id);

            if (show == null) {
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


   