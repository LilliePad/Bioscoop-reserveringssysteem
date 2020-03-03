using System;
using Project_Base;

namespace Project_Commands {

    class CreateUser : Command {

        public override string GetName() {
            return "create-user";
        }

        public override void RunCommand(string[] args) {
            Console.WriteLine("Test 123");

            if(args.Length >= 1) {
                Console.WriteLine("Arg 0: " + args[0]);
            }
        }

    }

}
