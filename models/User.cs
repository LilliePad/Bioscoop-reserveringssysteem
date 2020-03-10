using Project.Base;
using Project.Helpers;

namespace Project.Models {

    class User : Model {

        public int id { get; }
        public string fullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }

        public User(int id, string fullName, string username, string password, bool admin) {
            this.id = id;
            this.fullName = fullName;
            this.username = username;
            this.password = password;
            this.admin = admin;
        }

        public bool Authenticate(string password) {
            string hash = EncryptionHelper.CreateHash(password);
            return this.password.Equals(hash);
        }

    }

}
