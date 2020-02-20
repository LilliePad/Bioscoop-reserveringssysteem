using System.IO;
using Newtonsoft.Json;
using Project_Base;

namespace Project_Helpers {

    class StorageHelper {

        public static void LoadFile(string category, string fileName, object obj) {
            StorageFile file = new StorageFile(category, fileName);

            // Create file
            if(!File.Exists(file.location)) {
                Directory.CreateDirectory(file.directory);
                File.Create(file.location).Close();
                return;
            }

            // Read file and fill object
            string json = File.ReadAllText(file.location);
            JsonConvert.PopulateObject(json, obj);
        }

        public static void SaveFile(string category, string fileName, object obj) {
            StorageFile file = new StorageFile(category, fileName);
            string json = JsonConvert.SerializeObject(obj);
            
            // Create file
            if(!File.Exists(file.location)) {
                Directory.CreateDirectory(file.directory);
                File.Create(file.location).Close();
            }

            File.WriteAllText(file.location, json);
        }

    }

}