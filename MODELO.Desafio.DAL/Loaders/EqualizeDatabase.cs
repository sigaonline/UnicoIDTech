using MODELO.Desafio.DAL.Interface.Loaders;
using System.Diagnostics.CodeAnalysis;

namespace MODELO.Desafio.DAL.Loaders
{
    [ExcludeFromCodeCoverageAttribute]
    public class EqualizeDatabase : IEqualizeDatabase
    {
        private readonly DataBaseContext context;

        public EqualizeDatabase(DataBaseContext context)
        {
            this.context = context;
        }

        public void Sync()
        {
            new FairEqualizeDatabase().Equalize(context);
        }
    }
}