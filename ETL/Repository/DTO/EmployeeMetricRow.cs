﻿using System;

namespace ETL.Repository.DTO
{
    public class EmployeeMetricRow
    {
        public string EmployeeNumber { get; set; }
        public DateTime Date { get; set; }
        public double TargetBillableHours { get; set; }
        public double CurrentBillableHours { get; set; }
        public double TargetTrainingHours { get; set; }
        public double CurrentTrainingHours { get; set; }
        public double YearlyAccruablePTO { get; set; }
        public double OverflowedPTO { get; set; }
        public double UsedPTO { get; set; }
    }
}
