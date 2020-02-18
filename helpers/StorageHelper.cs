using System.IO;
using Newtonsoft.Json;

namespace Project_Helpers {

    class StorageHelper {

        public static T LoadFile<T>(string path, T clazz) where T : class {
            string content = File.ReadAllText(path);
            return (T) JsonConvert.DeserializeObject<T>(path);
        }

        public static void SaveFile(string path, object data) {
            string content = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, content);
        }

    }

}