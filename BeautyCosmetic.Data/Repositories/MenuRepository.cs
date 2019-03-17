using BeautyCosmetic.Data.Infrastructure;
using BeautyCosmetic.Model.Models;

namespace BeautyCosmetic.Data.Repositories
{
    public interface IMenuRepository : IRepository<Menu>
    {
    }

    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}