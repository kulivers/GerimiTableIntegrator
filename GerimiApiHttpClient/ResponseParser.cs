namespace GerimiApiHttpClient;

public class CsvParser
{
    public List<List<string>> Parse(string inputData)
    {
        var result = new List<List<string>>();
        var lines = inputData.Trim().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            var columns = line.Split(';');
            var row = new List<string>(columns);
            result.Add(row);
        }

        return result;
        

    }
}