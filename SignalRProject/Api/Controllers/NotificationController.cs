﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.NotificationCountByStatusFalse());
		}
		[HttpGet("{id}")]
		public IActionResult MakeNotificationStatusTrue(int id)
		{
			_notificationService.MakeNotificationStatusTrue(id);
			return Ok();
		}
	}
}
