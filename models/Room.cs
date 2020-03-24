using System.Collections.Generic;
using Project.Base;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class Room : Model {

        public int id = -1;
        public int number;
        public List<string> chairs = new List<string>();

        public Room(RoomRecord record) {
            this.id = record.id;
            this.number = record.number;
            this.chairs = record.chairs;
        }

        public Room(int number) {
            this.number = number;
        }

        public override bool Validate() {
            RoomManager roomManager = Program.GetInstance().GetService<RoomManager>("rooms");

            // Make sure the number is unique
            Room existing = roomManager.GetRoomByNumber(number);

            if (existing != null && existing.id != id) {
                this.AddError("number", "Nummer is al in gebruik.");
                return false;
            }

            // TODO: Add chair validation

            return true;
        }

        public List<string> GetChairs() {
            return chairs;
        }

        public string GetChairById(int id) {
            return "";
        }

        public void AddChair(string chair) {
            chairs.Add(chair);
        }

        public void RemoveChair(string chair) {
            chairs.Remove(chair);
        }

    }

}
