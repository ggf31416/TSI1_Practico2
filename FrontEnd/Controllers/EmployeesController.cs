using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrontEnd.Models;
using Shared.Entities;

namespace FrontEnd.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View("employee");
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Model emp)
        {
            try
            {
                // TODO: Add insert logic here
                ServiceEmployeesClient client = new ServiceEmployeesClient();

                string name = emp.Name;

                if (emp.isFullTime)
                {
                    FullTimeEmployee e = new FullTimeEmployee();
                    e.Name = name;
                    e.StartDate = DateTime.Now;
                    e.Salary = emp.Salary;
                    client.AddEmployee(e);
                }
                else
                {
                    PartTimeEmployee e = new PartTimeEmployee();
                    e.Name = name;
                    e.StartDate = DateTime.Now;
                    e.HourlyRate = emp.Hourly;
                    client.AddEmployee(e);
                }

                return Json(new { success = true, responseText = "User correct!" }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
                return Json(new { success = false, responseText = "User wrong!" }, JsonRequestBehavior.AllowGet);
            }
          
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Employee/Delete/5
        [HttpGet]
        public ActionResult getAllEmployee()
        {
            try
            {
                // TODO: Add insert logic here
                ServiceEmployeesClient client = new ServiceEmployeesClient();

                Employee[] listEmployee = client.GetAllEmployees();

                List<Model> ret = new List<Model>();
                foreach(Employee e in listEmployee)
                {
                    Model newEmployee = new Model();
                    newEmployee.Id = e.Id;
                    newEmployee.Name = e.Name;
                    newEmployee.StartDate = e.StartDate.ToString();
                    if(e.GetType() == typeof(FullTimeEmployee)) {
                        newEmployee.isFullTime = true;
                        newEmployee.Salary = ((FullTimeEmployee)e).Salary;
                        newEmployee.Hourly = 0;
                    }
                    else
                    {
                        newEmployee.isFullTime = false;
                        newEmployee.Hourly = ((PartTimeEmployee)e).HourlyRate;
                        newEmployee.Salary = 0;
                    }
                    ret.Add(newEmployee);
                }

                return Json(ret, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
                return Json(new { success = false, responseText = "User wrong!" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
