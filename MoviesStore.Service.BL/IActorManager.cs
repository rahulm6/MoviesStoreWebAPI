using MoviesStore.Service.Common.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.BL
{
    public interface IActorManager
    {
        List<Actor> GetAllActors();

        Actor AddActor(Actor actor);
    }
}
