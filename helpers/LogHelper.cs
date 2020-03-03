using System;
using Project_Enums;

namespace Project_Helpers {

    class LogHelper {

        public static void Log(LogType type, string message) {
            Console.WriteLine("[" + type + "] " + message);
        }

    }

}