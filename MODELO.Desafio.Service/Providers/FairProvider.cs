using AutoMapper;
using MODELO.Desafio.DAL;
using MODELO.Desafio.DAL.Interface.Entities;
using MODELO.Desafio.Model.Result;
using MODELO.Desafio.Service.Interface.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MODELO.Desafio.Service.Providers
{
    public class FairProvider : IFairProvider
    {
        protected readonly DataBaseContext dataBaseContext;
        private readonly IMapper mapper;
        public FairProvider(DataBaseContext dataBaseContext, IMapper mapper)
        {
            this.dataBaseContext = dataBaseContext;
            this.mapper = mapper;
        }

        public async Task<List<Fair>> GetAllAsync()
        {
            var result = dataBaseContext.Set<Fair>().ToList();
            return result;
        }
        public async Task<FairResult> GetByIdAsync(int id)
        {
            var result = dataBaseContext.Set<Fair>().Find(id);
            return mapper.Map<FairResult>(result);
        }
        public async Task<FairResult> GetByFairNameAsync(string FairName)
        {
            var result = dataBaseContext.Fairs.Where(x => x.NameFair.Equals(FairName)).FirstOrDefault();
            return result == null ? null : mapper.Map<FairResult>(result);
        }

    }
}
