using System.Collections.Generic;
using Project.Base;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class Room : Model {

        public int id = -1;
        public int number;

        public Room(RoomRecord record) {
            id = record.id;
            number = record.number;
        }

        public Room(int number) {
            this.number = number;
        }

        public override bool Validate() {
            RoomService roomService = Program.GetInstance().GetService<RoomService>("rooms");

            // Make sure the number is unique
            Room existing = roomService.GetRoomByNumber(number);

            if (existing != null && existing.id != id) {
                AddError("number", "Nummer is al in gebruik");
                return false;
            }

            return true;
        }

        // Returns all chairs that belong to this Room
        public List<Chair> GetChairs() {
            ChairService chairService = Program.GetInstance().GetService<ChairService>("chairs");
            return chairService.GetChairsByRoom(this);
        }

    }

}
