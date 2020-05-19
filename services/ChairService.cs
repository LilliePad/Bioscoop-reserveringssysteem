using System;
using System.Collections.Generic;
using System.Linq;
using Project.Base;
using Project.Data;
using Project.Models;
using Project.Records;

namespace Project.Services {

    class ChairService : Service {

        public override string GetHandle() {
            return "chairs";
        }

        // Returns a chair by its id
        public Chair GetChairById(int id) {
            Database database = Program.GetInstance().GetDatabase();

            try {
                return new Chair(database.chairs.Where(i => i.id == id).First());
            } catch (InvalidOperationException) {
                return null;
            }
        }

        public List<Chair> GetChairsByRoom(Room room) {
            Database database = Program.GetInstance().GetDatabase();
            List<Chair> models = new List<Chair>();

            // Get records for the specified room
            List<ChairRecord> records = database.chairs.Where(i => i.roomId == room.id).ToList();

            // Turn records into models
            foreach (ChairRecord record in records) {
                models.Add(new Chair(record));
            }

            return models;
        }

        public Chair GetChairByRoomAndPosition(Room room, int row, int number) {
            Database database = Program.GetInstance().GetDatabase();

            try {
                return new Chair(database.chairs.Where(i => i.roomId == room.id && i.row == row && i.number == number).First());
            } catch (InvalidOperationException) {
                return null;
            }
        }

        // Saves the specified user
        public bool SaveChair(Chair chair) {
            Database database = Program.GetInstance().GetDatabase();
            bool isNew = chair.id == -1;

            // Validate and add if valid
            if (!chair.Validate()) {
                return false;
            }

            // Set id if its a new user
            if (isNew) {
                chair.id = database.GetNewId("chairs");
            }

            // Find existing record
            ChairRecord record = database.chairs.SingleOrDefault(i => i.id == chair.id);

            // Add if no record exists
            if (record == null) {
                record = new ChairRecord();
                database.chairs.Add(record);
            }


            // Update record
            record.id = chair.id;
            record.roomId = chair.roomId;
            record.row = chair.row;
            record.number = chair.number;
            record.price = chair.price;
            record.type = chair.type;

            // Try to save
            database.TryToSave();

            return true;
        }

        // Deletes the specified chair
        public bool DeleteChair(Chair chair) {
            Program app = Program.GetInstance();
            Database database = app.GetDatabase();
            ReservationService reservationService = Program.GetInstance().GetService<ReservationService>("reservations");

            // Find record
            ChairRecord record = database.chairs.SingleOrDefault(i => i.id == chair.id);

            if (record == null) {
                return false;
            }

            // Remove record and related reservations
            database.chairs.Remove(record);

            foreach (Reservation reservation in reservationService.GetReservationsByChair(chair)) {
                reservationService.DeleteReservation(reservation);
            }

            // Try to save
            database.TryToSave();

            return true;
        }


    }

}
