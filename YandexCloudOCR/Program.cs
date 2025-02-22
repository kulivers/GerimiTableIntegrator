// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using YandexCloudOCR;

internal class Program
{
    public static void Main(string[] args)
    {
        var mock = "C:\\Users\\kulivers\\AppData\\Roaming\\JetBrains\\Rider2023.3\\scratches\\table.json";
        var json = File.ReadAllText(mock);
        var response = JsonConvert.DeserializeObject<TableResponse>(json);
        var table = response.result.textAnnotation.tables.First();
    }
}
