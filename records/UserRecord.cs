using Project.Base;
using Project.Helpers;
using Project.Models;

namespace Project.Records {

    class UserRecord : Record {

        public int id;
        public string fullName;
        public string username;
        public string password;
        public bool admin;

        public UserRecord() {  }

        public UserRecord(User model) {
            this.id = model.id;
            this.fullName = model.fullName;
            this.username = model.username;
            this.password = model.password;
            this.admin = model.admin;
        }

    }

}
