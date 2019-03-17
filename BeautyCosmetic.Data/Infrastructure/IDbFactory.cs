using System;

namespace BeautyCosmetic.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        BeautyCosmeticDbContext Init();
    }
}