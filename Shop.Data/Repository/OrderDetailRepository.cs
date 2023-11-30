using Shop.Data.Infastructure;
using Shop.Models.Models;

namespace Shop.Data.Repository
{
    public interface IOrderDetalRepository : IRepository<OrderDetails>
    {
    }

    public class OrderDetailRepository : Repository<OrderDetails>, IOrderDetalRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}