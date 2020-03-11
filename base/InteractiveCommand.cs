using System;
using System.Threading;
using Project.Enums;
using Project.Helpers;
using Project.Services;

namespace Project.Base {

    abstract class InteractiveCommand : Command {

        // Prints the question and blocks until we're got an answer
        protected string AskQuestion(string questionText) {
            Program app = Program.GetInstance();
            CommandManager commandManager = app.GetService<CommandManager>("commands");
            UserManager userManager = app.GetService<UserManager>("users");

            ConsoleHelper.Print(LogType.Info, questionText);

            // Create question and wait for an answer
            Question question = new Question(questionText);

            // Try to register the question
            if(!commandManager.SetQuestion(question)) {
                throw new Exception("Failed to register question");
            }

            // Block the thead until we've got an answer
            while (question.GetAnswer() == null) {
                Thread.Sleep(1);
            }

            // Return the answer
            return question.GetAnswer();
        }

    }

}
