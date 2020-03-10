using Project.Base;
using Project.Helpers;
using Project.Services;

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

            if (userManager.GetUserByUsername(username) != null) {
                this.AddError("username", "Username is al in gebruik.");
                return false;
            }

            if (password == null || password.Length == 0) {
                this.AddError("password", "Wachtwoord mag niet leeg zijn.");
                return false;
            }

            return true;
        }

        public bool Authenticate(string password) {
            string hash = EncryptionHelper.CreateHash(password);
            return this.password.Equals(hash);
        }

    }

}
