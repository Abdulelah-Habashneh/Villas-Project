using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using CleanArchaticture.Application.Common.Interfaces;
using CleanArchaticture.Domain.Model;
using CleanArchaticture.Infrastructure.Data;

namespace CleanArchaticture.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {   
        //to deal with database
        private readonly ApplicationDbContext _context;
           
        // to dela with entity  
        // i can add whatever i want like villanumber
        // i have activated it in generic repo ><><><3
        public IRepository<Villa> Villa { get; private set; }
        public IRepository<VillaNumbers> VillaNumbers { get; private set; }
        public IRepository<Amenity> Amenity { get; private set; }


        
        
         

      


         

        //constuctotr to add any entity i need
        public UnitOfWork(ApplicationDbContext context)
           {
                    _context=context;
                    Villa = new Repository<Villa>(_context);
                    VillaNumbers = new Repository<VillaNumbers>(_context);
                    Amenity=new Repository<Amenity>(_context);
                  
           }

        public void Save()
        {
            _context.SaveChanges();
        }

 
         
    }
}
    