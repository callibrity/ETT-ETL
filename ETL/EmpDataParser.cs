using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;

namespace ETL.DTO
{
  public class EmpDataParser
  {
    private string _empStartString = "Employee Number";
    private int _empNumColumnIndex = 1;
    private int _dateColumnIndex = 3;
    private int _nameColumnIndex = 5;
    private int _codeColumnIndex = 15;
    private int _hoursColumnIndex = 27;
    private int _startToDataGap = 3;
    private int _startToEmpNumGap = 1;
    public ExcelWorksheet Worksheet;
    public List<int> EmpStartRowIndexList;

    public EmpDataParser(string path)
    {
      Worksheet = GetWorksheet(path);
      EmpStartRowIndexList = GetEmpStartRowIndices();
    }

    public List<Employee> GetAllEmpData()
    {
      var empObjList = new List<Employee>();
      for (int i = 0; i < EmpStartRowIndexList.Count - 1; i += 1)
      {
        empObjList.Add(CreateEmpObj(EmpStartRowIndexList[i], EmpStartRowIndexList[i + 1]));
      }
      return empObjList;
    }

    private ExcelWorksheet GetWorksheet(string path)
    {
      ExcelPackage.LicenseContext = LicenseContext.Commercial;
      var file = new FileInfo(path);
      var package = new ExcelPackage(file);
      return package.Workbook.Worksheets[0];
    }

    private List<int> GetEmpStartRowIndices()
    {
      int lastRow = Worksheet.Dimension.End.Row;
      var indices = new List<int>();
      for (int i = 1; i <= lastRow; i += 1)
      {
        if (GetCellText(i, _empNumColumnIndex) == _empStartString)
        {
          indices.Add(i);
        }
      }
      indices.Add(lastRow);
      return indices;
    }

    private Employee CreateEmpObj(int startRow, int stopRow)
    {
      int searchRow = startRow + _startToDataGap;
      int empNumAndNameRow = startRow + _startToEmpNumGap;

      var empTimeData = new List<EmpDataRow>();
      while (searchRow < stopRow)
      {
        if (GetCellText(searchRow, _codeColumnIndex) != "")
        {
          empTimeData.Add(new EmpDataRow(
            GetCellText(searchRow, _dateColumnIndex),
            GetCellText(searchRow, _hoursColumnIndex),
            GetCellText(searchRow, _codeColumnIndex)
          ));
        }
        searchRow += 1;
      }
      string empNum = GetCellText(empNumAndNameRow, _empNumColumnIndex);
      string empName = GetCellText(empNumAndNameRow, _nameColumnIndex);
      return new Employee(empNum, empName, empTimeData);
    }


    private string GetCellText(int row, int col)
    {
      return Worksheet.Cells[row, col].Text;
    }
  }
}
