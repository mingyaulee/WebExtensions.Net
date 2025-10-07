using System.Collections.Generic;

namespace WebExtensions.Net.Generator.Repositories
{
    public class BaseRepository<TEntity>
    {
        protected List<TEntity> Entities { get; }

        public BaseRepository()
        {
            Entities = [];
        }

        public void Clear() => Entities.Clear();
    }
}
