using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    class Program
    {
        public static IBLEmployees blHandler;

        static void Main(string[] args)
        {
            SetupDependencies();
            SetupService();
        }

        private static void SetupDependencies()
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
        }

        private static void SetupService()
        {
            Uri baseAddress = new Uri("http://localhost:8834/tsi/");
            ServiceHost selfHost = new ServiceHost(typeof(ServiceEmployees), baseAddress);
            try
            {
                selfHost.AddServiceEndpoint(
                        typeof(IServiceEmployees),
                        new BasicHttpBinding(),
                        "ServiceEmployees");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);
                selfHost.Open();
                Console.WriteLine("Hola");
                Console.ReadLine();
                selfHost.Close();
            }catch (CommunicationException ce)
            {
                Console.Write("An exception ocurred: ", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
