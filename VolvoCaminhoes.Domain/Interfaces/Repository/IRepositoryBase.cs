using System.Collections.Generic;
using VolvoCaminhoes.Domain.Entities.IdEntity;

namespace VolvoCaminhoes.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IIdEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);

        TEntity Inserir(TEntity entity);

        int Atualizar(TEntity entity);

        int Excluir(TEntity entity);
    }
}
