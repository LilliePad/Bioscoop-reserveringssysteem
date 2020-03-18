using System.Collections.Generic;
using Project.Base;
using Project.Records;

namespace Project.Data {

    class ChairDatabasee : Database {

        public List<ChairRecord> chairs = new List<ChairRecord>();

        public override string GetFileName() {
            return "chairs";
        }

    }

}