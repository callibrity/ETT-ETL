using System;
using Xunit;
using System.Globalization;
using ETL.ExcelParsing.DTO;

namespace ETL.Tests.EmpDataRowTests
{
  public class WhenCreated
  {
    private string _mockValidDate = "01/01/2020";
    private string _mockValidHours = "8.00";
    private string _mockValidCode = "Holiday";

    [Fact]
    public void AndDataIsValidThenDataShouldMatchExpected()
    {
      var expectedDate = DateTime.ParseExact("01/01/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture);
      double expectedHours = 8;
      string expectedCode = "Holiday";
      var empDataRow = new EmployeeTimeRow(_mockValidDate, _mockValidHours, _mockValidCode);
      Assert.Equal(expectedDate, empDataRow.Date);
      Assert.Equal(expectedHours, empDataRow.Hours);
      Assert.Equal(expectedCode, empDataRow.Code);
    }

    [Fact]
    public void AndDateIsInvalidThenThrowException()
    {

      string mockInvalidDate = "13/13/2020";
      Assert.ThrowsAny<Exception>(() =>
        {
          new EmployeeTimeRow(mockInvalidDate, _mockValidHours, _mockValidCode);
        }
          );
    }

    [Fact]
    public void AndHoursIsInvalidThenThrowException()
    {
      string mockInvalidHours = "eight";
      Assert.ThrowsAny<Exception>(() =>
        {
          new EmployeeTimeRow(_mockValidDate, mockInvalidHours, _mockValidCode);
        }
          );
    }
  }
}