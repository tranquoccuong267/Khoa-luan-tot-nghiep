using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using BeautyCosmetic.Common.ViewModels;
using BeautyCosmetic.Data.Infrastructure;
using BeautyCosmetic.Model.Models;
namespace BeautyCosmetic.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);

        IEnumerable<Order> GetAllnew();
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Order> GetAllnew()
        {
            var query = DbContext.Orders;
            return DbContext.Orders;
        }

        public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@fromDate",fromDate),
                new SqlParameter("@toDate",toDate)
            };
            return DbContext.Database.SqlQuery<RevenueStatisticViewModel>("GetRevenueStatistic @fromDate,@toDate", parameters);
        }
    }
}