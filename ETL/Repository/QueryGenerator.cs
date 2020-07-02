using System;
using ETL.Repository.DTO;

namespace ETL.Repository
{
  public static class QueryGenerator
  {
    public static string RetrieveAllEmployeeNumbers()
    {
      return "SELECT employee_number from public.ett_employee";
    }

    public static string AddEmployee(EmployeeRow employeeObject)
    {
      return $"INSERT INTO public.ett_employee (first_name, last_name, employee_number) VALUES('{employeeObject.FirstName}', '{employeeObject.LastName}', '{employeeObject.EmployeeNumber}');";
    }

    public static string AddHourRow(HoursSourceRow obj)
    {
      return $"INSERT INTO public.ett_hours_source (employee_number_fk, hours, code, the_date) VALUES('{obj.EmployeeNumber}', {obj.Hours}, '{obj.Code}', '{obj.Date.ToString("MM/dd/yyyy")}');";
    }

    public static string GetEmployeeMetric(string employeeNumber, DateTime date)
    {
      string result = "SELECT employee_number_fk, target_billable_hours, current_billable_hours, target_training_hours, current_training_hours, total_yearly_pto, overflow_pto, used_pto, the_year ";
      result += "FROM public.ett_employee_metrics ";
      result += $"WHERE employee_number_fk = '{employeeNumber}' AND the_year = {date.Year}";
      return result;
    }

    public static string AddEmployeeMetric(EmployeeMetricRow obj)
    {
      string result = "";
      result += "INSERT INTO public.ett_employee_metrics ";
      result += "(employee_number_fk, target_billable_hours, current_billable_hours, target_training_hours, current_training_hours, total_yearly_pto, overflow_pto, used_pto, the_year) ";
      result += $"VALUES('{obj.EmployeeNumber}', {obj.TargetBillableHours}, {obj.CurrentBillableHours}, {obj.TargetTrainingHours}, {obj.CurrentTrainingHours}, {obj.YearlyAccruablePTO}, {obj.OverflowedPTO}, {obj.UsedPTO}, {obj.Date.Year});";
      return result;
    }

    public static string UpdateEmployeeMetric(EmployeeMetricRow obj)
    {
      string result = "";
      result += "UPDATE public.ett_employee_metrics SET ";
      result += $"target_billable_hours={obj.TargetBillableHours}, current_billable_hours={obj.CurrentBillableHours}, target_training_hours={obj.CurrentBillableHours}, current_training_hours={obj.CurrentTrainingHours}, total_yearly_pto={obj.YearlyAccruablePTO}, overflow_pto={obj.OverflowedPTO}, used_pto={obj.UsedPTO} ";
      result += $"WHERE employee_number_fk = '{obj.EmployeeNumber}' AND the_year = {obj.Date.Year};";
      return result;
    }
  }
}
