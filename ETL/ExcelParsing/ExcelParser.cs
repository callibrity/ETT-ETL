using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;
using ETL.ExcelParsing.DTO;

namespace ETL.ExcelParsing
{
  public class ExcelParser
  {
    private string _employeeStartString = "Employee Number";
    private int _employeeNumColumnIndex = 1;
    private int _dateColumnIndex = 3;
    private int _nameColumnIndex = 5;
    private int _codeColumnIndex = 15;
    private int _hoursColumnIndex = 27;
    private int _rowCountBetweenStartAndData = 3;
    private int _rowCountBetweenStartAndEmployeeNum = 1;
    public ExcelWorksheet Worksheet;
    public List<int> EmployeeStartRows;

    public ExcelParser(string path)
    {
      Worksheet = GetFirstWorksheet(path);
      EmployeeStartRows = GetEmployeeStartRows();
    }

    public List<Employee> GetAllEmployeeData()
    {
      var employeeList = new List<Employee>();
      for (int i = 0; i < EmployeeStartRows.Count - 1; i += 1)
      {
        employeeList.Add(CreateEmployee(EmployeeStartRows[i], EmployeeStartRows[i + 1]));
      }
      return employeeList;
    }

    private Employee CreateEmployee(int startRow, int stopRow)
    {
      int initialRow = startRow + _rowCountBetweenStartAndData;
      int employeeNumAndNameRow = startRow + _rowCountBetweenStartAndEmployeeNum;
      string employeeNum = GetCellText(employeeNumAndNameRow, _employeeNumColumnIndex);
      string employeeName = GetCellText(employeeNumAndNameRow, _nameColumnIndex);
      List<EmployeeTimeRow> employeeTimeData = GetEmployeeTimeData(initialRow, stopRow);
      return new Employee(employeeNum, employeeName, employeeTimeData);
    }

    private ExcelWorksheet GetFirstWorksheet(string path)
    {
      ExcelPackage.LicenseContext = LicenseContext.Commercial;
      var file = new FileInfo(path);
      var package = new ExcelPackage(file);
      return package.Workbook.Worksheets[0];
    }

    private List<int> GetEmployeeStartRows()
    {
      int lastRowOfWorksheet = Worksheet.Dimension.End.Row;
      var employeeStartRows = new List<int>();
      for (int i = 1; i <= lastRowOfWorksheet; i += 1)
      {
        if (GetCellText(i, _employeeNumColumnIndex) == _employeeStartString)
        {
          employeeStartRows.Add(i);
        }
      }
      employeeStartRows.Add(lastRowOfWorksheet);
      return employeeStartRows;
    }

    private List<EmployeeTimeRow> GetEmployeeTimeData(int initialRow, int stopRow)
    {
      var employeeTimeData = new List<EmployeeTimeRow>();
      for (int i = initialRow; i < stopRow; i += 1)
      {
        if (GetCellText(i, _codeColumnIndex) != "")
        {
          employeeTimeData.Add(new EmployeeTimeRow(
            GetCellText(i, _dateColumnIndex),
            GetCellText(i, _hoursColumnIndex),
            GetCellText(i, _codeColumnIndex)
          ));
        }
      }
      return employeeTimeData;
    }



    private string GetCellText(int row, int col)
    {
      return Worksheet.Cells[row, col].Text;
    }
  }
}
