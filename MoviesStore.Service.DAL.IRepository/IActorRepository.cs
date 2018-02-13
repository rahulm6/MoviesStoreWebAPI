using MoviesStore.Service.Common.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.DAL.IRepository
{
    public interface IActorRepository
    {
        List<Actor> GetAllActors(string spName, string providerName, string connectionString);

        Actor AddActor(Actor actor, string spName, string providerName, string connectionString);
    }
}
