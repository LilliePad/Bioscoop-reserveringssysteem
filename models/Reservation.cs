using Project.Base;
using Project.Records;
using Project.Services;
using System.Linq;
namespace Project.Models {
    class Reservation : Model {
        //Properties
        public int id;
        public int chair;
        public int room;
        public int userId;
        public string show;


        public Reservation(ReservationRecord record) {
            id = record.id;
            chair = record.chair;
            room = record.room;
            userId = record.userId;
            show = record.show;
        }

        public Reservation(int id, int chair, int room, int userId, string show) {
            this.id = id;
            this.chair = chair;
            this.room = room;
            this.userId = userId;
            this.show = show;
        }
    }
}