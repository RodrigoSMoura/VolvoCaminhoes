﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VolvoCaminhoes.Domain.Entities.IdEntity;
using VolvoCaminhoes.Domain.Interfaces.Repository;

namespace VolvoCaminhoes.Repository.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IIdEntity
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        protected RepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public int Atualizar(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return Salvar();
        }

        public int Excluir(TEntity entity)
        {
            dbSet.Remove(entity);
            return Salvar();
        }

        public TEntity Inserir(TEntity entity)
        {
            var result = dbSet.Add(entity);
            Salvar();
            return result.Entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet;
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        private int Salvar()
        {
            return dbContext.SaveChanges();
        }
    }
}
