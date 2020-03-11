using System.Collections.Generic;
using Project.Base;
using Project.Models;

namespace Project.Data {

    class UserDatabase : Database {

        public List<User> users = new List<User>();

        public override string GetFileName() {
            return "users";
        }

    }

}