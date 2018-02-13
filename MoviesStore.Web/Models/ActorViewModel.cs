using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Web.Models
{
    public class ActorViewModel
    {
        public ActorViewModel()
        {
            this.Movies = new List<MovieViewModel>();
        }

        public int ActorID { get; set; }

        [Display(Name = "Actor")]
        public string Name { get; set; }
        public string Sex { get; set; }
        public string DOB { get; set; }

        public string Bio { get; set; }

        public List<MovieViewModel> Movies { get; set; }
    }
}
