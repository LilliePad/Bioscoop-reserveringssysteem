using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Project.Base;
using Project.Enums;
using Project.Helpers;

namespace Project.Services {

    class ConsoleService : Service {

        // All registered commands
        private readonly Dictionary<String, Command> commands = new Dictionary<String, Command>();

        // The current question
        private Question question;

        public override string GetHandle() {
            return "console";
        }

        public override void Load() {
            Program app = Program.GetInstance();
            UserService userService = app.GetService<UserService>("users");
            string line;

            // Start listening for commands
            while ((line = Console.ReadLine()) != null) {
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

                        // Check if command exists
                        if (!commands.TryGetValue(name, out Command command)) {
                            ConsoleHelper.Print(PrintType.Error, "Onbekend commando");
                            continue;
                        }

                        // Check if the user is logged in
                        if ((command.RequireLogin() || command.RequireAdmin()) && userService.GetCurrentUser() == null) {
                            ConsoleHelper.Print(PrintType.Error, "Je moet ingelogd zijn om dit command te gebruiken");
                            continue;
                        }

                        // Check if the user is an admin
                        if (command.RequireAdmin() && !userService.GetCurrentUser().admin) {
                            ConsoleHelper.Print(PrintType.Error, "Je moet admin zijn om dit command te gebruiken");
                            continue;
                        }

                        // Create thread to be blocked while waiting for an answer
                        if(command is InteractiveCommand) {
                            new Thread(() => {
                                this.RunCommand(command, args);
                            }).Start();
                        // Run command code on main thread
                        } else {
                            this.RunCommand(command, args);
                        }
                    }
                }
            }
        }

        // Registers a command
        public void RegisterCommand(Command command) {
            commands.Add(command.GetKey(), command);
        }

        // Sets the current question
        public bool SetQuestion(Question question) {
            if(this.question != null) {
                return false;
            }

            this.question = question;
            return true;
        }

        // Runs a command and handles exceptions
        private void RunCommand(Command command, string[] args) {
            try {
                command.RunCommand(args);
            } catch(ArgumentException e) {
                ConsoleHelper.Print(PrintType.Error, e.Message);
            } catch(Exception e) {
                ConsoleHelper.Print(PrintType.Error, "Er is een fout opgetreden: " + e.Message);
            }
        }

        // Returns all registeren commands
        public List<Command> GetCommands() {
            return commands.Values.ToList();
        }

    }

}
