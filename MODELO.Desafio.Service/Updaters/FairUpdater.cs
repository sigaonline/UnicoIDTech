using AutoMapper;
using MODELO.Desafio.DAL;
using MODELO.Desafio.DAL.Interface.Entities;
using MODELO.Desafio.Model;
using MODELO.Desafio.Model.Exceptions;
using MODELO.Desafio.Model.Request;
using MODELO.Desafio.Model.Result;
using MODELO.Desafio.Model.Validators;
using MODELO.Desafio.Service.Interface.Providers;
using MODELO.Desafio.Service.Interface.Updaters;
using System.Linq;
using System.Threading.Tasks;

namespace MODELO.Desafio.Service.Updaters
{
    public class FairUpdater : IFairUpdater
    {
        protected readonly DataBaseContext dataBaseContext;
        private readonly IMapper mapper;
        private readonly FairRequestValidator fairRequestValidator;
        private readonly IFairProvider fairProvider;
        public FairUpdater(DataBaseContext dataBaseContext, IMapper mapper, FairRequestValidator fairRequestValidator, IFairProvider fairProvider)
        {
            this.dataBaseContext = dataBaseContext;
            this.mapper = mapper;
            this.fairRequestValidator = fairRequestValidator;
            this.fairProvider = fairProvider;
        }
        public async Task<Fair> SaveAsync(FairRequest dataObject)
        {
            var checkUserExists = await fairProvider.GetByFairNameAsync(dataObject.NameFair);
            if (checkUserExists?.Id != null)
                throw new BusinessException(ExceptionMessages.FairFound);

            var entity = mapper.Map<Fair>(dataObject);
            this.dataBaseContext.Set<Fair>().Add(entity);
            this.dataBaseContext.SaveChanges();
            return entity;
        }
        public async Task<Fair> UpdateAsync(FairRequest dataObject)
        {
            var checkUserExists = await fairProvider.GetByIdAsync(dataObject.Id);
            if (checkUserExists?.Id == null)
                throw new BusinessException(ExceptionMessages.FairNotFound);
            
            var entity = mapper.Map<Fair>(dataObject);
            var entry = dataBaseContext.Fairs.First(e => e.Id == entity.Id);
            dataBaseContext.Entry(entry).CurrentValues.SetValues(entity);
            dataBaseContext.SaveChanges();
            return entity;

        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = dataBaseContext.Fairs.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
                throw new BusinessException(ExceptionMessages.FairNotFound);

            var result = dataBaseContext.Remove(entity);
            dataBaseContext.SaveChanges();
            return true;
        }
    }
}
