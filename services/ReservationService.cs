using System;
using System.Collections.Generic;
using System.Linq;
using Project.Base;
using Project.Data;
using Project.Models;
using Project.Records;

namespace Project.Services {

    class ReservationService : Service {

        public override string GetHandle() {
            return "reservation";
        }

        // Returns a reservation by its id
        public Reservation GetReservationById(int id) {
            Database database = Program.GetInstance().GetDatabase();

            try {
                return new Reservation(database.reservations.Where(i => i.id == id).First());
            }
            catch (InvalidOperationException) {
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
            }
            catch (InvalidOperationException) {
                return null;
            }
        }

        // Saves the specified user
        public bool SaveReservation(Reservation reservation) {
            Database database = Program.GetInstance().GetDatabase();
            bool isNew = reservation.id == -1;

            // Validate and add if valid
            if (!reservation.Validate()) {
                return false;
            }

            // Set id if its a new user
            if (isNew) {
                reservation.id = database.GetNewId("chairs");
            }

            // Find existing record
            ReservationRecord record = database.reservations.SingleOrDefault(i => i.id == reservation.id);

            // Add if no record exists
            if (record == null) {
                record = new ReservationRecord();
                database.reservations.Add(record);
            }


            // Update record
            record.id = reservation.id;
            record.chair = reservation.chair;
            record.room = reservation.room;
            record.userId = reservation.userId;
            record.show = reservation.show;

            // Try to save
            database.TryToSave();

            return true;
        }

        // Deletes the specified chair
        public bool DeleteReservation(Reservation reservation) {
            Database database = Program.GetInstance().GetDatabase();
            ReservationRecord record = database.reservations.SingleOrDefault(i => i.id == reservation.id);

            // Return false if room doesn't exist
            if (record == null) {
                return false;
            }

            // returns if users and the user is not an admin
            //  if ( userService.GetCurrentUserId() !=) {
            //      return false
            //  }


            // Remove record
            database.reservations.Remove(record);
            // TODO: Remove related reservations

            // Try to save
            database.TryToSave();

            return true;
        }


    }

}
