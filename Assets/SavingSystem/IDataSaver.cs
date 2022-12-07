namespace SavingSystems.Interfaces
{
    public interface IDataSaver<T>
    {
        void SaveObject(T data, string path);
        void SaveObjects(T[] data, string path);

        T LoadObject(string path);
        T[] LoadObjects(string path);
    }
}
