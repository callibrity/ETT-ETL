using System;
using System.Collections.Generic;
using Xunit;
using OfficeOpenXml;
using ETL.DTO;

namespace ETL.Tests.EmpDataParserTests
{
  public class WhenCreatedWithValidData
  {
    private EmpDataParser _empDataParser;
    private List<Employee> _empObjList;

    public WhenCreatedWithValidData()
    {
      _empDataParser = new EmpDataParser(System.AppDomain.CurrentDomain.BaseDirectory + "EmployeeFile.xlsx");
      _empObjList = _empDataParser.GetAllEmpData();
    }

    [Fact]
    public void ThenStartCellIsOneCommaOne()
    {
      ExcelCellAddress start = _empDataParser.Worksheet.Dimension.Start;
      Assert.Equal(1, start.Row);
      Assert.Equal(1, start.Column);
    }

    [Fact]
    public void ThenEndCellIsNotOneCommaOne()
    {
      ExcelCellAddress end = _empDataParser.Worksheet.Dimension.End;
      Assert.NotEqual(1, end.Row);
      Assert.NotEqual(1, end.Column);
    }

    [Fact]
    public void ThenMoreThanOneEmployeeIsFound()
    {
      List<int> employeeStartRows = _empDataParser.EmpStartRowIndexList;
      Assert.True(employeeStartRows.Count > 2);
    }

    [Fact]
    public void ThenTheFirstEmployeeStartsAfterRowOne()
    {
      List<int> employeeStartRows = _empDataParser.EmpStartRowIndexList;
      Assert.True(employeeStartRows[0] > 1);
    }

    [Fact]
    public void ThenFirstEmployeeMatchesExpectedValues()
    {
      Employee empObj = _empObjList[0];
      int expectedNum = 2000;
      string expectedName = "Gatsby, Jay";
      Assert.Equal(expectedNum, empObj.EmpNum);
      Assert.Equal(expectedName, empObj.Name);
    }

    [Fact]
    public void ThenFirstEmployeeFirstDayMatchesExpectedValues()
    {
      Employee empObj = _empObjList[0];
      var expectedDate = new DateTime(2020, 1, 1);
      double expectedHours = 8.00;
      string expectedCode = "HOLIDAY";
      Assert.Equal(expectedDate, empObj.EmpData[0].Date);
      Assert.Equal(expectedHours, empObj.EmpData[0].Hours);
      Assert.Equal(expectedCode, empObj.EmpData[0].Code);
    }
  }
}
