using MODELO.Desafio.DAL.Interface.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MODELO.Desafio.DAL.Loaders
{
    [ExcludeFromCodeCoverageAttribute]
    public class FairDataLoader
    {
        public IEnumerable<Fair> Load()
        {
            var path = $@"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/Csv/DEINFO_AB_FEIRASLIVRES_2014.csv";
            if (File.Exists(path))
            return File.ReadAllLines(path)
                               .Skip(1)
                               .Select(x => x.Split(','))
                               .Select(x => new Fair
                               {
                                   Id = int.Parse(x[0]),
                                   District = x[6],
                                   Region = x[9],
                                   NameFair = x[11],
                                    Neighborhood = x[15],
                               });

            return null;
        }
    }
}
