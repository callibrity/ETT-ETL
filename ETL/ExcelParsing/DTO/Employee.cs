using System;
using System.Collections.Generic;

namespace ETL.ExcelParsing.DTO
{
  public class Employee
  {
    public int Num;
    public string Name;
    public List<EmployeeTimeRow> TimeData;

    public Employee(string num, string name, List<EmployeeTimeRow> timeData)
    {
      this.Num = Int32.Parse(num);
      this.Name = name;
      this.TimeData = timeData;
    }
  }
}