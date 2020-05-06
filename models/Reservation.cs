using Project.Base;
using Project.Records;
using Project.Services;
using System.Linq;
namespace Project.Models {
    class Reservation : Model {
        //Properties
        public int id = -1;
        public int chair;
        public int userId = 0;
        public int show;


        public Reservation(ReservationRecord record) {
            id = record.id;
            chair = record.chair;
            userId = record.userId;
            show = record.show;
        }

        public Reservation(int chair, int show, int userId) {
            this.chair = chair;
            this.userId = userId;
            this.show = show;
        }
    }
}