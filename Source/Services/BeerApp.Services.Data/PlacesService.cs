namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Common.Repositories.Contracts;
    using BeerApp.Data.Models;
    using Web;

    public class PlacesService : IPlacesService
    {
        private readonly IDbRepository<Place> places;
        private readonly IIdentifierProvider identifierProvider;
        private readonly IDeletableEntityRepository<Place> deleteableRepo;

        public PlacesService(IDbRepository<Place> places, IIdentifierProvider identifierProvider, IDeletableEntityRepository<Place> deleteableRepo)
        {
            this.places = places;
            this.identifierProvider = identifierProvider;
            this.deleteableRepo = deleteableRepo;
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

        public Place GetByIntId(int id)
        {
            var place = this.places.GetById(id);

            return place;
        }

        public IQueryable<Place> GetAll()
        {
            return this.places.All();
        }

        public int AdminCreate(Place entity)
        {
            this.deleteableRepo.Add(entity);
            this.deleteableRepo.SaveChanges();
            return entity.Id;
        }

        public int AdminUpdate(Place entity)
        {
            this.deleteableRepo.Update(entity);
            this.deleteableRepo.SaveChanges();
            return entity.Id;
        }

        public void AdminDestroy(int id)
        {
            this.deleteableRepo.Delete(id);
            this.deleteableRepo.SaveChanges();
        }

        public void AdminDispose()
        {
            this.deleteableRepo.Dispose();
        }

    }
}
