using Project.Base;
using Project.Records;
using Project.Services;
using System.Linq;

namespace Project.Models {

    public class Chair : Model {

        // Valid chair types
        public static readonly string[] TYPES = { "default" };

        // Properties
        public int id = -1;
        public int roomId;
        public int row;
        public int number;
        public double price;
        public string type;

        public Chair(ChairRecord record) {
            id = record.id;
            roomId = record.roomId;
            row = record.row;
            number = record.number;
            price = record.price;
            type = record.type;
        }

        public Chair(int roomId, int row, int number, double price, string type) {
            this.roomId = roomId;
            this.row = row;
            this.number = number;
            this.price = price;
            this.type = type;
        }

        public override bool Validate() {
            Program app = Program.GetInstance();
            RoomService roomService = app.GetService<RoomService>("rooms");
            ChairService chairService = app.GetService<ChairService>("chairs");

            // Make sure the room exists
            Room room = roomService.GetRoomById(roomId);

            if (room == null) {
                AddError("roomId", "Ongeldige zaal");
                return false;
            }

            // Make sure the row + number combo is unique
            Chair chair = chairService.GetChairByRoomAndPosition(room, row, number);

            if(chair != null && chair.id != id) {
                AddError("number", "Nummer moet uniek zijn voor de gekozen rij");
                return false;
            }

            // Make sure price is 0 or higher
            if (price < 0) {
                AddError("price", "Prijs mag niet negatief zijn");
                return false;
            }

            // Make a valid type was selected
            if (!TYPES.Contains(type)) {
                AddError("type", "Ongeldig type");
                return false;
            }

            return true;
        }

        // Returns the room which this chair belongs to
        public Room GetRoom() {
            RoomService roomService = Program.GetInstance().GetService<RoomService>("rooms");
            return roomService.GetRoomById(roomId);
        }

    }
}


