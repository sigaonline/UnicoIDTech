using MODELO.Desafio.Model.Result;

namespace MODELO.Desafio.MStest.Builders.Contracts
{
    public class FairResultBuilder : BaseBuilder<FairResult>
    {
        public FairResultBuilder Default()
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
