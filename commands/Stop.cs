using System;
using Project;
using Project_Base;

namespace Project_Commands {

    class Stop : Command {

        public override string GetName() {
            return "stop";
        }

        public override void RunCommand(string[] args) {
            Console.WriteLine("Stopping application...");
            Program.GetInstance().Stop();
        }

    }

}
