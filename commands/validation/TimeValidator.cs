namespace Project.Commands.Validation {

    class TimeValidator : RegexValidator {

        public TimeValidator() : base(Program.TIME_REGEX, Program.TIME_FORMAT) { }

    }
}