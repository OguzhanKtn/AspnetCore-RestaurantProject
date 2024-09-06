using EntityLayer.Entities;


namespace BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        int TTotalCount();
        int TActiveOrderCount();
        int TPassiveOrderCount();
        decimal LastOrderPrice();
        decimal TodayTotalPrice();
    }
}
