using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Web.Service.Facade.DTO
{
    public class MovieDTO
    {
        
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string YearOfRelease { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }

        public List<ActorDTO> Actors { get; set; }

        public int ProducerID { get; set; }

        public ProducerDTO Producer { get; set; }
    }
}
