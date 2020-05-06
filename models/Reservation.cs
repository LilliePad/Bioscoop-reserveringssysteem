using Project.Base;
using Project.Records;
using Project.Services;
using System.Linq;
namespace Project.Models {
    class Reservation : Model {
        //Properties
        public int id = -1;
        public int chair;
        public int room;
        public int userId = 0;
        public string show;


        public Reservation(ReservationRecord record) {
            chair = record.chair;
            room = record.room;
            userId = record.userId;
            show = record.show;
        }

        public Reservation(int chair, int room, int userId, string show) {
            this.chair = chair;
            this.room = room;
            this.userId = userId;
            this.show = show;
        }
    }
}