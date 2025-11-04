using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CleanArchaticture.Domain.Model
{
    public class Villa
    {
        public int Id { get; set; }
        public required string Name { get; set; }

                    

        public string? Description { get; set; }
        [Display(Name ="Price Per Night")]
        [Range(10,10000)]
        public double Price { get; set; }
      
        public int Sqft { get; set; }
        public int Occupancy { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        public string? ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


        [ValidateNever]
        public ICollection<Amenity> Amenities { get; set; }
       


    }
}
