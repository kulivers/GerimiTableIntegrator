namespace YandexCloudOCR.Common;

public class Result<T>
{
    public bool Success { get; set; }
    public T Value { get; set; }
    public Exception Exception { get; set; }
}