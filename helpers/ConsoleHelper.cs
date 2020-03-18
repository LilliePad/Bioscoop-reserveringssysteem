using System.Collections.Generic;
using Project.Base;
using Project.Enums;

namespace Project.Helpers {

    class ConsoleHelper {

        // Prints a typed message to the console
        public static void Print(PrintType type, string message) {
            string prefix = type == PrintType.Default ? "" : ("[" + type + "] ");
            System.Console.WriteLine(prefix + message);
        }

        // Prints a message to the console
        public static void Print(string message) {
            Print(PrintType.Default, message);
        }

        // Prints all errors for the specified model
        public static void PrintErrors(Model model) {
            foreach (KeyValuePair<string, List<string>> attribute in model.GetErrors()) {
                foreach (string error in attribute.Value) {
                    Print(PrintType.Error, attribute.Key + " -> " + error);
                }
            }
        }

    }

}