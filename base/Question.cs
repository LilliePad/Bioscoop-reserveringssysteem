namespace Project.Base {

    class Question {

        // The question to be asked
        private string question;

        // The answer (null until answered)
        private string answer;

        // The object used for locking the answer variable
        private readonly object answerLock = new object();

        public Question(string question) {
            this.question = question;
        }

        // Returns the question
        public string GetQuestion() {
            return this.question;
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
