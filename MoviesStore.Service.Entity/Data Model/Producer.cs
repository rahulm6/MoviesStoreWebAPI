using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.Common.Entity.DataModel
{
    public class Producer
    {
        [Key]
        public int ProducerID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DOB { get; set; }
        public string Bio { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
