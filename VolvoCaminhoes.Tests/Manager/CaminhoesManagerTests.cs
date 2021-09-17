using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolvoCaminhoes.Domain.Entities;
using VolvoCaminhoes.Domain.Erros;
using VolvoCaminhoes.Domain.Interfaces.Repository;
using VolvoCaminhoes.Domain.Resources;
using VolvoCaminhoes.Manager;
using Xunit;

namespace VolvoCaminhoes.Tests.Manager
{
    public class CaminhoesManagerTests
    {
        private readonly AutoMocker _mocker;

        public CaminhoesManagerTests()
        {
            _mocker = new AutoMocker();
        }

        [Fact]
        public void ObterTodos_Success()
        {
            var caminhaoList = new List<Caminhao>()
            {
                new Caminhao()
            };

            _mocker.GetMock<ICaminhaoRepository>()
                .Setup(c => c.GetAll())
                .Returns(caminhaoList);

            _mocker.GetMock<IModeloRepository>();

            var manager = _mocker.CreateInstance<CaminhoesManager>();

            var caminhoes = manager.ObterTodos();

            Assert.NotNull(caminhoes);
            Assert.True(caminhoes.Any());
        }

        [Fact]
        public void ObterModelos_Success()
        {
            var modeloList = new List<Modelo>()
            {
                new Modelo()
            };

            _mocker.GetMock<IModeloRepository>()
                .Setup(c => c.GetAll())
                .Returns(modeloList);

            _mocker.GetMock<ICaminhaoRepository>();

            var manager = _mocker.CreateInstance<CaminhoesManager>();

            var modelos = manager.ObterModelos();

            Assert.NotNull(modelos);
            Assert.True(modelos.Any());
        }

        [Fact]
        public void Inserir_Success()
        {
            var caminhao = new Caminhao()
            {
                IdModelo = 1
            };

            _mocker.GetMock<ICaminhaoRepository>()
                .Setup(c => c.Inserir(It.IsAny<Caminhao>()))
                .Returns(caminhao);

            _mocker.GetMock<IModeloRepository>();

            var manager = _mocker.CreateInstance<CaminhoesManager>();

            var caminhaoInserido = manager.Inserir(caminhao);

            Assert.NotNull(caminhaoInserido);
        }

        [Fact]
        public void Inserir_Erro_ModeloNaoInformado()
        {
            var caminhao = new Caminhao();

            _mocker.GetMock<ICaminhaoRepository>()
                .Setup(c => c.Inserir(It.IsAny<Caminhao>()))
                .Returns(caminhao);

            _mocker.GetMock<IModeloRepository>();

            var manager = _mocker.CreateInstance<CaminhoesManager>();
            try
            {
                var caminhaoInserido = manager.Inserir(caminhao);
                Assert.Null(caminhaoInserido);
            }
            catch(RegraDeNegocioException ex)
            {
                Assert.Equal(ex.Message, Mensagens.ERRO_MODELO_NAO_INFORMADO);
            }
        }

        [Fact]
        public void Atualizar_Success()
        {
            var caminhao = new Caminhao();
            var updateReturn = 1;

            _mocker.GetMock<ICaminhaoRepository>()
                .Setup(c => c.Atualizar(It.IsAny<Caminhao>()))
                .Returns(updateReturn);

            _mocker.GetMock<IModeloRepository>();

            var manager = _mocker.CreateInstance<CaminhoesManager>();

            var retorno = manager.Atualizar(caminhao);

            Assert.Equal(retorno, updateReturn);
        }

        [Fact]
        public void Excluir_Success()
        {
            var caminhao = new Caminhao() { Id = 1 };
            var deleteReturn = 1;

            _mocker.GetMock<ICaminhaoRepository>()
                .Setup(c => c.Excluir(It.IsAny<int>()))
                .Returns(deleteReturn);

            _mocker.GetMock<IModeloRepository>();

            var manager = _mocker.CreateInstance<CaminhoesManager>();

            var retorno = manager.Excluir(caminhao.Id);

            Assert.Equal(retorno, deleteReturn);
        }
    }
}
