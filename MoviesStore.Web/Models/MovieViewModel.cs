using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MoviesStore.Web.Models
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {
            this.Actors = new List<ActorViewModel>();
            this.Producer = new ProducerViewModel();
            //this.Files = new List<HttpPostedFileBase>();
        }
        public int MovieID { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required]
        
        public string YearOfRelease { get; set; }


        [Required]
        [Display(Name = "Movie Plot")]
        public string Plot { get; set; }

        [Display(Name = "Movie Poster")]
        public string Poster { get; set; }

        public HttpPostedFileBase File { get; set; }
        //public List<HttpPostedFileBase> Files { get; set; }

        public List<ActorViewModel> Actors { get; set; }

        public List<YearViewModel> Years { get; set; }

        [Display(Name="Producer Name")]
        public int ProducerID { get; set; }

        public ProducerViewModel Producer { get; set; }
    }
}
