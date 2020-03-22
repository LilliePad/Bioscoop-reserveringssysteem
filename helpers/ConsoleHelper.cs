using System;
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

        // Parses an int value
        public static int ParseInt(string value, string paramName = null) {
            try {
                return Int32.Parse(value);
            } catch(FormatException) {
                throw new ArgumentException((paramName ?? value) + " moet een integer zijn.");
            }
        }

        // Parses an double value
        public static double ParseDouble(string value, string paramName = null) {
            try {
                return Double.Parse(value);
            } catch (FormatException) {
                throw new ArgumentException((paramName ?? value) + " moet een double zijn.");
            }
        }

        // Parses an boolean value
        public static bool ParseBoolean(string value, string paramName = null) {
            switch(value) {
                case "ja":
                case "yes":
                case "true":
                    return true;
                case "nee":
                case "no":
                case "false":
                    return false;
                default:
                    throw new ArgumentException((paramName ?? value) + " moet een boolean zijn.");
            }
        }

    }

}