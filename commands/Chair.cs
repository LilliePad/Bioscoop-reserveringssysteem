using Project.Base;
using Project.Enums;
using Project.Helpers;

namespace Project.Commands
{

    class Chair : Command {

        public override string GetName() {
            return "chair";
        }
         

        public override bool RequireAdmin() {
            return true;
        }
        //format: chair row number price type
        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();

            if(args.Length != 4) {
                ConsoleHelper.Print(PrintType.Error, "Usage: chair <row> <number> <price> <type>");
                return;
            }
            ConsoleHelper.Print(PrintType.Info, "Chair succefully added");
        }
    }
}
