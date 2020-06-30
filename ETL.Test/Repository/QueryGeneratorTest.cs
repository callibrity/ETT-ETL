using Xunit;
using System;
using ETL.Repository.DTO;

namespace ETL.Repository.Test
{
    public class QueryGeneratorTest
    {

        [Fact]
        public void ShouldReturnQueryForRetrievingEmployeeNumbers()
        {
            string expected = "SELECT employee_number from public.ett_employee";
            string actual = QueryGenerator.RetrieveAllEmployeeNumbers();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnQueryForAddingEmployee()
        {
            string expected = "INSERT INTO public.ett_employee (first_name, last_name, employee_number) VALUES('Daniel', 'Moon', 'b003223');";
            EmployeeRow obj = new EmployeeRow { EmployeeNumber = "b003223", LastName = "Moon", FirstName = "Daniel" };
            string actual = QueryGenerator.AddEmployee(obj);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnQueryForAddingHourRow()
        {
            string expected = "INSERT INTO public.ett_hours_source (employee_number_fk, hours, code, the_date) VALUES('b003223', 8, 'Work', '10/03/2020');";
            HoursSourceRow obj = new HoursSourceRow { EmployeeNumber = "b003223", Code = "Work", Date = new DateTime(2020,10,3), Hours = 8.0 };
            string actual = QueryGenerator.AddHourRow(obj);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnQueryForAddingEmployeeMetric()
        {
            string expected = "INSERT INTO public.ett_hours_source (employee_number_fk, hours, code, the_date) VALUES('b003223', 8, 'Work', '10/03/2020');";
            HoursSourceRow obj = new HoursSourceRow { EmployeeNumber = "b003223", Code = "Work", Date = new DateTime(2020, 10, 3), Hours = 8.0 };
            string actual = QueryGenerator.AddHourRow(obj);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnQueryForGettingEmployeeMetric()
        {
            string expected = "SELECT employee_number_fk, target_billable_hours, current_billable_hours, target_training_hours, current_training_hours, total_yearly_pto, overflow_pto, used_pto, the_year FROM public.ett_employee_metrics WHERE employee_number_fk = 'b003223' AND the_year = 2020";
            string actual = QueryGenerator.GetEmployeeMetric("b003223", new DateTime(2020, 10, 03));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnQueryForUpdatingEmployeeMetric()
        {
            string expected = "SELECT employee_number_fk, target_billable_hours, current_billable_hours, target_training_hours, current_training_hours, total_yearly_pto, overflow_pto, used_pto, the_year FROM public.ett_employee_metrics WHERE employee_number_fk = 'b003223' AND the_year = 2020";
            string actual = QueryGenerator.GetEmployeeMetric("b003223", new DateTime(2020, 10, 03));
            Assert.Equal(expected, actual);
        }

    }
}