using System.Collections.Generic;
using Project.Base;
using Project.Records;

namespace Project.Data {

    class UserDatabase : Database {

        public List<UserRecord> users = new List<UserRecord>();

        public override string GetFileName() {
            return "users";
        }

    }

}