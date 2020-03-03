using System;
using Project.Enums;

namespace Project.Helpers {

    class LogHelper {

        public static void Log(LogType type, string message) {
            Console.WriteLine("[" + type + "] " + message);
        }

    }

}