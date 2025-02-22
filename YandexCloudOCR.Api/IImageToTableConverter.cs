namespace YandexCloudOCR.Api;

public interface IImageToTableConverter
{
    List<List<string>> Convert(TableResponse response);
}