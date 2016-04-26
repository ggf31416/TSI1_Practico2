using BusinessLogicLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "http://localhost:8834", headers: "*", methods: "*")]
    public class EmployeesController : ApiController
    {
        /* public HttpResponseMessage Get()
         {
              return new HttpResponseMessage()
              {
                  Content = new StringContent("GET: Test message")
              };

         }

         public HttpResponseMessage Post()
         {
             return new HttpResponseMessage()
             {
                 Content = new StringContent("POST: Test message")
             };
         }*/

        private static IBLEmployees blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());

        [HttpGet]
        [ActionName("addemployee")]
        public void AddEmployee(Employee emp)
        {
            //throw new NotImplementedException();
            blHandler.AddEmployee(emp);
        }

        [HttpGet]
        [ActionName("deleteemployee")]
        public void DeleteEmployee(int id)
        {
            //throw new NotImplementedException();
            blHandler.DeleteEmployee(id);
        }

        [HttpGet]
        [ActionName("updateemployee")]
        public void UpdateEmployee(Employee emp)
        {
            //throw new NotImplementedException();
            blHandler.UpdateEmployee(emp);
        }

        [HttpGet]
        [ActionName("getallemployee")]
        public List<Employee> GetAllEmployees()
        {
            //throw new NotImplementedException();
            return blHandler.GetAllEmployees();
        }

        [HttpGet]
        [ActionName("getemployee")]
        public Employee GetEmployee(int id)
        {
            //throw new NotImplementedException();
            return blHandler.GetEmployee(id);
        }

        [HttpGet]
        [ActionName("getparttymeemployeesalary")]
        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            //throw new NotImplementedException();
            return blHandler.CalcPartTimeEmployeeSalary(idEmployee, hours);
        }

        [HttpGet]
        [ActionName("gettext")]
        public HttpResponseMessage GetText()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("GET: Test message")
            };

        }
    }
}
