using System;
using System.Linq;

namespace Project.Helpers {

    public class StringHelper {

        private static Random RANDOM = new Random();
        private static string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomString(int length) {
            return new string(Enumerable.Repeat(CHARS, length).Select(s => s[RANDOM.Next(s.Length)]).ToArray());
        }

    }

}
