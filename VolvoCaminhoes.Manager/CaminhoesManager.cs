using System;
using System.Collections.Generic;
using System.Linq;
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
            Validar(caminhao);
            return _caminhoesRepository.Atualizar(caminhao);
        }

        public int Excluir(int id)
        {
            return _caminhoesRepository.Excluir(id);
        }

        public Caminhao Inserir(Caminhao caminhao)
        {
            Validar(caminhao);
            return _caminhoesRepository.Inserir(caminhao);
        }

        public List<Modelo> ObterModelos()
        {
            return _modeloRepository.GetAll().ToList();
        }

        public List<Caminhao> ObterTodos()
        {
            return _caminhoesRepository.GetAll().ToList();
        }

        public List<Caminhao> Filtrar(int? idModelo, int? anoFabricacao)
        {
            return _caminhoesRepository.Filter(c => (!idModelo.HasValue || c.IdModelo == idModelo.Value)
                                                 && (!anoFabricacao.HasValue || c.AnoFabricacao == anoFabricacao.Value)).ToList();
        }

        public Caminhao ObterPorId(int id)
        {
            return _caminhoesRepository.GetById(id);
        }

        private void Validar(Caminhao caminhao)
        {

            if (caminhao.IdModelo == 0)
                throw new RegraDeNegocioException(Mensagens.ERRO_MODELO_NAO_INFORMADO);

            if (caminhao.AnoFabricacao != DateTime.Now.Year)
                throw new RegraDeNegocioException(Mensagens.ERRO_ANO_FABRICACAO_INVALIDO);

            if (caminhao.AnoModelo < DateTime.Now.Year || caminhao.AnoModelo > DateTime.Now.AddYears(1).Year)
                throw new RegraDeNegocioException(Mensagens.ERRO_ANO_MODELO_INVALIDO);
        }
    }
}
