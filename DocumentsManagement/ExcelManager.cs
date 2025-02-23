using System.Data;
using OfficeOpenXml;

namespace DocumentsManagement;

public class ExcelManager
{
    public ExcelManager()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }

    public void CreateEmpty()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        // Create a new Excel package
        using (var package = new ExcelPackage())
        {
            // Optionally, you can add a worksheet if needed
            // var worksheet = package.Workbook.Worksheets.Add("Sheet1");

            // Save the package to a file
            var fileInfo = new FileInfo(@"C:\Users\kulivers\Desktop\test.xlsx");
            package.Workbook.Worksheets.Add("Sheet1");
            var worksheet = package.Workbook.Worksheets["Sheet1"];
            worksheet.Cells[1, 1].Value = "Hello"; // A1
            worksheet.Cells[1, 2].Value = "World"; // B1
            worksheet.Cells[2, 1].Value = "EPPlus"; // A2
            worksheet.Cells[2, 2].Value = "Example"; // B2
            package.SaveAs(fileInfo);
        }
    }

    public byte[] CreateStreamFromTable(Dictionary<int, List<string>> table)
    {
        using var package = new ExcelPackage();
        package.Workbook.Worksheets.Add("Sheet1");
        var worksheet = package.Workbook.Worksheets["Sheet1"];
        var cells = worksheet.Cells;
        var columnWidths = new Dictionary<int, int>();
        foreach (var (rowI, values) in table)
        {
            var rowExcelI = rowI + 1;
            for (var colI = 0; colI < values.Count; colI++)
            {
                var colExcelI = colI + 1;
                var value = values[colI];
                var curCell = cells[rowExcelI, colExcelI];
                curCell.Value = value;
                if (value.Contains(Environment.NewLine) || value.Contains('\n'))
                {
                    curCell.Style.WrapText = true;
                }

                if (columnWidths.TryGetValue(colExcelI, out var maxWidth))
                {
                    if (maxWidth < value.Length)
                    {
                        columnWidths[colExcelI] = value.Length + 5;
                    }
                }
                else
                {
                    columnWidths[colExcelI] = value.Length + 5;
                }
            }
        }
            
        foreach (var (idx, width) in columnWidths)
        {
            worksheet.Columns[idx].Width = width;
        }

        //worksheet.Columns.AutoFit();
        // worksheet.Columns[4].Width = 43;
        var data = package.GetAsByteArray();
        string path = @"C:\Users\kulivers\Desktop\test.xlsx";
        File.WriteAllBytes(path, data);
        return data;
    }
}