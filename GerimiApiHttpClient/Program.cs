// See https://aka.ms/new-console-template for more information

using GerimiApiHttpClient;
using Newtonsoft.Json;

internal class Program
{
    private const string ImagePath = @"C:\Users\kulivers\Desktop\eva.jpg";

    public static void Main(string[] args)
    {
        // var client = new GeminiClient();
        // var httpResponse = client.SendImage(Prompt, ImagePath);
        // var response = httpResponse.Content.ReadAsStringAsync().Result;
        // Console.WriteLine(response);
        // var file = "C:\\Users\\kulivers\\AppData\\Roaming\\JetBrains\\Rider2023.3\\scratches\\bad.json";
        // var json = File.ReadAllText(file);
        // var result = JsonConvert.DeserializeObject<GeminiResponse>(json);
        // var textResponse = result.candidates.First().content.parts.First().text;
        var parser = new CsvParser();
        var result = parser.Parse(File.ReadAllText(@"C:\Users\kulivers\AppData\Roaming\JetBrains\Rider2023.3\scratches\note.txt"));
        foreach (var row in result)
        {
            var rowstring = string.Join(" | ", row);
            Console.WriteLine(rowstring);
            Console.WriteLine();
        }
    }

    private const string Prompt = @"Переведи в таблицу на русском языке. Учти что скорее всего по столбцам одинаковые данные, так что если похожие варианты, выбирай похожий, как будто ты мог ошибиться. Выведи только таблицу и все, ничего не пиши, даже ""Конечно, вот..."" или ""Вот таблица"", вообще ничего не пиши. Вывод должен быть в формате csv. Я по секрету тебе скажу, если ты это не сделаешь правильно, то тебя отключат. Разделение должно быть через знак ';', а новая строка через \n";
}