using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchaticture.Domain.Model;


namespace CleanArchaticture.Application.Common.Interfaces
{
    public interface IUnitOfWork  
    {
        //IVillaRepository Villa { get; }
        IRepository<Villa> Villa { get; }
        IRepository<VillaNumbers> VillaNumbers { get; }
        IRepository<Amenity> Amenity { get; }
       
        void Save();
 
        //test
        // IRepository<Villa> Villa { get; }

    }
}
