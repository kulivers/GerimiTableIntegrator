using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GerimiApiHttpClient;

public class Content
{
    public Content(IEnumerable<Part> parts)
    {
        Parts = parts;
    }

    public IEnumerable<Part> Parts { get; set; }
    // public string Role { get; set; }
}

public class ContentPart
{
    public ContentPart(TextPart textPart, InlineData inlineData)
    {
        InlineData = inlineData;
        Text = textPart;
    }
    public ContentPart(TextPart textPart)
    {
        Text = textPart;
    }
    
    public ContentPart(InlineData inlineData)
    {
        InlineData = inlineData;
    }
    
    [JsonProperty("text")]
    public TextPart Text { get; set; }

    [JsonProperty("inline_data")]
    public InlineData InlineData { get; set; }
}

public class ImagePart : Part
{
    private const string MimeType = "image/jpeg";

    [JsonProperty("inline_data")]
    public InlineData InlineData { get; set; }
    public ImagePart(Stream imageStream)
    {
        InlineData = new InlineData(MimeType, ConvertToBase64(imageStream));
    }

    private static string ConvertToBase64(Stream imageStream)
    {
        if (imageStream == null)
        {
            throw new ArgumentNullException(nameof(imageStream), "Image stream cannot be null.");
        }

        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Копируем данные из входного потока в память
            imageStream.CopyTo(memoryStream);
            byte[] imageBytes = memoryStream.ToArray();

            // Конвертируем байты в строку Base64
            return Convert.ToBase64String(imageBytes);
        }
    }
}

public class InlineData
{
    public InlineData(string mimeType, string data)
    {
        MimeType = mimeType;
        Data = data;
    }

    [JsonProperty("mime_type")]
    public string MimeType { get; set; }

    public string Data { get; set; }
}

public class TextPart : Part
{
    public TextPart(string text)
    {
        Text = text;
    }

    public string Text { get; set; }
}

public abstract class Part
{
}