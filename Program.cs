using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Customer
{
    class Program
    { //userinterface section
        static void Main(string[] args)
        {
            // container is a  framework it automatically creates the necessary objects bases on the request and injects them whenever required. 
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<CustomerML>();
            unityContainer.RegisterType<iDal, LogicDL>();
            unityContainer.RegisterType<iDal, DataDL>();
            CustomerML pro = unityContainer.Resolve<CustomerML>();
            pro.CustomerName = "Ankita";
            pro.Add();
        }
    }
    // middle layer 
    public class CustomerML
    {
        private iDal dal;

        public string CustomerName { get; set; }

        public CustomerML(iDal id)// create constructor to remove tight coupling
        {
            dal = id;
        }

        public void Add()
        {
            dal.Add();
        }
    }
    public interface iDal // to converstion tightly coupled to loosly coupled interface is used.
    {
        void Add()
        {

        }
    }
    // data access layer
    public class LogicDL : iDal
    {
        public void Add()
        {

            Console.WriteLine("DataLogic");
        }
    }
    // to understand the concept of dependency injection  adding a new data access layer.
    public class DataDL : iDal
    {
        public void Add()
        {
            Console.WriteLine("datalayer");
        }

    }
}
