using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Project.Base;
using Project.Enums;
using Project.Helpers;

namespace Project.Services {

    class CommandManager : Service {

        // All registered commands
        private readonly Dictionary<String, Command> commands = new Dictionary<String, Command>();

        // The current question
        private Question question;

        public override string getHandle() {
            return "commands";
        }

        public override void Load() {
            Program app = Program.GetInstance();
            UserManager userManager = app.GetService<UserManager>("users");
            string line;

            // Start listening for commands
            while (Program.GetInstance().IsRunning() && (line = Console.ReadLine()) != null) {
                // Answer question
                if (question != null) {
                    question.SetAnswer(line);
                    question = null;
                } else {
                    // Get data and ignore empty input
                    string[] data = line.Split(' ');

                    if (data.Length >= 1) {
                        // Prepare values
                        string name = data[0];
                        string[] args = data.Skip(1).ToArray();

                        // Find command
                        Command command;

                        // Check if command exists
                        if (!commands.TryGetValue(name, out command)) {
                            ConsoleHelper.Print(PrintType.Error, "Unknown command");
                            continue;
                        }

                        // Check if the user is logged in
                        if ((command.RequireLogin() || command.RequireAdmin()) && userManager.GetCurrentUser() == null) {
                            ConsoleHelper.Print(PrintType.Error, "Je moet ingelogd zijn om dit command te gebruiken.");
                            continue;
                        }

                        // Check if the user is an admin
                        if (command.RequireAdmin() && !userManager.GetCurrentUser().admin) {
                            ConsoleHelper.Print(PrintType.Error, "Je moet admin zijn om dit command te gebruiken.");
                            continue;
                        }

                        // Create thread to be blocked while waiting for an answer
                        if(command is InteractiveCommand) {
                            new Thread(() => {
                                command.RunCommand(args);
                            }).Start();
                        // Run command code on main thread
                        } else {
                            command.RunCommand(args);
                        }
                    }
                }
            }
        }

        public void RegisterCommand(Command command) {
            string category = command.GetCategory();
            string name = (category != null ? (category + "/") : "") + command.GetName();
            commands.Add(name, command);
        }

        public bool SetQuestion(Question question) {
            if(this.question != null) {
                return false;
            }

            this.question = question;
            return true;
        }

    }

}
