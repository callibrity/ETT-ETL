using System;
using System.IO;

namespace Main
{
  class Program
  {
    static void Main(string[] args)
    {
      string path = System.AppDomain.CurrentDomain.BaseDirectory + "EmployeeFile.xlsx";
      System.Console.WriteLine(path);
    }
  }
}
