using Project.Base;
using Project.Helpers;
using Project.Records;
using Project.Services;
using System;

namespace Project.Models {

    class Show: Model {

        public int id = -1;
        public int movieId;
        public int roomId;
        public DateTime dateTimeShow;
        
        

        public Show(ShowRecord record) {
            this.id = record.id;
            this.movieId = record.movieId;
            this.roomId = record.roomId;
            this.dateTimeShow = record.dateTimeShow;
            
        }

        public Show(int movieId, int roomId, DateTime dateTimeShow) {
            this.movieId = movieId;
            this.roomId = roomId;
            this.dateTimeShow = dateTimeShow;
            
        }

        private Show(int id, int movieId, int roomId, DateTime dateTimeShow) {
            this.id = id;
            this.movieId = movieId;
            this.roomId = roomId;
            this.dateTimeShow = dateTimeShow;
            
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


   