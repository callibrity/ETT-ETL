using System;
using System.Collections.Generic;
using ETL.DTO;

namespace ETL
{
  public class Employee
  {
    public int EmpNum;
    public string Name;
    public List<EmpDataRow> EmpData;

    public Employee(string empNum, string name, List<EmpDataRow> empData)
    {
      this.EmpNum = Int32.Parse(empNum);
      this.Name = name;
      this.EmpData = empData;
    }
  }
}