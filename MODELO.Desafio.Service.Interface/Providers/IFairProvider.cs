using MODELO.Desafio.DAL.Interface.Entities;
using MODELO.Desafio.Model.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MODELO.Desafio.Service.Interface.Providers
{
    public interface IFairProvider
    {
        Task<List<Fair>> GetAllAsync();
        Task<FairResult> GetByIdAsync(int id);
        Task<FairResult> GetByFairNameAsync(string FairName);
    }
}
