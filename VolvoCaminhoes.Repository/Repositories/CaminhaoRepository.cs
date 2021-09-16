using System.Collections.Generic;
using System.Linq;
using VolvoCaminhoes.Domain.Entities;
using VolvoCaminhoes.Domain.Interfaces.Repository;
using VolvoCaminhoes.Repository.Database.Context;
using VolvoCaminhoes.Repository.Repositories.Base;

namespace VolvoCaminhoes.Repository.Repositories
{
    public class CaminhaoRepository : RepositoryBase<Caminhao>, ICaminhaoRepository
    {
        public CaminhaoRepository(VolvoCaminhoesContext context) : base(context)
        {
            
        }

        public IEnumerable<Caminhao> GetByModelo(int idModelo)
        {
            return dbSet.Where(c => c.IdModelo == idModelo);
        }
    }
}
