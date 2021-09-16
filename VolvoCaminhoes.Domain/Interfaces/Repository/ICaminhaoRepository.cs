using System.Collections.Generic;
using VolvoCaminhoes.Domain.Entities;

namespace VolvoCaminhoes.Domain.Interfaces.Repository
{
    public interface ICaminhaoRepository : IRepositoryBase<Caminhao>
    {
        /// <summary>
        /// Obtém caminhões por Modelo
        /// </summary>
        /// <param name="idModelo"></param>
        /// <returns></returns>
        IEnumerable<Caminhao> GetByModelo(int idModelo);
    }
}
