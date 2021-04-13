using System.Collections.Generic;

namespace WebExtension.Net.Generator.Repositories
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
