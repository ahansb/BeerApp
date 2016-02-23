namespace BeerApp.Services.Data
{
    using System;
    using System.Linq;
    using BeerApp.Data.Common.Repositories.Contracts;
    using BeerApp.Data.Models;
    using Web;

    public class BeerTypesService : IBeerTypesService
    {
        private readonly IDbRepository<BeerType> beerTypes;
        private readonly IIdentifierProvider identifierProvider;
        private readonly IDeletableEntityRepository<BeerType> deleteableRepo;


        public BeerTypesService(IDbRepository<BeerType> beerTypes, IIdentifierProvider identifierProvider, IDeletableEntityRepository<BeerType> deleteableRepo)
        {
            this.beerTypes = beerTypes;
            this.identifierProvider = identifierProvider;
            this.deleteableRepo = deleteableRepo;
        }

        public IQueryable<BeerType> GetAll()
        {
            return this.beerTypes.All();
        }

        public BeerType GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var beerType = this.beerTypes.GetById(intId);

            return beerType;
        }

        public BeerType GetByIntId(int id)
        {
            var beerType = this.beerTypes.GetById(id);

            return beerType;
        }

        public IQueryable<BeerType> GetRandom(int count)
        {
            return this.beerTypes.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }

        public int AdminCreate(BeerType entity)
        {
            this.deleteableRepo.Add(entity);
            this.deleteableRepo.SaveChanges();
            return entity.Id;
        }

        public int AdminUpdate(BeerType entity)
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
