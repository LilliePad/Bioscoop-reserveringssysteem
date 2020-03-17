﻿using System;
using System.Linq;
using System.Threading;
using Project.Enums;
using Project.Helpers;
using Project.Services;

namespace Project.Base {

    abstract class InteractiveCommand : Command {

        // Prints the question and blocks until we're got an answer
        protected string AskQuestion(string questionText, string[] options = null, string defaultValue = null) {
            Question question = new Question(questionText, options, defaultValue);

            // Print question
            ConsoleHelper.Print(PrintType.Default, question.GetMessage());

            // Get answer and return
            return this.WaitForAnswer(question);
        }

        private string WaitForAnswer(Question question) {
            Program app = Program.GetInstance();
            CommandManager commandManager = app.GetService<CommandManager>("commands");

            // Try to register the question
            if (!commandManager.SetQuestion(question)) {
                throw new Exception("Failed to register question");
            }

            // Block the thead until we've got an answer
            while (question.GetAnswer() == null) {
                Thread.Sleep(1);
            }

            string answer = question.GetAnswer();

            // Return default if answer is empty
            if (question.GetDefaultValue() != null && answer.Length == 0) {
                return question.GetDefaultValue();
            }

            // Validate value
            if (question.GetOptions() != null && !question.GetOptions().Contains(answer)) {
                ConsoleHelper.Print(PrintType.Error, "Invalid answer: " + answer);
                question.SetAnswer(null);
                return this.WaitForAnswer(question);
            }

            // Return answer
            return answer;
        }

    }

}