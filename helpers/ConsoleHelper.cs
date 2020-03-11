using Project.Enums;

namespace Project.Helpers {

    class ConsoleHelper {

        // Prints a typed message to the console
        public static void Print(LogType type, string message) {
            string prefix = type == LogType.Default ? "" : ("[" + type + "] ");
            System.Console.WriteLine(prefix + message);
        }

        // Prints a message to the console
        public static void Print(string message) {
            Print(LogType.Default, message);
        }

    }

}