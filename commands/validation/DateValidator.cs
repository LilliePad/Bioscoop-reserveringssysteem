namespace Project.Commands.Validation {

    class DateValidator : RegexValidator {

        public DateValidator() : base(Program.DATE_REGEX, Program.DATE_FORMAT) { }

    }
}