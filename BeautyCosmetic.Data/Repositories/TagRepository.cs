﻿using BeautyCosmetic.Data.Infrastructure;
using BeautyCosmetic.Model.Models;

namespace BeautyCosmetic.Data.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}