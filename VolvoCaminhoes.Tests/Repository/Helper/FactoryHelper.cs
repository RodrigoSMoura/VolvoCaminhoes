using System;
using System.Diagnostics.CodeAnalysis;
using VolvoCaminhoes.Domain.Entities;

namespace VolvoCaminhoes.Tests.Repository.Helper
{
    [ExcludeFromCodeCoverage]
    public static class FactoryHelper
    {
        public static Caminhao CreateCaminhao(int idModelo)
        {
            return new Caminhao()
            {
                IdModelo = idModelo,
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year
            };
        }
        public static Modelo CreateModelo()
        {
            return CreateModelo("FH");
        }

        public static Modelo CreateModelo(string nome)
        {
            return new Modelo()
            {
                Nome = nome
            };
        }
    }
}
