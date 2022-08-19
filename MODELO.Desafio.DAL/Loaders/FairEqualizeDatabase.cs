using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MODELO.Desafio.DAL.Loaders
{
    [ExcludeFromCodeCoverageAttribute]
    public class FairEqualizeDatabase
    {
        public void Equalize(DataBaseContext context)
        {
            var registerInDatabase = context.Fairs;
            var querySourceInDataLoader = new FairDataLoader().Load().ToList();
            if (querySourceInDataLoader != null && querySourceInDataLoader.Any())
            {
                var idsOnDatabase = registerInDatabase.Select(e => e.Id);

                var divisionLocalToInsert = querySourceInDataLoader.Where(x => !idsOnDatabase.Contains(x.Id));
                context.AddRange(divisionLocalToInsert);

                context.SaveChanges();
            }
        }
    }
}
