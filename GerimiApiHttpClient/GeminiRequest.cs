namespace GerimiApiHttpClient;

public class GeminiRequest
{
    public IEnumerable<Content> Contents { get; set; }

    public GeminiRequest()
    {
    }

    public GeminiRequest(IEnumerable<Content> contents)
    {
        Contents = contents;
    }

    public static GeminiRequest CreateTextRequest(string text)
    {
        return new GeminiRequest()
        {
            Contents = new List<Content>()
            {
                new Content(new List<Part>()
                {
                    new TextPart(text)
                })
            }
        };
    }

    public static GeminiRequest CreateImageRequest(string text, Stream imageStream)
    {
        var parts = new List<Part>()
        {
            new TextPart(text), new ImagePart(imageStream),
        };
        return new GeminiRequest()
        {
            Contents = new List<Content>()
            {
                new Content(parts)
            }
        };
    }
}