using YandexCloudOCR.Api;

namespace YandexCloudOCR.Services;

internal class ImageToTableConverter
{
    public Dictionary<int, List<string>> ConvertToDict(TableResponse response)
    {
        if (response.result.textAnnotation.tables.Length != 1)
        {
            throw new ArgumentException("More then 1 table result");
        }
    
        var table = response.result.textAnnotation.tables[0];
        return ConvertCellsToTable(table.cells);
    }
    
    public Dictionary<int, List<string>> ConvertCellsToTable(Cell[] cells)
    {
        // Создаем словарь для хранения строк таблицы
        Dictionary<int, List<string>> tableDict = new Dictionary<int, List<string>>();

        foreach (var cell in cells)
        {
            int rowIndex = int.Parse(cell.rowIndex);
            int columnIndex = int.Parse(cell.columnIndex);

            // Если строка еще не существует, создаем новую
            if (!tableDict.ContainsKey(rowIndex))
            {
                tableDict[rowIndex] = new List<string>();
            }

            // Увеличиваем размер строки, если необходимо
            while (tableDict[rowIndex].Count <= columnIndex)
            {
                tableDict[rowIndex].Add(string.Empty); // Заполняем пустыми значениями
            }

            // Устанавливаем текст в соответствующую ячейку
            tableDict[rowIndex][columnIndex] = cell.text;
        }


        return tableDict;
    }
}