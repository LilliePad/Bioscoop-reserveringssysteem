using System.Collections.Generic;

namespace Project.Base {

    class Model {

        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public virtual bool Validate() {
            return true;
        }

        public void AddError(string attribute, string error) {
            List<string> errors = this.GetErrors(attribute);

            // Add error if not present already
            if(!errors.Contains(error)) {
                errors.Add(error);
                this.errors[attribute] = errors;
            }
        }

        public Dictionary<string, List<string>> GetErrors() {
            return this.errors;
        }

        public List<string> GetErrors(string attribute) {
            List<string> errors;

            // Get the error list
            if(!this.errors.TryGetValue(attribute, out errors)) {
                errors = new List<string>();
            }

            return errors;
        }

        public bool HasErrors() {
            return this.errors.Count > 0;
        }

    }

}
