namespace BeerApp.Web.ViewModels.Country
{
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class CountryResponseViewModel : IMapFrom<Country>
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"{identifier.EncodeId(this.Id)}";
            }
        }
    }
}