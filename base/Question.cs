namespace Project.Base {

    class Question {

        private string question;
        private string answer;

        public Question(string question) {
            this.question = question;
        }

        public string GetQuestion() {
            return this.question;
        }

        public string GetAnswer() {
            return this.answer;
        }

        public void SetAnswer(string answer) {
            this.answer = answer;
        }

    }

}
