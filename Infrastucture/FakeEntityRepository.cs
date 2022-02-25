using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Infrastucture
{
    public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected ICollection<TEntity> entities;

        public virtual void Add(TEntity entity)
        {
            int id = entities.Max(e => e.Id);

            entity.Id = ++id;

            entities.Add(entity);
        }

        public virtual bool Exists(int id)
        {
            return entities.Any(e => e.Id == id);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public virtual TEntity Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public virtual void Remove(int id)
        {
            entities.Remove(Get(id));
        }

        public virtual void Update(TEntity entity)
        {
            Remove(entity.Id);

            entities.Add(entity);
        }
    }
}
