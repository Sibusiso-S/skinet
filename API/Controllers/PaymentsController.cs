using API.Controllers;
using API.Errors;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Order = Core.Entities.OrderAggregate.Order;

namespace API
{
	public class PaymentsController : BaseApiController
	{
		private readonly IPaymentService _paymentService;
		public readonly string _whSecret;
		private readonly ILogger<PaymentsController> _logger;
		public PaymentsController(IPaymentService paymentService, ILogger<PaymentsController> logger, IConfiguration configuration)
		{
			_whSecret = configuration.GetSection("StripeSettings:WhSecret").Value;
			_logger = logger;
			_paymentService = paymentService;
		}

		[Authorize]
		[HttpPost("{basketId}")]
		public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
		{
			var basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);

			if (basket == null)
			{
				return BadRequest(new ApiResponse(400, "Problem with the basket"));
			}

			return basket;
		}

		[HttpPost("webhook")]
		public async Task<ActionResult> StripeWebhook()
		{
			var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

			var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], _whSecret);

			PaymentIntent intent;
			Order order;

			switch (stripeEvent.Type)
			{
				case "payment_intent.succeeded":
					intent = (PaymentIntent)stripeEvent.Data.Object;
					_logger.LogInformation("Payment succeeded: ", intent.Id);
					order = await _paymentService.UpdateOrderPaymentSucceeded(intent.Id);
					_logger.LogInformation("Order updated to payment recevied: ", order.Id);
					break;
				case "payment_intent.payment_failed":
					intent = (PaymentIntent)stripeEvent.Data.Object;
					_logger.LogInformation("Payment Faield: ", intent.Id);
					order = await _paymentService.UpdateOrderPaymentFailed(intent.Id);
					_logger.LogInformation("Failed: ", order.Id);
					break;
			}
			return new EmptyResult();
		}

	}
}