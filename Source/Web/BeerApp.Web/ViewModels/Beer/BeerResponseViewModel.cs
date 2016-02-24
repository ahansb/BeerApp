namespace BeerApp.Web.ViewModels.Beer
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using BeerType;
    using Country;
    using Data.Models;
    using Infrastructure.Mapping;
    using Place;
    using Services.Web;
    using System.Linq;

    public class BeerResponseViewModel : IMapFrom<Beer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual BeerTypeResponseViewModel Type { get; set; }

        public virtual CountryResponseViewModel Country { get; set; }

        public string Description { get; set; }

        public int? ProducedSince { get; set; }

        public decimal AlcoholContaining { get; set; }

        public string PhotoUrl { get; set; }

        public int VotesCount { get; set; }

        //public virtual ICollection<CommentResponseViewModel> Comments { get; set; }

        public virtual ICollection<PlaceResponseViewModel> Places { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Beer, BeerResponseViewModel>()
                            .ForMember(x => x.VotesCount, opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(v => (int)v.Type) : 0));
        }
    }
}
