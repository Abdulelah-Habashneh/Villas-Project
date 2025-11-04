using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchaticture.Domain.Model
{
    public class Amenity
    {
         
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty; // مطلوب
            public string? Description { get; set; } // اختياري
       

        [ForeignKey("Villa")]
        public int VillaId  { get; set; }

        //navigation property 
       public Villa Villa { get; set; }  

    }
}
