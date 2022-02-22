using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Infrastucture
{
    public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected ICollection<TEntity> entities;

        public void Add(TEntity entity)
        {
            int id = entities.Max(e => e.Id);

            entity.Id = ++id;

            entities.Add(entity);
        }

        public bool Exists(int id)
        {
            return entities.Any(e => e.Id == id);
        }

        public IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public void Remove(int id)
        {
            entities.Remove(Get(id));
        }

        public void Update(TEntity entity)
        {
            Remove(entity.Id);

            entities.Add(entity);
        }
    }
}
