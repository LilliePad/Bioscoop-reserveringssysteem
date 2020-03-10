using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Project.Base;
using Project.Enums;
using Project.Helpers;

namespace Project.Services {

    class CommandManager : Service {

        private readonly Dictionary<String, Command> commands = new Dictionary<String, Command>();
        private Question question;

        public override string getHandle() {
            return "commands";
        }

        // Start listening for commands
        public override void Load() {
            Program app = Program.GetInstance();
            UserManager userManager = app.GetService<UserManager>("users");
            string line;

            while ((line = Console.ReadLine()) != null && Program.GetInstance().IsRunning()) {
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

                        if (!commands.TryGetValue(name, out command)) {
                            LogHelper.Log(LogType.Error, "Unknown command");
                            continue;
                        }

                        if ((command.RequireLogin() || command.RequireAdmin()) && userManager.GetCurrentUser() == null) {
                            LogHelper.Log(LogType.Error, "Je moet ingelogd zijn om dit command te gebruiken.");
                            continue;
                        }

                        if (command.RequireAdmin() && !userManager.GetCurrentUser().admin) {
                            LogHelper.Log(LogType.Error, "Je moet admin zijn om dit command te gebruiken.");
                            continue;
                        }

                        // Create thread which the command can block
                        new Thread(() => {
                            command.RunCommand(args);
                        }).Start();
                    }
                }
            }
        }

        public void RegisterCommand(Command command) {
            string category = command.GetCategory();
            string name = (category != null ? (category + "/") : "") + command.GetName();
            commands.Add(name, command);
        }

        public void SetQuestion(Question question) {
            this.question = question;
        }

    }

}
