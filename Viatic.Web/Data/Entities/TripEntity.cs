using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Viatic.Web.Data.Entities
{
    public class TripEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public String Description { get; set; }
    }
}
