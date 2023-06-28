namespace Services.Abstractions
{
	public interface IExcelParserService
	{
		public IEnumerable<T> ReadFromExcel<T>(Stream excelStream, DataType[] expectedTypes, Func<object?[], T?> rowSelector);
	}

	public enum DataType
	{
		String, Integer, Double, Date, Time
	}
}