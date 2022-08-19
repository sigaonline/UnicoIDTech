using MODELO.Desafio.DAL.Interface.Entities;


namespace MODELO.Desafio.MStest.Builders.Entities
{
    public class FairBuilder : BaseBuilder<Fair>
    {
        public FairBuilder Default()
        {
            _instance.Id = 1;
            _instance.District = "distrito";
            _instance.Region = "região";
            _instance.NameFair = "nome da feira";
            _instance.Neighborhood = "bairro da feira";
            return this;
        }

    }
}
