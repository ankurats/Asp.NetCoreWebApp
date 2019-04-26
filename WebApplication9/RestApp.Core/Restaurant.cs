using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestApp.Core
{
   
   public class Restaurant 
    {
        public int  Id { get; set; }

        [Required, StringLength(80)]
        public string Title { get; set; }

        [Required, StringLength(50)]
        public string City { get; set; }

        [Required]
        public CuisineType Cuisine { get; set; }
    }
}
