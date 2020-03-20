using System.Collections.Generic;
using Project.Base;
using Project.Records;

namespace Project.Data {

    class ChairDatabase : Database {

        public List<ChairRecord> chairs = new List<ChairRecord>();

        public override string GetFileName() {
            return "chairs";
        }

    }

}