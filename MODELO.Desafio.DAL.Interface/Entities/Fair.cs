using MODELO.Desafio.Model.Entities;

namespace MODELO.Desafio.DAL.Interface.Entities
{
    public class Fair : BaseEntity
    {
        public string District { get; set; }
        public string Region { get; set; }
        public string NameFair { get; set; }
        public string Neighborhood { get; set; }
    }
}
