using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.Common.Entity.DataModel
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Sex { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DOB { get; set; }

        public string Bio { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
