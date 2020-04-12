using System;
using System.Collections.Generic;
using System.Linq;
using Project.Base;
using Project.Data;
using Project.Models;
using Project.Records;

namespace Project.Services {

    class RoomService : Service {

        public override string GetHandle() {
            return "rooms";
        }

        // Returns all rooms
        public List<Room> GetRooms() {
            Database database = Program.GetInstance().GetDatabase();
            List<Room> models = new List<Room>();

            foreach (RoomRecord record in database.rooms) {
                models.Add(new Room(record));
            }

            return models;
        }

        // Returns a room by its id
        public Room GetRoomById(int id) {
            Database database = Program.GetInstance().GetDatabase();

            try {
                return new Room(database.rooms.Where(i => i.id == id).First());
            } catch (InvalidOperationException) {
                return null;
            }
        }

        // Returns a room by its number
        public Room GetRoomByNumber(int number) {
            Database database = Program.GetInstance().GetDatabase();

            try {
                return new Room(database.rooms.Where(i => i.number == number).First());
            } catch (InvalidOperationException) {
                return null;
            }
        }

        // Saves the specified room
        public bool SaveRoom(Room room) {
            Program app = Program.GetInstance();
            Database database = app.GetDatabase();
            ChairService chairService = app.GetService<ChairService>("chairs");
            bool isNew = room.id == -1;

            // Validate and add if valid
            if (!room.Validate()) {
                return false;
            }

            // Set id if its a new room
            if (isNew) {
                room.id = database.GetNewId("rooms");
            }

            // Find existing record
            RoomRecord record = database.rooms.SingleOrDefault(i => i.id == room.id);

            // Add if no record exists
            if (record == null) {
                record = new RoomRecord();
                database.rooms.Add(record);
            }

            // Update record
            record.id = room.id;
            record.number = room.number;

            // Try to save
            database.TryToSave();

            return true;
        }

        // Deletes the specified room
        public bool DeleteRoom(Room room) {
            Program app = Program.GetInstance();
            Database database = app.GetDatabase();
            ChairService chairService = app.GetService<ChairService>("chairs");
            ShowService showService = app.GetService<ShowService>("shows");

            // Find record
            RoomRecord record = database.rooms.SingleOrDefault(i => i.id == room.id);

            if (record == null) {
                return false;
            }

            // Remove record and chairs
            database.rooms.Remove(record);
            
            foreach(Chair chair in chairService.GetChairsByRoom(room)) {
                chairService.DeleteChair(chair);
            }

            // Try to save
            database.TryToSave();

            return true;
        }

    }

}
