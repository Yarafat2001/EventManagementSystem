using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using EventManagementSystem.Models; // Assuming you have a StripeSettings model
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class CheckoutController : Controller
{
    // You would create a StripeSettings class to hold your keys
    // and configure it in Program.cs
    private readonly string _secretKey;

    public CheckoutController() // In a real app, inject IOptions<StripeSettings>
    {
        // Replace with your actual secret key, ideally from appsettings.json
        _secretKey = "sk_test_YOUR_SECRET_KEY";
        StripeConfiguration.ApiKey = _secretKey;
    }

    [HttpPost]
    public ActionResult CreateCheckoutSession(int ticketTypeId, string ticketName, long unitAmount)
    {
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = unitAmount, // Price in cents (e.g., 2000 for $20.00)
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = ticketName,
                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            // These URLs are where Stripe will redirect the user after payment
            SuccessUrl = Url.Action("OrderConfirmation", "Home", null, Request.Scheme),
            CancelUrl = Url.Action("Index", "Home", null, Request.Scheme),
            // We can pass metadata to identify the purchase later in the webhook
            Metadata = new Dictionary<string, string>
            {
                { "TicketTypeId", ticketTypeId.ToString() },
                { "UserId", User.Identity.Name } // Or user ID
            }
        };

        var service = new SessionService();
        Session session = service.Create(options);

        return Json(new { id = session.Id });
    }
}