using System;
using Project_Enums;

namespace Project_Helpers {

    class LogHelper {

        public static void log(LogType type, string message) {
            Console.WriteLine("[" + type + "] " + message);
        }

    }

}