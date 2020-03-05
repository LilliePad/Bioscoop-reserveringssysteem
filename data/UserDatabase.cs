using System.Collections.Generic;
using Project.Base;
using Project.Models;

namespace Project.Data {

    class UserDatabase : Database {

        public List<User> users = new List<User>();

        public override string GetFileName() {
            return "users";
        }

        public List<User> GetUsers() {
            return this.users;
        }

        public void AddUser(User user) {
            users.Add(user);
        }

        public void RemoveUser(User user) {
            users.Remove(user);
        }

    }

}