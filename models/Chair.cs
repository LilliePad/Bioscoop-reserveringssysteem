using Project.Base;
using Project.Records;
using Project.Services;
using System.Linq;

namespace Project.Models {

    class Chair : Model {

        // Valid chair types
        public static readonly string[] TYPES = { "default" };

        // Properties
        public int id = -1;
        public int roomId;
        public int row;
        public int number;
        public double price;
        public string type;
        public bool available;


        public Chair(ChairRecord record) {
            id = record.id;
            roomId = record.roomId;
            row = record.row;
            number = record.number;
            price = record.price;
            type = record.type;
            available = record.available;
        }

        public Chair(int roomId, int row, int number, double price, string type, bool available) {
            this.roomId = roomId;
            this.row = row;
            this.number = number;
            this.price = price;
            this.type = type;
            this.available =available;
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
    
    }

}


