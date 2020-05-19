using System.Collections.Generic;
using Project.Base;
using Project.Records;

namespace Project.Data {

    class Database : BaseDatabase {

        // Users
        public List<UserRecord> users = new List<UserRecord>();

        // Movies
        public List<MovieRecord> movies = new List<MovieRecord>();

        // Rooms
        public List<RoomRecord> rooms = new List<RoomRecord>();

        // Chairs
        public List<ChairRecord> chairs = new List<ChairRecord>();

        // Show 
        public List<ShowRecord> shows = new List<ShowRecord>();

        // Reservations
        public List<ReservationRecord> reservations = new List<ReservationRecord>();
    }

}