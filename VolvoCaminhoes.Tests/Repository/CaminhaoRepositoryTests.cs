using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using VolvoCaminhoes.Domain.Interfaces.Repository;
using VolvoCaminhoes.Repository.Repositories;
using VolvoCaminhoes.Tests.Repository.Helper;
using Xunit;

namespace VolvoCaminhoes.Tests.Repository
{
    public class CaminhaoRepositoryTests : RepositoryTestsBase, IDisposable
    {
        private IDbContextTransaction _transaction;

        private ICaminhaoRepository _caminhaoRepository;
        private IModeloRepository _modeloRepository;
        private bool disposedValue;

        public CaminhaoRepositoryTests()
        {
            _caminhaoRepository = new CaminhaoRepository(GetContext());
            _modeloRepository = new ModeloRepository(GetContext());
            _transaction = context.Database.BeginTransaction();
        }

        [Fact(DisplayName = "GetAll")]
        [Trait("Categoria", nameof(CaminhaoRepository))]
        public void GetAll()
        {
            var modelo = FactoryHelper.CreateModelo();
            _modeloRepository.Inserir(modelo);

            var caminhao = FactoryHelper.CreateCaminhao(modelo.Id);

            var caminhaoInserido = _caminhaoRepository.Inserir(caminhao);

            var caminhoes = _caminhaoRepository.GetAll();

            Assert.Contains(caminhoes, c => caminhao.IdModelo == c.IdModelo);
            Assert.Contains(caminhoes, c => caminhao.AnoFabricacao == c.AnoFabricacao);
            Assert.Contains(caminhoes, c => caminhao.AnoModelo == c.AnoModelo);
            Assert.Contains(caminhoes, c => caminhao.Modelo.Id == c.Modelo.Id);
            Assert.Contains(caminhoes, c => caminhao.Modelo.Nome == c.Modelo.Nome);
        }

        [Fact(DisplayName = "GetByIdModelo")]
        [Trait("Categoria", nameof(CaminhaoRepository))]
        public void GetByIdModelo()
        {
            var modelo1 = FactoryHelper.CreateModelo();
            _modeloRepository.Inserir(modelo1);
            var idModelo1 = modelo1.Id;

            var modelo2 = FactoryHelper.CreateModelo("FM");
            _modeloRepository.Inserir(modelo2);

            for (int i = 0; i < 1; i++)
            {
                _caminhaoRepository.Inserir(FactoryHelper.CreateCaminhao(modelo1.Id));
            }

            var caminhoes = _caminhaoRepository.GetByModelo(idModelo1);
            
            Assert.True(caminhoes.All(c => c.IdModelo == idModelo1));
        }

        [Fact(DisplayName = "GetById")]
        [Trait("Categoria", nameof(CaminhaoRepository))]
        public void GetById()
        {
            var modelo = FactoryHelper.CreateModelo();
            _modeloRepository.Inserir(modelo);

            var caminhao = FactoryHelper.CreateCaminhao(modelo.Id);

            _caminhaoRepository.Inserir(caminhao);

            var caminhaoInserido = _caminhaoRepository.GetById(caminhao.Id);

            Assert.Equal(caminhao.IdModelo, caminhaoInserido.IdModelo);
            Assert.Equal(caminhao.AnoFabricacao, caminhaoInserido.AnoFabricacao);
            Assert.Equal(caminhao.AnoModelo, caminhaoInserido.AnoModelo);
        }

        [Fact(DisplayName = "Atualizar")]
        [Trait("Categoria", nameof(CaminhaoRepository))]
        public void Atualizar()
        {
            var anoFabricacaoAlteracao = DateTime.Now.AddYears(-1).Year;

            var modelo = FactoryHelper.CreateModelo();
            _modeloRepository.Inserir(modelo);

            var caminhao = FactoryHelper.CreateCaminhao(modelo.Id);

            _caminhaoRepository.Inserir(caminhao);

            caminhao.AnoFabricacao = anoFabricacaoAlteracao;

            _caminhaoRepository.Atualizar(caminhao);

            var caminhaoAtualizado = _caminhaoRepository.GetById(caminhao.Id);

            Assert.Equal(caminhao.IdModelo, caminhaoAtualizado.IdModelo);
            Assert.Equal(anoFabricacaoAlteracao, caminhaoAtualizado.AnoFabricacao);
            Assert.Equal(caminhao.AnoModelo, caminhaoAtualizado.AnoModelo);
        }

        [Fact(DisplayName = "Excluir")]
        [Trait("Categoria", nameof(CaminhaoRepository))]
        public void Excluir()
        {
            var modelo = FactoryHelper.CreateModelo();
            _modeloRepository.Inserir(modelo);

            var caminhao = FactoryHelper.CreateCaminhao(modelo.Id);

            _caminhaoRepository.Inserir(caminhao);

            var idCaminhaoInserido = caminhao.Id;

            _caminhaoRepository.Excluir(caminhao);

            var caminhaoExcluido = _caminhaoRepository.GetById(idCaminhaoInserido);

            Assert.Null(caminhaoExcluido);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _transaction.Rollback();
                    _transaction.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
