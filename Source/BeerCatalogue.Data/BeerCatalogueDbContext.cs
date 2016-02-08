using BeerCatalogue.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCatalogue.Data
{
    public class BeerCatalogueDbContext : IdentityDbContext<User>
    {
        public BeerCatalogueDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BeerCatalogueDbContext Create()
        {
            return new BeerCatalogueDbContext();
        }
    }
}
