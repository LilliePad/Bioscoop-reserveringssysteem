using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Services;
using Project.Models;

namespace Project.Commands
{

    class ChairCreate : Command {

        public override string GetName() {
            return "chair";
        }
        

        public override bool RequireAdmin() {
            return true;
        }
        //format: chair row number price type
        public override void RunCommand(string[] args) {
            Program app = Program.GetInstance();
            ChairManager chairManager = app.GetService<ChairManager>("chairs");
            if (args.Length != 4) {
                ConsoleHelper.Print(PrintType.Error, "Usage: chair <row> <number> <price> <type>");
                return;
            }
            Chair chair = new Chair(Int32.Parse(args[0]), Int32.Parse(args[1]), Double.Parse(args[2]), args[3]);

            // Login if registration successful
            if (chairManager.SaveChair(chair)) {
                ConsoleHelper.Print(PrintType.Info, "Stoel aangemaakt");
            }
            else {
                ConsoleHelper.Print(PrintType.Info, "Kon stoel niet aanmaken. Errors:");
                ConsoleHelper.PrintErrors(chair);
            }
 
        }
    }
}
