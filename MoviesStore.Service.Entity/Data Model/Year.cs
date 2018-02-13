using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.Common.Entity.Data_Model
{
    public class Year
    {
        [Key]
        public int YearID { get; set; }

        public string Value { get; set; }
    }
}
