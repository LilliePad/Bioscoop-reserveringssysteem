using Project.Base;

namespace Project.Models {

    class User : Model {

        private int id;
        private string fullName;
        private string username;
        private string password;
        private bool admin;

        public User(int id, string fullName, string username, string password, bool admin) {
            this.id = id;
            this.fullName = fullName;
            this.username = username;
            this.password = password;
            this.admin = admin;
        }

        public int getId() {
            return this.id;
        }

        public string getFullName() {
            return this.fullName;
        }

        public void setFullName(string fullName) {
            this.fullName = fullName;
        }

        public string getUsername() {
            return this.username;
        }

        public void setUsername(string username) {
            this.username = username;
        }

        public string getPassword() {
            return this.password;
        }

        public void setPassword(string password) {
            this.password = password;
        }

        public bool isAdmin() {
            return this.admin;
        }

        public void setAdmin(bool admin) {
            this.admin = admin;
        }

    }

}
