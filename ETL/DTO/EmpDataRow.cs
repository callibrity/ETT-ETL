using System;
using System.Globalization;


namespace ETL.DTO
{
  public class EmpDataRow
  {
    public DateTime Date;
    public double Hours;
    public string Code;

    public EmpDataRow(string date, string hours, string code)
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
