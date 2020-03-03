using System;
using Project.Base;

namespace Project.Commands {

    class CreateUser : Command {

        public override string GetCategory() {
            return "user";
        }

        public override string GetName() {
            return "create";
        }

        public override void RunCommand(string[] args) {
            Console.WriteLine("Test 123");

            if(args.Length >= 1) {
                Console.WriteLine("Arg 0: " + args[0]);
            }
        }

    }

}
