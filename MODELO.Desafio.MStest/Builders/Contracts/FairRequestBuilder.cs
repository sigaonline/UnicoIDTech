using MODELO.Desafio.Model.Request;

namespace MODELO.Desafio.MStest.Builders.Contracts
{
    public class FairRequestBuilder : BaseBuilder<FairRequest>
    {
        public FairRequestBuilder Default()
        {
            _instance.District = "distrito";
            _instance.Region = "região";
            _instance.NameFair = "nome da feira";
            _instance.Neighborhood = "bairro da feira";
            return this;
        }

    }
}
