using MoviesStore.Service.Common.Entity.Data_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.DAL.IRepository
{
    public interface IMasterDataRepository
    {
        List<Year> GetAllYears(string spName, string providerName, string connectionString);
    }
}
