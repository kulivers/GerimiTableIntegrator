// See https://aka.ms/new-console-template for more information

using DocumentsManagement;
using Newtonsoft.Json;
using YandexCloudOCR;
using YandexCloudOCR.Services;

internal class Program
{
    public static void Main(string[] args) 
    {
        var mock = "C:\\Users\\kulivers\\AppData\\Roaming\\JetBrains\\Rider2023.3\\scratches\\table.json";
        var json = File.ReadAllText(mock);
        var response = JsonConvert.DeserializeObject<TableResponse>(json);
        var converter = new ImageToTableConverter();
        var table = converter.ConvertToDict(response);
        ShowTable(table);
        var excelManager = new ExcelManager();
        var result = excelManager.CreateStreamFromTable(table);
    }

    private static void ShowTable(Dictionary<int, List<string>> table)
    {
        var array = table.Select(x=>x.Value).ToArray();
        foreach (var row in array)
        {
            Console.WriteLine(string.Join(" ", row));
            Console.WriteLine("__________________________________________");
        }
    }
}
