using System;
using System.Collections.Generic;
using Xunit;
using OfficeOpenXml;
using ETL.ExcelParsing;
using ETL.ExcelParsing.DTO;

namespace ETL.Tests.ExcelParsing
{
  public class WhenCreatedWithValidData
  {
    private ExcelParser _excelParser;
    private List<Employee> _employees;

    public WhenCreatedWithValidData()
    {
      _excelParser = new ExcelParser(System.AppDomain.CurrentDomain.BaseDirectory + "EmployeeFile.xlsx");
      _employees = _excelParser.GetAllEmployeeData();
    }

    [Fact]
    public void ThenStartCellIsOneCommaOne()
    {
      ExcelCellAddress start = _excelParser.Worksheet.Dimension.Start;
      Assert.Equal(1, start.Row);
      Assert.Equal(1, start.Column);
    }

    [Fact]
    public void ThenEndCellIsNotOneCommaOne()
    {
      ExcelCellAddress end = _excelParser.Worksheet.Dimension.End;
      Assert.NotEqual(1, end.Row);
      Assert.NotEqual(1, end.Column);
    }

    [Fact]
    public void ThenMoreThanOneEmployeeIsFound()
    {
      List<int> employeeStartRows = _excelParser.EmployeeStartRows;
      Assert.True(employeeStartRows.Count > 2);
    }

    [Fact]
    public void ThenTheFirstEmployeeStartsAfterRowOne()
    {
      List<int> employeeStartRows = _excelParser.EmployeeStartRows;
      Assert.True(employeeStartRows[0] > 1);
    }

    [Fact]
    public void ThenFirstEmployeeMatchesExpectedValues()
    {
      Employee employee = _employees[0];
      int expectedNum = 2000;
      string expectedName = "Gatsby, Jay";
      Assert.Equal(expectedNum, employee.Num);
      Assert.Equal(expectedName, employee.Name);
    }

    [Fact]
    public void ThenFirstEmployeeFirstDayMatchesExpectedValues()
    {
      Employee employee = _employees[0];
      var expectedDate = new DateTime(2020, 1, 1);
      double expectedHours = 8.00;
      string expectedCode = "HOLIDAY";
      Assert.Equal(expectedDate, employee.TimeData[0].Date);
      Assert.Equal(expectedHours, employee.TimeData[0].Hours);
      Assert.Equal(expectedCode, employee.TimeData[0].Code);
    }
  }
}
