namespace BeerApp.Web.ViewModels.Beer
{
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class BeerResponseViewModel : IMapFrom<Beer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ProducedSince { get; set; }

        public decimal AlcoholContaining { get; set; }

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
