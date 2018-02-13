using MoviesStore.Service.Common.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.DAL.EFRepository
{
    public class MoviesStoreDBContext : DbContext
    {
        public MoviesStoreDBContext() : base("name = MoviesStoreDb")
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Movie> Movies { get; set; }
         
    }
}
