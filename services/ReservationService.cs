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
            return "reservations";
        }

        // Returns all reservations
        public List<Reservation> GetReservations() {
            Database database = Program.GetInstance().GetDatabase();
            List<Reservation> models = new List<Reservation>();

            foreach (ReservationRecord record in database.reservations) {
                models.Add(new Reservation(record));
            }

            return models;
        }

        // Returns a reservation by its id
        public Reservation GetReservationById(int id) {
            Database database = Program.GetInstance().GetDatabase();

            try {
                return new Reservation(database.reservations.Where(i => i.id == id).First());
            } catch (InvalidOperationException) {
                return null;
            }
        }

        // Returns whether the specified chair is taken for the specified show
        public bool IsChairTaken(Chair chair, Show show) {
            Database database = Program.GetInstance().GetDatabase();
            return database.reservations.Any(i => i.chairId == chair.id && i.showId == show.id);
        }

        // Saves the specified reservation
        public bool SaveReservation(Reservation reservation) {
            Database database = Program.GetInstance().GetDatabase();
            bool isNew = reservation.id == -1;

            // Validate and add if valid
            if (!reservation.Validate()) {
                return false;
            }

            // Set id if its a new user
            if (isNew) {
                reservation.id = database.GetNewId("reservations");
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
            record.showId = reservation.showId;
            record.userId = reservation.userId;
            record.chairId = reservation.chairId;

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

            // Remove record
            database.reservations.Remove(record);
            // TODO: Remove related reservations

            // Try to save
            database.TryToSave();

            return true;
        }

    }
}
