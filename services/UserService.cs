﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Project.Base;
using Project.Data;
using Project.Helpers;
using Project.Models;
using Project.Records;

namespace Project.Services {

    public class UserService : Service {

        // Current user (logged in user)
        private User currentUser;
        public override string GetHandle() {
            return "users";
        }

        public override void Load() {
            Database database = Program.GetInstance().GetDatabase();

            // Creating default user if we need to
            if (database.users.Count == 0) {
                User admin = new User("Admin user", "admin", "admin", true);

                if (!SaveUser(admin)) {
                    GuiHelper.ShowError("Failed to create default user");
                    return;
                }

                SetCurrentUser(admin);
                GuiHelper.ShowWarning("Er is een standaard admin gebruiker aangemaakt, pas deze z.s.m. aan");
            }
        }

        // Returns all users
        public List<User> GetUsers() {
            Database database = Program.GetInstance().GetDatabase();
            List<User> models = new List<User>();

            foreach(UserRecord record in database.users) {
                models.Add(new User(record));
            }

            return models;
        }

        // Returns a user by its id
        public User GetUserById(int id) {
            Database database = Program.GetInstance().GetDatabase();

            try {
                return new User(database.users.Where(i => i.id == id).First());
            } catch (InvalidOperationException) {
                return null;
            }
        }

        // Returns a user by its username
        public User GetUserByUsername(string username) {
            Database database = Program.GetInstance().GetDatabase();

            try {
                return new User(database.users.Where(i => i.username.Equals(username)).First());
            } catch(InvalidOperationException) {
                return null;
            }
        }

        // Saves the specified user
        public bool SaveUser(User user) {
            Database database = Program.GetInstance().GetDatabase();
            bool isNew = user.id == -1;

            // Validate and add if valid
            if(!user.Validate()) {
                return false;
            }

            // Set id if its a new user
            if (isNew) {
                user.id = database.GetNewId("users");
            }

            // Find existing record
            UserRecord record = database.users.SingleOrDefault(i => i.id == user.id);
            
            // Add if no record exists
            if(record == null) {
                record = new UserRecord();
                database.users.Add(record);
            }

            // Update record
            record.id = user.id;
            record.fullName = user.fullName;
            record.username = user.username;
            record.password = user.password;
            record.admin = user.admin;

            // Try to save
            database.TryToSave();

            return true;
        }

        // Deletes the specified user
        public bool DeleteUser(User user) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            Database database = Program.GetInstance().GetDatabase();

            // Find record
            UserRecord record = database.users.SingleOrDefault(i => i.id == user.id);

            if (record == null) {
                return false;
            }

            // Remove record and related reservations
            database.users.Remove(record);

            foreach (Reservation reservation in reservationService.GetReservationsByUser(user)) {
                reservationService.DeleteReservation(reservation);
            }

            // Try to save
            database.TryToSave();

            return true;
        }

        // Returns current user
        public User GetCurrentUser() {
            return currentUser;
        }

        // Sets the current user
        public void SetCurrentUser(User currentUser) {
            this.currentUser = currentUser;
        }

    }

}
