﻿using System;
using System.Linq;
using System.Collections.Generic;
using Project;
using Project_Base;
using Project_Enums;
using Project_Helpers;

namespace Project_Managers {

    class CommandManager {

        private readonly Dictionary<String, Command> commands = new Dictionary<String, Command>();

        // Start listening for commands
        public void Start() {
            string line;

            while ((line = Console.ReadLine()) != null && Program.GetInstance().IsRunning()) {
                string[] data = line.Split(' ');

                // Ignore empty input
                if(data.Length < 1) {
                    continue;
                }

                // Prepare values
                string name = data[0];
                string[] args = data.Skip(1).ToArray();

                // Find command
                Command command;

                if (!commands.TryGetValue(name, out command)) {
                    LogHelper.Log(LogType.Error, "Unknown command");
                    return;
                }

                command.RunCommand(args);
            }
        }

        public void RegisterCommand(Command command) {
            commands.Add(command.GetName(), command);
        }

    }

}
