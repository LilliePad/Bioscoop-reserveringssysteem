using System.Text.RegularExpressions;
using Project.Base;

namespace Project.Commands.Validation {

    class RegexValidator : QuestionValidator {

        private readonly Regex regex;
        private readonly string format;

        public RegexValidator(Regex regex, string format) {
            this.regex = regex;
            this.format = format;
        }

        public string GetText() {
            return format;
        }

        public bool Validate(string value) {
            return regex.Matches(value).Count > 0;
        }
    }

}
