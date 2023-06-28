using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Bcpg;
using Services.Abstractions;
using System.Data;

namespace Services
{
	public class ExcelParserService : IExcelParserService 
	{
		public IEnumerable<T> ReadFromExcel<T>(Stream excelStream, DataType[] expectedTypes, Func<object?[], T?> rowSelector)
		{
			var book = new XSSFWorkbook(excelStream);
			var cells = new object?[expectedTypes.Length];
			for (int sheetNum = 0; sheetNum < book.NumberOfSheets; sheetNum++)
			{
				var sheet = book.GetSheetAt(sheetNum);
				for (int rowNum = sheet.FirstRowNum; rowNum < sheet.LastRowNum; rowNum++)
				{
					var row = sheet.GetRow(rowNum);
					if (row == null || row.LastCellNum <= row.FirstCellNum + 1) continue;
					for (int cellNum = row.FirstCellNum; cellNum < row.LastCellNum; cellNum++)
					{
						var cell = row.GetCell(cellNum);
						var type = expectedTypes[cellNum];

						cells[cellNum] = null;
						switch (type)
						{
							case DataType.String:
								cells[cellNum] = cell.StringCellValue; break;
							case DataType.Integer:
								if (int.TryParse(cell.StringCellValue, out var intresult))
									cells[cellNum] = intresult;
								break;
							case DataType.Double:
								if (double.TryParse(cell.StringCellValue, out var doubleresult))
									cells[cellNum] = doubleresult;
								break;
							case DataType.Date:
								if (DateTime.TryParseExact(cell.StringCellValue, "d", null, System.Globalization.DateTimeStyles.None, out var dateresult))
									cells[cellNum] = dateresult;
								break;
							case DataType.Time:
								if (DateTime.TryParseExact(cell.StringCellValue, "t", null, System.Globalization.DateTimeStyles.None, out var timeresult))
									cells[cellNum] = timeresult;
								break;
						}
					}
					var result = rowSelector(cells);
					if (result is not null) yield return result;
				}
			}
		}
	}
}