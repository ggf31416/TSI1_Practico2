using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace DataAccessLayer
{
    public class DALEmployeesMongo : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            throw new NotImplementedException();
            //MongoClient _mongoClient = new MongoClient(System.Configuration.ConfigurationManager.ConnectionStrings["ER1Mongo"].ConnectionString);
            //var _mongoDatabase = _mongoClient.GetDatabase(System.Configuration.ConfigurationManager.AppSettings["ER1Mongo"]);

        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
            //MongoClient _mongoClient = new MongoClient(System.Configuration.ConfigurationManager.ConnectionStrings["ER1Mongo"].ConnectionString);
            //var _mongoDatabase = _mongoClient.GetDatabase(System.Configuration.ConfigurationManager.AppSettings["ER1Mongo"]);
            //var collection =_mongoDatabase.GetCollection<Employee>("employees");
        }
    }
}
