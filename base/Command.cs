using System.Threading;
using Project.Enums;
using Project.Helpers;
using Project.Services;

namespace Project.Base {

    abstract class Command {

        public abstract string GetName();
        public abstract void RunCommand(string[] args);
        
        public virtual string GetCategory() {
            return null;
        }

        public virtual bool RequireLogin() {
            return true;
        }

        public virtual bool RequireAdmin() {
            return false;
        }

        protected string AskQuestion(string questionText) {
            Program app = Program.GetInstance();
            CommandManager commandManager = app.getService<CommandManager>("commands");
            UserManager userManager = app.getService<UserManager>("users");

            LogHelper.Log(LogType.Info, questionText);

            // Create question and wait for an answer
            Question question = new Question(questionText);
            commandManager.SetQuestion(question);

            while(question.GetAnswer() == null) {
                Thread.Sleep(1);
            }

            return question.GetAnswer();
        }

    }

}
