using System.Threading;
using Project.Enums;
using Project.Helpers;
using Project.Services;

namespace Project.Base {

    abstract class InteractiveCommand : Command {

        protected string AskQuestion(string questionText) {
            Program app = Program.GetInstance();
            CommandManager commandManager = app.GetService<CommandManager>("commands");
            UserManager userManager = app.GetService<UserManager>("users");

            LogHelper.Log(LogType.Info, questionText);

            // Create question and wait for an answer
            Question question = new Question(questionText);
            commandManager.SetQuestion(question);

            while (question.GetAnswer() == null) {
                Thread.Sleep(1);
            }

            return question.GetAnswer();
        }

    }

}
