using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var configmgr = ConfigurationManager.GetInstance;
            configmgr.DisplayConfiguration();

            var businessrulesmgr = BusinessRulesManager.GetInstance;
            businessrulesmgr.DisplayRules();

            Console.ReadKey();
        }
    }

    public sealed class ConfigurationManager
    {
        private static ConfigurationManager instance;
        private static object syncRoot = new object();

        private ConfigurationManager()
        {
        }

        public static ConfigurationManager GetInstance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ConfigurationManager();
                    }                

                    return instance;
                }
            }
        }

        public void DisplayConfiguration()
        {
            Console.WriteLine("Single Instance Object");
        }
    }

    public sealed class BusinessRulesManager
    {
        private BusinessRulesManager()
        {
        }

        public static BusinessRulesManager GetInstance
        {
            get
            {
                return BusinessRulesManagerImpl.instance;
            }
        }

        public void DisplayRules()
        {
            Console.WriteLine("Single Instance Object");
        }

        private class BusinessRulesManagerImpl
        {
            static BusinessRulesManagerImpl()
            {
            }

            internal static readonly BusinessRulesManager instance = new BusinessRulesManager();
        }
    }

}
