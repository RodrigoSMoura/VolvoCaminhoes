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
        List<Caminhao> ObterTodos();

        /// <summary>
        /// Insere um caminhão
        /// </summary>
        /// <param name="caminhao"></param>
        /// <returns></returns>
        Caminhao Inserir(Caminhao caminhao);

        /// <summary>
        /// Atualiza um caminhão
        /// </summary>
        /// <param name="caminhao"></param>
        /// <returns></returns>
        int Atualizar(Caminhao caminhao);

        /// <summary>
        /// Exclui um caminhão
        /// </summary>
        /// <param name="caminhao"></param>
        /// <returns></returns>
        int Excluir(int id);

        /// <summary>
        /// Obtém todos os modelos
        /// </summary>
        /// <returns></returns>
        List<Modelo> ObterModelos();
        
        /// <summary>
        /// Obtém um caminhão pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Caminhao ObterPorId(int id);

        /// <summary>
        /// Filtra baseado no idModelo e/ou no Ano de Fabricação
        /// </summary>
        /// <param name="idModelo"></param>
        /// <param name="anoFabricacao"></param>
        /// <returns></returns>
        List<Caminhao> Filtrar(int? idModelo, int? anoFabricacao);
    }
}
