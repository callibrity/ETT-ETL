using System;
using System.Collections.Generic;
using Xunit;
using ETL.DTO;

namespace ETL.Tests.EmployeeTests
{

  public class WhenCreated
  {
    private string _mockValidNum = "2000";
    private string _mockValidName = "Tom";
    private List<EmpDataRow> _mockValidData = new List<EmpDataRow>();

    [Fact]
    public void AndDataIsValidThenDataShouldMatchExpected()
    {
      int expectedNum = 2000;
      string expectedName = "Tom";
      var employee = new Employee(_mockValidNum, _mockValidName, _mockValidData);
      Assert.Equal(expectedNum, employee.EmpNum);
      Assert.Equal(_mockValidName, expectedName);
    }

    [Fact]
    public void AndNumIsInvalidThenThrowException()
    {
      string mockInvalidNum = "Tom";
      Assert.ThrowsAny<Exception>(() =>
      {
        new Employee(mockInvalidNum, _mockValidName, _mockValidData);
      }
        );
    }
  }
}