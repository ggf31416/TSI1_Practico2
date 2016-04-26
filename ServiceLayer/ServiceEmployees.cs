using BusinessLogicLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ServiceEmployees : IServiceEmployees
    {
        private static IBLEmployees blHandler;

        public ServiceEmployees()
        {
            blHandler = Program.blHandler;
        }

        public void AddEmployee(Employee emp)
        {
            //throw new NotImplementedException();
            blHandler.AddEmployee(emp);
        }

        public void DeleteEmployee(int id)
        {
            //throw new NotImplementedException();
            blHandler.DeleteEmployee(id);
        }

        public void UpdateEmployee(Employee emp)
        {
            //throw new NotImplementedException();
            blHandler.UpdateEmployee(emp);
        }

        public List<Employee> GetAllEmployees()
        {
            //throw new NotImplementedException();
            return blHandler.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {
            //throw new NotImplementedException();
            return blHandler.GetEmployee(id);
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            //throw new NotImplementedException();
            return blHandler.CalcPartTimeEmployeeSalary(idEmployee, hours);
        }
    }
}
