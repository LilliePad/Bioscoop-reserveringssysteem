using System.Collections.Generic;
using Project.Base;
using Project.Models;

namespace Project.Data {

    class Database : BaseDatabase {

        public List<User> user;

        public override string GetFileName() {
            return "data";
        }

    }

}