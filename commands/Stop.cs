using System;
using Project.Base;

namespace Project.Commands {

    class Stop : Command {

        public override string GetName() {
            return "stop";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            Console.WriteLine("Stopping application...");
            Program.GetInstance().Stop();
        }

    }

}
