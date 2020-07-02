using System;
using System.Collections.Generic;
using Xunit;
using ETL.ExcelParsing.DTO;

namespace ETL.Tests.EmployeeTests
{

  public class WhenCreated
  {
    private string _mockValidNum = "2000";
    private string _mockValidName = "Tom";
    private List<EmployeeTimeRow> _mockValidTimeData = new List<EmployeeTimeRow>();

    [Fact]
    public void AndDataIsValidThenDataShouldMatchExpected()
    {
      int expectedNum = 2000;
      string expectedName = "Tom";
      var employee = new Employee(_mockValidNum, _mockValidName, _mockValidTimeData);
      Assert.Equal(expectedNum, employee.Num);
      Assert.Equal(_mockValidName, expectedName);
    }

    [Fact]
    public void AndNumIsInvalidThenThrowException()
    {
      string mockInvalidNum = "Tom";
      Assert.ThrowsAny<Exception>(() =>
      {
        new Employee(mockInvalidNum, _mockValidName, _mockValidTimeData);
      }
        );
    }
  }
}