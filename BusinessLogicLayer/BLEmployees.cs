using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLEmployees : IBLEmployees
    {
       private IDALEmployees _dal;

        public BLEmployees(IDALEmployees dal)
        {
            _dal = dal;
        }

        public void AddEmployee(Shared.Entities.Employee emp)
        {
            //throw new NotImplementedException();
            _dal.AddEmployee(emp);
        }

        public void DeleteEmployee(int id)
        {
            //throw new NotImplementedException();
            _dal.DeleteEmployee(id);
        }

        public void UpdateEmployee(Shared.Entities.Employee emp)
        {
            //throw new NotImplementedException();
            _dal.UpdateEmployee(emp);
        }

        public List<Shared.Entities.Employee> GetAllEmployees()
        {
            //throw new NotImplementedException();
            return _dal.GetAllEmployees();
        }

        public Shared.Entities.Employee GetEmployee(int id)
        {
            //throw new NotImplementedException();
            return _dal.GetEmployee(id);
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            //throw new NotImplementedException();
            Shared.Entities.Employee emp = GetEmployee(idEmployee);
            if(emp == null || (emp.GetType() == typeof(Shared.Entities.FullTimeEmployee)))
            {
                throw new Exception("Empleado no es Part time o no existe");
            }
            else
            {
                return hours * ((Shared.Entities.PartTimeEmployee)emp).HourlyRate;
            }
        }
    }
}
