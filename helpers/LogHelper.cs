using Project.Enums;

namespace Project.Helpers {

    class LogHelper {

        public static void Log(LogType type, string message) {
            System.Console.WriteLine("[" + type + "] " + message);
        }

    }

}