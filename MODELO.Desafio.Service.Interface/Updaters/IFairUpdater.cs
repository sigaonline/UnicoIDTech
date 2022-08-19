using MODELO.Desafio.DAL.Interface.Entities;
using MODELO.Desafio.Model.Request;
using System.Threading.Tasks;

namespace MODELO.Desafio.Service.Interface.Updaters
{
    public interface IFairUpdater
    {
        Task<Fair> SaveAsync(FairRequest dataObject);
        Task<Fair> UpdateAsync(FairRequest dataObject);
        Task<bool> DeleteByIdAsync(int id);
    }
}
