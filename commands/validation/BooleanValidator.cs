namespace Project.Commands.Validation {

    class BooleanValidator : OptionsValidator {

        public static readonly string[] OPTIONS = new string[] { "ja", "nee" };

        public BooleanValidator() : base(OPTIONS) { }

    }

}
