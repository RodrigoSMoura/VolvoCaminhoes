using System;

namespace VolvoCaminhoes.Domain.Erros
{
    public class RegraDeNegocioException : Exception
    {
        public RegraDeNegocioException(string mensagem) : base(mensagem) { }
    }
}
