namespace BeerApp.Web.ViewModels.BeerType
{
    using BeerApp.Services.Web;
    using Data.Models;
    using Infrastructure.Mapping;

    public class SimpleBeerTypeResponseViewModel : IMapFrom<BeerType>
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