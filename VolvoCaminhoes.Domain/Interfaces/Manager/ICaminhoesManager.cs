using System.Collections.Generic;
using VolvoCaminhoes.Domain.Entities;

namespace VolvoCaminhoes.Domain.Interfaces.Manager
{
    public interface ICaminhoesManager
    {
        /// <summary>
        /// Obtém todos os caminhões
        /// </summary>
        /// <returns></returns>
        IEnumerable<Caminhao> ObterTodos();

        /// <summary>
        /// Insere um caminhão
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Caminhao Inserir(Caminhao entity);

        /// <summary>
        /// Atualiza um caminhão
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Atualizar(Caminhao entity);

        /// <summary>
        /// Exclui um caminhão
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Excluir(Caminhao entity);

        /// <summary>
        /// Obtém todos os modelos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Modelo> ObterModelos();
    }
}
