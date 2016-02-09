namespace BeerCatalogue.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<Beer> beers;
        private ICollection<Bar> bars;
        private ICollection<Store> stores;


        public User() : base()
        {
            this.beers = new HashSet<Beer>();
            this.bars = new HashSet<Bar>();
            this.stores = new HashSet<Store>();
        }

        public virtual ICollection<Beer> Beers { get { return this.beers; } set { this.beers = value; } }

        public virtual ICollection<Bar> Bars { get { return this.bars; } set { this.bars = value; } }

        public virtual ICollection<Store> Stores { get { return this.stores; } set { this.stores = value; } }




        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
