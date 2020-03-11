namespace Project.Base {

    class Question {

        public static readonly string OPTION_YES = "ja";
        public static readonly string OPTION_NO = "nee";
        public static readonly string[] OPTIONS_BOOL = new string[] { OPTION_YES, OPTION_NO };

        // The question to be asked
        private string question;

        // The valid options
        private string[] options;

        // The default value
        private string defaultValue;

        // The answer (null until answered)
        private string answer;

        // The object used for locking the answer variable
        private readonly object answerLock = new object();

        public Question(string question, string[] options = null, string defaultValue = null) {
            this.question = question;
            this.options = options;
            this.defaultValue = defaultValue;
        }

        // Returns the question
        public string GetQuestion() {
            return this.question;
        }

        // Returns the message
        public string GetMessage() {
            string message = question;

            // Append options to question text
            if (options != null && options.Length > 0) {
                message += " (" + string.Join(", ", options) + ")";
            }

            // Append default value to question text
            if (defaultValue != null) {
                message += " [" + defaultValue + "]";
            }

            return message;
        }

        // Returns the options
        public string[] GetOptions() {
            return this.options;
        }

        // Returns the default value
        public string GetDefaultValue() {
            return this.defaultValue;
        }

        // Returns the answer or null
        public string GetAnswer() {
            lock(this.answerLock) {
                return this.answer;
            }
        }

        // Sets the answer
        public void SetAnswer(string answer) {
            lock (this.answerLock) {
                this.answer = answer;
            }
        }

    }

}
