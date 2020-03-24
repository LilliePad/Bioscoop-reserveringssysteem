using System.Collections.Generic;
using Project.Base;
using Project.Records;

namespace Project.Data {

    class RoomDatabase : Database {

        public List<RoomRecord> rooms = new List<RoomRecord>();

        public override string GetFileName() {
            return "rooms";
        }

    }

}