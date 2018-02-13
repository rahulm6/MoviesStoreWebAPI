using MoviesStore.Service.Common.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.BL
{
    public interface IProducerManager
    {
        List<Producer> GetAllProducers();

        Producer AddProducer(Producer producer);
    }
}
