using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MoviesStore.Service.Common.Util
{
    public static class MasterDataManager
    {
        public static NameValueCollection ConfigData;
        public static DataTable ActorDataTable;
        
        public static void MasterManager()
        {
            ConfigData = ConfigurationManager.AppSettings;

            ActorDataTable = new DataTable();
            ActorDataTable.Columns.Add("ActorID", typeof(int));
            ActorDataTable.Columns.Add("Name", typeof(string));
            ActorDataTable.Columns.Add("DOB", typeof(DateTime));
            ActorDataTable.Columns.Add("Sex", typeof(string));
            ActorDataTable.Columns.Add("Bio", typeof(string));

        }
    }
}