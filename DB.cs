using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
namespace DQF_30_01_15
{
   public class DB
    {
        //ConnectionStringSettings connstr = ConfigurationManager.ConnectionStrings["DBName"];
       public static string lusid;
       public static string GetConnectionStringByName(string name)
        {            
            
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;           
           
        }


    }
}
