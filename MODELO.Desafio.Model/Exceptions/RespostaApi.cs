using System.Diagnostics.CodeAnalysis;

namespace MODELO.Desafio.Model.Exceptions
{
    [ExcludeFromCodeCoverageAttribute]
    public class RespostaApi<T>
    {
        public T dados { get; set; }
        public bool erro { get; set; }
        public string mensagem { get; set; }
    }
}
