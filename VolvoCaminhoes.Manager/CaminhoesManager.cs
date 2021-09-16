using System;
using System.Collections.Generic;
using VolvoCaminhoes.Domain.Entities;
using VolvoCaminhoes.Domain.Erros;
using VolvoCaminhoes.Domain.Interfaces.Manager;
using VolvoCaminhoes.Domain.Interfaces.Repository;
using VolvoCaminhoes.Domain.Resources;

namespace VolvoCaminhoes.Manager
{
    public class CaminhoesManager : ICaminhoesManager
    {
        private ICaminhaoRepository _caminhoesRepository;
        private IModeloRepository _modeloRepository;
        public CaminhoesManager(ICaminhaoRepository caminhoesRepository, IModeloRepository modeloRepository)
        {
            _caminhoesRepository = caminhoesRepository;
            _modeloRepository = modeloRepository;
        }

        public int Atualizar(Caminhao caminhao)
        {
            return _caminhoesRepository.Atualizar(caminhao);
        }

        public int Excluir(Caminhao caminhao)
        {
            return _caminhoesRepository.Excluir(caminhao);
        }

        public Caminhao Inserir(Caminhao caminhao)
        {
            if (caminhao.IdModelo == 0)
                throw new RegraDeNegocioException(Mensagens.ERRO_MODELO_NAO_INFORMADO);
            return _caminhoesRepository.Inserir(caminhao);
        }

        public IEnumerable<Modelo> ObterModelos()
        {
            return _modeloRepository.GetAll();
        }

        public IEnumerable<Caminhao> ObterTodos()
        {
            return _caminhoesRepository.GetAll();
        }
    }
}
