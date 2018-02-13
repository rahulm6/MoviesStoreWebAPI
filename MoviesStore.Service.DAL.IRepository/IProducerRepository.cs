using MoviesStore.Service.Common.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.DAL.IRepository
{
    public interface IProducerRepository
    {
        List<Producer> GetAllProducers(string spName, string providerName, string connectionString);

        Producer AddProducer(Producer producer, string spName, string providerName, string connectionString);
    }
}
