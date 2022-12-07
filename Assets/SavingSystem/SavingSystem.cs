using Newtonsoft.Json;
using SavingSystems.Interfaces;
using System.IO;

namespace SavingSystems.Systems
{
    public class SavingSystem<T> : IDataSaver<T>
    {
        public void SaveObject(T savingObject, string path)
        {
            File.WriteAllText(path,
            JsonConvert.SerializeObject(savingObject, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
            ));
        }

        public void SaveObjects(T[] savingObjects, string path)
        {
            File.WriteAllText(path,
            JsonConvert.SerializeObject(savingObjects, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
            ));
        }

        public T LoadObject(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        public T[] LoadObjects(string path)
        {
            return JsonConvert.DeserializeObject<T[]>(File.ReadAllText(path));
        }
    }
}
