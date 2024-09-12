using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly ITableService _tableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, ITableService tableService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_tableService = tableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}

		public async Task SendStatistic()
		{
			var value = _categoryService.GetCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount",value);

            var value2 = _productService.GetProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.ActiveCategoryCount();
            await Clients.All.SendAsync("ActiveCategoryCount", value3);

            var value4 = _categoryService.PassiveCategoryCount();
            await Clients.All.SendAsync("PassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("TotalHamburgerCount", value5);

            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("TotalBeverageCount", value6);

            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ProductPriceAvg", value7.ToString("0.00") + "₺");

            var value8 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ProductNameByMaxPrice", value8);

            var value9 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ProductNameByMinPrice", value9);

            var value10 = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("AvgPriceByHamburger", value10.ToString("0.00") + "₺");

            var value11 = _orderService.TTotalCount();
            await Clients.All.SendAsync("OrdersCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ActiveOrdersCount", value12);

            var value13 = _orderService.TodayTotalPrice();
            await Clients.All.SendAsync("TodayTotalPrice", value13);

            var value14 = _orderService.LastOrderPrice();
            await Clients.All.SendAsync("LastOrderPrice", value14.ToString("0.00") + "₺");

            var value15 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("TotalMoneyCaseAmount", value15.ToString("0.00") + "₺");

            var value16 = _tableService.TableCount();
            await Clients.All.SendAsync("TableCount", value16);
        }

        public async Task SendProgress()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("TotalMoneyCaseAmount", value.ToString("0.00") + "₺");

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ActiveOrderCount", value2);

            var value3 = _tableService.TableCount();
            await Clients.All.SendAsync("TableCount", value3);
        }

        public async Task GetBookingList()
        {
            var value = _bookingService.TGetAll();
            await Clients.All.SendAsync("ReceiveBookingList", value);
        }

        public async Task SendNotification()
        {
            var value = _notificationService.NotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var value2 = _notificationService.GetAllNotifications();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", value2);
        }
    }
}
