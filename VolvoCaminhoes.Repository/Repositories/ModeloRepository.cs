using VolvoCaminhoes.Domain.Entities;
using VolvoCaminhoes.Domain.Interfaces.Repository;
using VolvoCaminhoes.Repository.Database.Context;
using VolvoCaminhoes.Repository.Repositories.Base;

namespace VolvoCaminhoes.Repository.Repositories
{
    public class ModeloRepository : RepositoryBase<Modelo>, IModeloRepository
    {
        public ModeloRepository(VolvoCaminhoesContext context) : base(context)
        {

        }
    }
}
