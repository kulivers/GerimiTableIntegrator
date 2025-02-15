public class Candidate
{
    public Content content { get; set; }
    public string finishReason { get; set; }
    public double avgLogprobs { get; set; }
}

public class CandidatesTokensDetail
{
    public string modality { get; set; }
    public int tokenCount { get; set; }
}

public class Content
{
    public List<Part> parts { get; set; }
    public string role { get; set; }
}

public class Part
{
    public string text { get; set; }
}

public class PromptTokensDetail
{
    public string modality { get; set; }
    public int tokenCount { get; set; }
}

public class GeminiResponse
{
    public List<Candidate> candidates { get; set; }
    public UsageMetadata usageMetadata { get; set; }
    public string modelVersion { get; set; }
}

public class UsageMetadata
{
    public int promptTokenCount { get; set; }
    public int candidatesTokenCount { get; set; }
    public int totalTokenCount { get; set; }
    public List<PromptTokensDetail> promptTokensDetails { get; set; }
    public List<CandidatesTokensDetail> candidatesTokensDetails { get; set; }
}