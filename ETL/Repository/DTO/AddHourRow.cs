using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.Repository.DTO
{
    public class AddHourRow
    {
        public string EmployeeNumber { get; set; }
        public double Hours { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
    }
}
