using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MoviesStore.Web.Helpers
{
    public static class MasterDataManager
    {
        public static NameValueCollection ConfigData;

        public static void MasterManager()
        {
            ConfigData = ConfigurationManager.AppSettings;

        }
    }
}