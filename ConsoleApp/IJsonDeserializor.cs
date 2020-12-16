namespace ConsoleApp
{
    public interface IJsonDeserializor
    {
        T DeserializeObject<T>(string filePath);
    }
}