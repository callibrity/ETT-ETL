using System;
using System.Globalization;


namespace ETL.ExcelParsing.DTO
{
  public class EmployeeTimeRow
  {
    public DateTime Date;
    public double Hours;
    public string Code;

    public EmployeeTimeRow(string date, string hours, string code)
    {
      this.Date = StringToDateTime(date);
      this.Hours = double.Parse(hours);
      this.Code = code;
    }
    private DateTime StringToDateTime(string date)
    {
      return date != " " ? DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture)
      : DateTime.ParseExact("01/01/1990", "MM/dd/yyyy", CultureInfo.InvariantCulture);
    }
  }
}
