namespace Project.Base {

    class Question {

        // The question to be asked
        private readonly string question;

        // The validator
        private readonly QuestionValidator validator;

        // The default value
        private readonly string defaultValue;

        // The answer (null until answered)
        private string answer;

        // The object used for locking the answer variable
        private readonly object answerLock = new object();

        public Question(string question, QuestionValidator validator = null, string defaultValue = null) {
            this.question = question;
            this.validator = validator;
            this.defaultValue = defaultValue;
        }

        // Returns the question
        public string GetQuestion() {
            return question;
        }

        // Returns the message
        public string GetMessage() {
            string message = question;

            // Append options to question text
            if (validator != null) {
                message += " (" + validator.GetText() + ")";
            }

            // Append default value to question text
            if (defaultValue != null) {
                message += " [" + defaultValue + "]";
            }

            return message;
        }

        // Returns the validator
        public QuestionValidator GetValidator() {
            return validator;
        }

        // Returns the default value
        public string GetDefaultValue() {
            return defaultValue;
        }

        // Returns the answer or null
        public string GetAnswer() {
            lock(answerLock) {
                return answer;
            }
        }

        // Sets the answer
        public void SetAnswer(string answer) {
            lock (answerLock) {
                this.answer = answer;
            }
        }

    }

}
