using Project.Base;
using Project.Helpers;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class User : Model {

        public int id = -1;
        public string fullName;
        public string username;
        public string password;
        public bool admin;

        public User(UserRecord record) {
            this.id = record.id;
            this.fullName = record.fullName;
            this.username = record.username;
            this.password = record.password;
            this.admin = record.admin;
        }

        public User(string fullName, string username, string password, bool admin) {
            this.fullName = fullName;
            this.username = username;
            this.password = password;
            this.admin = admin;
        }

        private User(int id, string fullName, string username, string password, bool admin) {
            this.id = id;
            this.fullName = fullName;
            this.username = username;
            this.password = password;
            this.admin = admin;
        }

        public override bool Validate() {
            UserManager userManager = Program.GetInstance().GetService<UserManager>("users");

            if(fullName == null || fullName.Length == 0) {
                this.AddError("fullName", "Volledige naam mag niet leeg zijn.");
                return false;
            }

            if (username == null || username.Length == 0) {
                this.AddError("username", "Username mag niet leeg zijn.");
                return false;
            }

            User existing = userManager.GetUserByUsername(username);

            if (existing != null && existing.id != id) {
                this.AddError("username", "Username is al in gebruik.");
                return false;
            }

            if (password == null || password.Length == 0) {
                this.AddError("password", "Wachtwoord mag niet leeg zijn.");
                return false;
            }

            return true;
        }

        // Returns whether the specified password is correct
        public bool Authenticate(string password) {
            string hash = EncryptionHelper.CreateHash(password);
            return this.password.Equals(hash);
        }

    }

}
