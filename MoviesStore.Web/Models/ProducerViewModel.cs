using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Web.Models
{
    public class ProducerViewModel
    {
        public ProducerViewModel()
        {
            this.Movies = new List<MovieViewModel>();
        }

        public int ProducerID { get; set; }

        [Required]
        [Display(Name = "Producer Name")]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        public string Sex { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        public List<MovieViewModel> Movies { get; set; }
    }
}
