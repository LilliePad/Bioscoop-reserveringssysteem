using System.Collections.Generic;
using Project.Base;
using Project.Records;

namespace Project.Data {

    class ShowDatabase : Database {

        public List<ShowRecord> shows = new List<ShowRecord>();

        public override string GetFileName() {
            return "shows";
        }

    }

}