namespace Project.Base {

    class Question {

        private string question;
        private string answer;

        private object answerLock = new object();

        public Question(string question) {
            this.question = question;
        }

        public string GetQuestion() {
            return this.question;
        }

        public string GetAnswer() {
            lock(this.answerLock) {
                return this.answer;
            }
        }

        public void SetAnswer(string answer) {
            lock (this.answerLock) {
                this.answer = answer;
            }
        }

    }

}
