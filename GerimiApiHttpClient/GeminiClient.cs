using System.Text;
using GerimiApiHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class LowercaseContractResolver : DefaultContractResolver
{
    protected override string ResolvePropertyName(string propertyName)
    {
        return propertyName.ToLowerInvariant();
    }
}

public class GeminiClient
{
    private const string ApiKey = "AIzaSyB4nGpiSiBl717lJ_NfD-GVlMZrlvW9Bc0";
    private const string Uri = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={ApiKey}";

    public HttpResponseMessage SendText(string requestText)
    {
        var geminiTextRequest = GeminiRequest.CreateTextRequest(requestText);
        return SendRequest(geminiTextRequest);
    }

    public HttpResponseMessage SendImage(string requestText, string filePath)
    {
        using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        var geminiTextRequest = GeminiRequest.CreateImageRequest(requestText, fileStream);
        return SendRequest(geminiTextRequest);
    }

    private HttpResponseMessage SendRequest(GeminiRequest gRequest)
    {
        using (var client = new HttpClient())
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver(),
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(gRequest, settings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(Uri),
                Content = content,
                Method = HttpMethod.Post
            };

            return client.Send(request);
        }
    }
}