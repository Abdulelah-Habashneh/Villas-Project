using CleanArchaticture.Domain.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchaticture.View_model
{
    public class VillaNumberVM
    {
        //test VM
        public VillaNumbers? VillaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> VillaList { get; set; }


    }
}
