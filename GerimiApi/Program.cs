// See https://aka.ms/new-console-template for more information

using System.Net.Http.Json;
using System.Text;
using GenerativeAI.Classes;
using GenerativeAI.Models;
using GenerativeAI.Tools;
using GenerativeAI.Types;
using Newtonsoft.Json;

public class Gem : GenerativeModel
{
    public Gem(string apiKey, ModelParams modelParams, HttpClient? client = null, ICollection<ChatCompletionFunction>? functions = null, IReadOnlyDictionary<string, Func<string, CancellationToken, Task<string>>>? calls = null, string? systemInstruction = null) : base(apiKey, modelParams, client, functions, calls, systemInstruction)
    {
    }

    public Gem(string apiKey, string model = "gemini-pro", HttpClient? client = null, ICollection<ChatCompletionFunction>? functions = null, IReadOnlyDictionary<string, Func<string, CancellationToken, Task<string>>>? calls = null, string? systemInstruction = null) : base(apiKey, model, client, functions, calls, systemInstruction)
    {
    }

    public void Do()
    {
        // base.BaseUrl
    }
}


internal class Program
{
    private const string ImagePath = @"C:\Users\kulivers\Desktop\eva.jpg";
    private const string ApiKey = "AIzaSyB4nGpiSiBl717lJ_NfD-GVlMZrlvW9Bc0";
    private const string Uri = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={ApiKey}";

    public static void Main(string[] args)
    {
        M2ain(args).GetAwaiter().GetResult();
    }

    public static async Task M2ain(string[] args)
    {
        var imageBytes = await File.ReadAllBytesAsync(ImagePath);

        string prompt = "What is in the image?";

        var visionModel = new GenerativeAI.Models.GoogleAIModels();
        //
        // var result = await visionModel.GenerateContentAsync(prompt, new FileObject(imageBytes, "eva.jpg"));
        //
        // Console.WriteLine(result.Text());
    }

    public static async Task Example(string[] args)
    {
        // await TestImage();
        // return;
        var model = new GenerativeModel(ApiKey);
        //or var model = new GeminiProModel(apiKey)

        var chat = model.StartChat(new StartChatParams());

        var parts = new List<Part>();
        var result = await chat.SendMessageAsync("Write a poem");
        Console.WriteLine("Initial Poem\r\n");
        Console.WriteLine(result);

        var result2 = await chat.SendMessageAsync("Make it longer");
        Console.WriteLine("Long Poem\r\n");
        Console.WriteLine(result2);
    }
}