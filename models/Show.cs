using System;
using Project.Base;
using Project.Records;
using Project.Services;

namespace Project.Models {

    public class Show : Model {

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
            MovieService movieService = app.GetService<MovieService>("movies");
            RoomService roomService = app.GetService<RoomService>("rooms");

            // Validate movie
            Movie movie = movieService.GetMovieById(movieId);

            if (movie == null) {
                AddError("movieId", "Ongeldige film");
                return false;
            }

            // Validate room
            Room room = roomService.GetRoomById(roomId);

            if (room == null) {
                AddError("roomId", "Ongeldige zaal");
                return false;
            }

            return true;
        }

        // Returns the movie which this chair belongs to
        public Movie GetMovie() {
            MovieService movieService = Program.GetInstance().GetService<MovieService>("movies");
            return movieService.GetMovieById(movieId);
        }

        // Returns the room which this chair belongs to
        public Room GetRoom() {
            RoomService roomService = Program.GetInstance().GetService<RoomService>("rooms");
            return roomService.GetRoomById(roomId);
        }

    }
     
}


   