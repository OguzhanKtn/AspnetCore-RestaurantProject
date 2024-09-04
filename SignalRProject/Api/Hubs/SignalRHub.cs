using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
	public class SignalRHub : Hub
	{
		SignalRContext context = new SignalRContext();

		public async Task SendCategoryCount()
		{
			var value = context.Categories.Count();
			await Clients.All.SendAsync("ReceiveCategoryCount",value);
		}
	}
}
