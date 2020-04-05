using System.Linq;
using Project.Base;

namespace Project.Commands.Validation {

    class OptionsValidator : QuestionValidator {

        private readonly string[] options;

        public OptionsValidator(string[] options) {
            this.options = options;
        }

        public OptionsValidator(string option) {
            options = new string[] { option };
        }

        public string GetText() {
            return string.Join(", ", options);
        }

        public bool Validate(string value) {
            return options.Contains(value);
        }
    }

}
