using System.Collections.Generic;
using ETL.ExcelParsing;
using ETL.ExcelParsing.DTO;
using ETL.Repository;

namespace ETL.DatabaseUpdate
{
  class DatabaseUpdate
  {
    public void UpdateDatabase()
    {
      var excelParser = new ExcelParser(System.AppDomain.CurrentDomain.BaseDirectory + "EmployeeFile.xlsx");
      List<Employee> employeeList = excelParser.GetAllEmployeeData();
      string list = QueryGenerator.RetrieveAllEmployeeNumbers();

    }
  }
}