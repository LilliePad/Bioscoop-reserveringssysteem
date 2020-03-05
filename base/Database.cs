using System;
using System.Collections.Generic;
using Project.Helpers;

namespace Project.Base {

    abstract class Database {

        private Dictionary<string, int> newIds = new Dictionary<string, int>();

        public abstract string GetFileName();

        public bool Load() {
            try {
                StorageHelper.LoadFile("data", this.GetFileName(), this);
                return true;
            } catch(Exception) {
                return false;
            }
        }

        public bool Save() {
            try {
                StorageHelper.SaveFile("data", this.GetFileName(), this);
                return true;
            } catch(Exception) {
                return false;
            }
        }

        public int GetNewId(string category) {
            if(category == null) {
                category = "__global__";
            }

            // Grab id
            int newId;
            if(!newIds.TryGetValue(category, out newId)) {
                newId = 1;
            }

            // Increase and return
            newIds[category] = newId + 1;
            return newId;
        }

    }

}