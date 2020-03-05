using Project.Base;
using Project.Enums;
using Project.Helpers;

namespace Project.Commands {

    class Stop : Command {

        public override string GetName() {
            return "stop";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void RunCommand(string[] args) {
            LogHelper.Log(LogType.Info, "Stopping application...");
            Program.GetInstance().Stop();
        }

    }

}
