using System.Collections.Generic;

namespace Project.Base {

    class Model {

        // List of validation errors
        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        // Validates the model
        public virtual bool Validate() {
            return true;
        }

        // Adds an error to this model
        public void AddError(string attribute, string error) {
            List<string> errors = this.GetErrors(attribute);

            // Add error if not present already
            if(!errors.Contains(error)) {
                errors.Add(error);
                this.errors[attribute] = errors;
            }
        }

        // Returns all errors
        public Dictionary<string, List<string>> GetErrors() {
            return this.errors;
        }

        // Returns all errors for the specified attribute
        public List<string> GetErrors(string attribute) {
            List<string> errors;

            // Get the error list
            if(!this.errors.TryGetValue(attribute, out errors)) {
                errors = new List<string>();
            }

            return errors;
        }

        // Returns whether this model has valiation errors
        public bool HasErrors() {
            return this.errors.Count > 0;
        }

    }

}
