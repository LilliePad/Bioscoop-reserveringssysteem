using System;
using Project.Base;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class Show: Model {

        public int id = -1;
        public int movieId;
        public int roomId;
        public DateTime startTime;
        
        public Show(ShowRecord record) {
            id = record.id;
            movieId = record.movieId;
            roomId = record.roomId;
            startTime = record.startTime;
        }

        public Show(int movieId, int roomId, DateTime startTime) {
            this.movieId = movieId;
            this.roomId = roomId;
            this.startTime = startTime;
        }

        public override bool Validate() {
            Program app = Program.GetInstance();
            RoomService roomService = app.GetService<RoomService>("rooms");

            // TODO: Add movie validation

            // Validate room
            Room room = roomService.GetRoomById(roomId);

            if (room == null) {
                AddError("roomId", "Ongeldige zaal");
                return false;
            }

            return true;
        }

    }
     
}


   