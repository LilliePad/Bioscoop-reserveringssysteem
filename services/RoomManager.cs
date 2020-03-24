using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project.Base;
using Project.Data;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Records;

namespace Project.Services {

    class RoomManager : Service {

        // Database
        private RoomDatabase database;

        public override string getHandle() {
            return "rooms";
        }

        public override void Load() {
            database = new RoomDatabase();

            // Stop if loading failed
            if (!database.Load()) {
                throw new InvalidDataException("Failed to load room database");
            }
        }

        // Returns all rooms
        public List<Room> GetRooms() {
            List<Room> models = new List<Room>();

            foreach (RoomRecord record in database.rooms) {
                models.Add(new Room(record));
            }

            return models;
        }

        // Returns a room by its id
        public Room GetRoomById(int id) {
            try {
                return GetRooms().Where(i => i.id == id).First();
            } catch (InvalidOperationException) {
                return null;
            }
        }

        // Returns a room by its number
        public Room GetRoomByNumber(int number) {
            try {
                return GetRooms().Where(i => i.number == number).First();
            } catch (InvalidOperationException) {
                return null;
            }
        }

        // Saves the specified room
        public bool SaveRoom(Room room) {
            bool isNew = room.id == -1;

            // Set id if its a new room
            if (isNew) {
                room.id = database.GetNewId("rooms");
            }

            // Validate and add if valid
            if (!room.Validate()) {
                return false;
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
            record.chairs = room.chairs;

            // Try to save
            database.TryToSave();

            return true;
        }

        // Deletes the specified room
        public bool DeleteRoom(Room room) {
            RoomRecord record = database.rooms.SingleOrDefault(i => i.id == room.id);

            // Return false if room doesn't exist
            if (record == null) {
                return false;
            }

            // Remove record
            database.rooms.Remove(record);

            // Try to save
            database.TryToSave();

            return true;
        }

    }

}
