namespace BeautyCosmetic.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BeautyCosmeticDbContext dbContext;

        public BeautyCosmeticDbContext Init()
        {
            return dbContext ?? (dbContext = new BeautyCosmeticDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}