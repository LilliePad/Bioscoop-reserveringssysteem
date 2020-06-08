using Project.Base;
using Project.Helpers;
using Project.Records;
using Project.Services;

namespace Project.Models {

    public class User : Model {

        public int id = -1;
        public string fullName;
        public string username;
        public string password { get; private set; }
        public bool admin;

        public User(UserRecord record) {
            id = record.id;
            fullName = record.fullName;
            username = record.username;
            password = record.password;
            admin = record.admin;
        }

        public User(string fullName, string username, string password, bool admin) {
            this.fullName = fullName;
            this.username = username;
            SetPassword(password);
            this.admin = admin;
        }

        public override bool Validate() {
            UserService userService = Program.GetInstance().GetService<UserService>("users");

            // Make sure fullName is set
            if (fullName == null || fullName.Length == 0) {
                AddError("fullName", "Dit veld is vereist");
                return false;
            }

            // Make sure username is set
            if (username == null || username.Length == 0) {
                AddError("username", "Dit veld is vereist");
                return false;
            }

            // Make sure username is unique
            User existing = userService.GetUserByUsername(username);

            if (existing != null && existing.id != id) {
                AddError("username", "Deze gebruikersnaam is al in gebruik");
                return false;
            }

            // Make sure password is set
            if (password == null || password.Length == 0) {
                AddError("password", "Dit veld is vereist");
                return false;
            }

            return true;
        }

        // Sets the password
        public void SetPassword(string password) {
            this.password = password != null ? EncryptionHelper.CreateHash(password) : null; //Ow0

        }

        // Returns whether the specified password is correct
        public bool Authenticate(string password) {
            string hash = EncryptionHelper.CreateHash(password);
            return this.password.Equals(hash);
        }

    }

}
