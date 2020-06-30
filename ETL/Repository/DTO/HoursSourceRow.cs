using System;

namespace ETL.Repository.DTO
{
    public class HoursSourceRow
    {
        public string EmployeeNumber { get; set; }
        public double Hours { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
    }
}
