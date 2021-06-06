using System.Collections.Generic;

namespace WebExtensions.Net.Generator.Repositories
{
    public class BaseRepository<TEntity>
    {
        protected List<TEntity> Entities { get; }

        public BaseRepository()
        {
            Entities = new List<TEntity>();
        }
    }
}
