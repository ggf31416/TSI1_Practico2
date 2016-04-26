using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            //throw new NotImplementedException();
            Model.ER1Entities context = new Model.ER1Entities();
            if (emp.GetType() == typeof(FullTimeEmployee))
            { 
                Model.FullTimeEmployee result = new Model.FullTimeEmployee() { };
                result.Id = GetAllEmployees().Count;
                result.Name = emp.Name;
                result.Salary = ((FullTimeEmployee)emp).Salary;
                result.StartDate = emp.StartDate;
                context.Employees.Add(result);
            }
            else
            {
                Model.PartTimeEmployee result = new Model.PartTimeEmployee() { };
                result.Id = GetAllEmployees().Count;
                result.Name = emp.Name;
                result.HourlyRate = ((PartTimeEmployee)emp).HourlyRate;
                result.StartDate = emp.StartDate;
                context.Employees.Add(result);
            }
            
            // Submit the changes to the database.
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DeleteEmployee(int id)
        {
            //throw new NotImplementedException();
            Model.ER1Entities context = new Model.ER1Entities();
            //Query the database
            var query = from employee in context.Employees
                        where employee.Id == id
                        select employee;
            //Delete on submit
            foreach(Model.Employee e in query)
            {
                context.Employees.Remove(e);
            }
            // Submit the changes to the database.
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            Model.ER1Entities context = new Model.ER1Entities();
            //Query the database
            var query = from employee in context.Employees
                        where employee.Id == emp.Id
                        select employee;
            //Change the values
            foreach(Model.Employee e in query){
                e.Name = emp.Name;
                e.StartDate = emp.StartDate;
                if (e.GetType() == typeof(Model.FullTimeEmployee))
                {
                    ((Model.FullTimeEmployee)e).Salary = ((Shared.Entities.FullTimeEmployee)emp).Salary;
                }
                else
                {
                    ((Model.PartTimeEmployee)e).HourlyRate = ((Shared.Entities.PartTimeEmployee)emp).HourlyRate;
                }
            }
            // Submit the changes to the database.
            try
            {
                context.SaveChanges();
            }catch(Exception e){
                Console.WriteLine(e);
            }
        }

        public List<Employee> GetAllEmployees()
        {
            // Model.ER1Entities context = new Model.ER1Entities();
            using (var context = new Model.ER1Entities()) {
                IQueryable<Model.Employee> listEmp =
                    from row in context.Employees
                    select row;
                List<Employee> ret = new List<Employee>();
                try { 
                    foreach (var empR in listEmp)
                    {
                        if (empR.GetType() == typeof(Model.FullTimeEmployee))
                        {
                            FullTimeEmployee result = new FullTimeEmployee() { };
                            result.Id = empR.Id;
                            result.Name = empR.Name;
                            result.Salary = ((Model.FullTimeEmployee)empR).Salary;
                            result.StartDate = empR.StartDate;
                            ret.Add(result);
                        }
                        else
                        {
                            PartTimeEmployee result = new PartTimeEmployee() { };
                            result.Id = empR.Id;
                            result.Name = empR.Name;
                            result.HourlyRate = ((Model.PartTimeEmployee)empR).HourlyRate;
                            result.StartDate = empR.StartDate;
                            ret.Add(result);
                        }
                    }
                }catch(Exception e)
                {
                    var a = e;
                }


                return ret;
            };

            
        }

        public Employee GetEmployee(int id)
        {
            
            Model.ER1Entities context = new Model.ER1Entities();
            // DataContext takes a connection string. 
            IQueryable<Model.Employee> query =
                from employee in context.Employees
                where employee.Id == id
                select employee;
            Model.Employee empR = query.First();
            if(empR.GetType() == typeof(Model.FullTimeEmployee))
            {
                FullTimeEmployee result = new FullTimeEmployee();
                result.Id = id;
                result.Name = empR.Name;
                result.Salary = ((Model.FullTimeEmployee)empR).Salary;
                result.StartDate = empR.StartDate;
                return result;
            }
            else
            {
                PartTimeEmployee result = new PartTimeEmployee();
                result.Id = id;
                result.Name = empR.Name;
                result.HourlyRate = ((Model.PartTimeEmployee)empR).HourlyRate;
                result.StartDate = empR.StartDate;
                return result;
            }
            
        }
    }
}
