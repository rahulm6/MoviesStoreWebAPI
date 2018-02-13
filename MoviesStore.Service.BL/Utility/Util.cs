using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.BL.Utility
{
    public class Util
    {
        /// <summary>
        /// Gets the connection string from the configuration file for the given connection string name
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns>Requested connection String</returns>
        public static string GetConnectionString(string connectionStringName)
        {
            try
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            }
            catch (ConfigurationErrorsException e)
            {
                throw new ConfigurationErrorsException(e.Message);
            }
        }

        /// <summary>
        /// Gets the Database Provider string from the configuration file for the given connection string name
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns>Requested Database Provider string</returns>
        public static string GetProviderName(string connectionStringName)
        {
            try
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName;
            }
            catch (ConfigurationErrorsException e)
            {
                throw new ConfigurationErrorsException(e.Message);
            }
        }
    }
}
