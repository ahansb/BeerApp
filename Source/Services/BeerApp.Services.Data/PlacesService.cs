namespace BeerApp.Services.Data
{
    using System;
    using System.Linq;
    using BeerApp.Data.Common;
    using BeerApp.Data.Models;
    using Web;

    public class PlacesService : IPlacesService
    {
        private readonly IDbRepository<Place> places;
        private readonly IIdentifierProvider identifierProvider;

        public PlacesService(IDbRepository<Place> places, IIdentifierProvider identifierProvider)
        {
            this.places = places;
            this.identifierProvider = identifierProvider;
        }

        public int Add(Place place)
        {
            this.places.Add(place);
            this.places.Save();
            return place.Id;
        }

        public Place GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var place = this.places.GetById(intId);

            return place;
        }

        public IQueryable<Place> GetAll()
        {
            return this.places.All();
        }
    }
}
