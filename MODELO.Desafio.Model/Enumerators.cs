using System.ComponentModel;

namespace MODELO.Desafio.Model
{
    public enum ExceptionMessages
    {
        [Description("Feira não existe na base de dados!")] FairNotFound,
        [Description("Feira já existe na base de dados!")] FairFound
    }
}
