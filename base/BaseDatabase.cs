using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Project.Data;
using Project.Helpers;

namespace Project.Base {

    public class BaseDatabase {

        // Settings
        public static readonly string STORAGE_CATEGORY = null;
        public static readonly string STORAGE_NAME = "database";

        // List to keep track of the used ids
        // You can get a new unique id using GetNewId()
        public Dictionary<string, int> newIds = new Dictionary<string, int>();

        // Active bulk actions
        private List<BulkUpdate> bulkUpdates = new List<BulkUpdate>();

        // Loads the database file into this object
        public bool Load() {
            try {
                StorageHelper.LoadFile(STORAGE_CATEGORY, STORAGE_NAME, this);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        // Tries to load and prints error on failure
        public bool TryToLoad() {
            bool success = Load();

            // Try to save
            if (!success) {
                GuiHelper.ShowError("Failed to load " + STORAGE_NAME + " database");
            }

            return success;
        }

        // Saves this object into the database file
        public bool Save() {
            bool bulkUpdate = IsPerformingBulkUpate();

            // Ignore if performing a bulk update
            if(bulkUpdate) {
                return true;
            }

            try {
                StorageHelper.SaveFile(STORAGE_CATEGORY, STORAGE_NAME, this);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        // Tries to save and prints error on failure
        public bool TryToSave() {
            bool success = Save();

            // Try to save
            if (!success) {
                GuiHelper.ShowError("Failed to save " + STORAGE_NAME + " database");
            }

            return success;
        }

        // Returns a new unique id for the specified category
        public int GetNewId(string category) {
            if (category == null) {
                category = "__global__";
            }

            // Grab id
            if (!newIds.TryGetValue(category, out int newId)) {
                newId = 1;
            }

            // Increase and return
            newIds[category] = newId + 1;

            // Try to save
            TryToSave();

            return newId;
        }

        // Registers a bulk update
        public void RegisterBulkUpdate(BulkUpdate bulkUpdate) {
            if(bulkUpdates.Contains(bulkUpdate)) {
                return;
            }

            bulkUpdates.Add(bulkUpdate);
        }

        // Registers a bulk update
        public void RemoveBulkUpdate(BulkUpdate bulkUpdate) {
            bulkUpdates.Remove(bulkUpdate);

            if(bulkUpdates.Count == 0) {
                TryToSave();
            }
        }

        public bool IsPerformingBulkUpate() {
            return bulkUpdates.Count > 0;
        }

    }

}
