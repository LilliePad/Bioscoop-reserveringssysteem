using System.IO;
using Newtonsoft.Json;
using Project.Base;

namespace Project.Helpers {

    public class StorageHelper {

        // Fill an objects properties from a json file
        public static void LoadFile(string category, string fileName, object obj) {
            StorageFile file = new StorageFile(category, fileName + ".json");

            // Ignore if file does not exist
            if(!File.Exists(file.location)) {
                return;
            }

            // Read file and fill object
            string json = File.ReadAllText(file.location);
            JsonConvert.PopulateObject(json, obj);
        }

        // Saves the object properties to a file
        public static void SaveFile(string category, string fileName, object obj) {
            StorageFile file = new StorageFile(category, fileName + ".json");
            string json = JsonConvert.SerializeObject(obj);
            
            // Create file
            if(!File.Exists(file.location)) {
                Directory.CreateDirectory(file.directory);
                File.Create(file.location).Close();
            }

            // Write contents
            File.WriteAllText(file.location, json);
        }

        // Uploads an image, returns StorageFile on success.
        public static StorageFile UploadImage(string source) {
            if(source == null) {
                return null;
            }

            // Build path
            string[] fileInfo = Path.GetFileName(source).Split('.');
            string fileExt = fileInfo[1];

            // Make sure the source exists 
            if (!File.Exists(source)) {
                throw new FileNotFoundException("Unable to find file: " + source);
            }

            // Create storage object
            string randomId = StringHelper.RandomString(50);
            StorageFile storage = new StorageFile("images", randomId + '.' + fileExt);

            if(!File.Exists(storage.directory)) {
                Directory.CreateDirectory(storage.directory);
            }

            if(File.Exists(storage.location)) {
                File.Delete(storage.location);
            }

            File.Copy(source, storage.location);

            return storage;
        }

    }

}