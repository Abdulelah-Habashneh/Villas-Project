using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchaticture.Domain.Model
{
    public class VillaNumbers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNumber { get; set; }

        [ForeignKey("Villa")]
        public int VillaId { get; set; }

        [ValidateNever]
        public   Villa villa { get; set; }

        public string? SpecialDetails { get; set; } = null;


    }
}
