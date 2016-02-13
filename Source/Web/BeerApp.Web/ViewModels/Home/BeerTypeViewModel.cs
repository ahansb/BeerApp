namespace BeerApp.Web.ViewModels.Home
{
    using BeerApp.Services.Web;
    using Data.Models;
    using Infrastructure.Mapping;

    public class BeerTypeViewModel : IMapFrom<BeerType>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Joke/{identifier.EncodeId(this.Id)}";
            }
        }
    }
}