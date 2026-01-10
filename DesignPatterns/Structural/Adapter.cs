namespace DesignPatterns.Structural.Adapter
{
    /// <summary>
    /// Target interface that the client expects
    /// </summary>
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount, string accountInfo);
        string GetTransactionId();
    }

    /// <summary>
    /// Adaptee - existing class with incompatible interface (Third-party library)
    /// </summary>
    public class StripePaymentGateway
    {
        // Different method signature than IPaymentProcessor
        public string ChargeCustomer(double amountInCents, string customerId)
        {
            Console.WriteLine($"Stripe: Charging ${amountInCents / 100} to customer {customerId}");
            return $"stripe_tx_{Guid.NewGuid().ToString().Substring(0, 8)}";
        }

        public string GetLastTransaction()
        {
            return "stripe_tx_12345678";
        }
    }

    /// <summary>
    /// Another Adaptee - PayPal with different interface
    /// </summary>
    public class PayPalService
    {
        public bool MakePayment(decimal dollars, string email)
        {
            Console.WriteLine($"PayPal: Processing ${dollars} for {email}");
            return true;
        }

        public string RetrieveTransactionReference()
        {
            return $"paypal_ref_{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }

    /// <summary>
    /// Adapter - makes StripePaymentGateway compatible with IPaymentProcessor
    /// </summary>
    public class StripePaymentAdapter : IPaymentProcessor
    {
        private readonly StripePaymentGateway _stripeGateway;
        private string _lastTransactionId;

        public StripePaymentAdapter(StripePaymentGateway stripeGateway)
        {
            _stripeGateway = stripeGateway;
        }

        public bool ProcessPayment(decimal amount, string accountInfo)
        {
            try
            {
                // Adapt the interface: convert decimal to cents (double)
                double amountInCents = (double)(amount * 100);
                _lastTransactionId = _stripeGateway.ChargeCustomer(amountInCents, accountInfo);
                return !string.IsNullOrEmpty(_lastTransactionId);
            }
            catch
            {
                return false;
            }
        }

        public string GetTransactionId()
        {
            return _lastTransactionId ?? _stripeGateway.GetLastTransaction();
        }
    }

    /// <summary>
    /// Adapter - makes PayPalService compatible with IPaymentProcessor
    /// </summary>
    public class PayPalPaymentAdapter : IPaymentProcessor
    {
        private readonly PayPalService _payPalService;

        public PayPalPaymentAdapter(PayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        public bool ProcessPayment(decimal amount, string accountInfo)
        {
            // Adapt the interface
            return _payPalService.MakePayment(amount, accountInfo);
        }

        public string GetTransactionId()
        {
            return _payPalService.RetrieveTransactionReference();
        }
    }

    /// <summary>
    /// Client code that works with IPaymentProcessor interface
    /// </summary>
    public class CheckoutService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public CheckoutService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void ProcessCheckout(decimal amount, string accountInfo)
        {
            Console.WriteLine($"Checkout: Processing payment of ${amount}");
            
            bool success = _paymentProcessor.ProcessPayment(amount, accountInfo);
            
            if (success)
            {
                string transactionId = _paymentProcessor.GetTransactionId();
                Console.WriteLine($"Payment successful! Transaction ID: {transactionId}");
            }
            else
            {
                Console.WriteLine("Payment failed!");
            }
        }
    }

    /// <summary>
    /// Example usage of Adapter Pattern
    /// </summary>
    public class AdapterPatternExample
    {
        public static void RunExample()
        {
            Console.WriteLine("=== Adapter Pattern Example ===\n");

            decimal amount = 99.99m;

            // Using Stripe through adapter
            Console.WriteLine("1. Using Stripe Payment Gateway:");
            var stripeGateway = new StripePaymentGateway();
            var stripeAdapter = new StripePaymentAdapter(stripeGateway);
            var checkoutWithStripe = new CheckoutService(stripeAdapter);
            checkoutWithStripe.ProcessCheckout(amount, "cus_12345");

            // Using PayPal through adapter
            Console.WriteLine("\n2. Using PayPal Service:");
            var payPalService = new PayPalService();
            var payPalAdapter = new PayPalPaymentAdapter(payPalService);
            var checkoutWithPayPal = new CheckoutService(payPalAdapter);
            checkoutWithPayPal.ProcessCheckout(amount, "user@example.com");

            // Benefits:
            // 1. CheckoutService doesn't know about Stripe or PayPal specifics
            // 2. Can switch payment providers without changing client code
            // 3. Can integrate third-party libraries with incompatible interfaces
            // 4. Follows Dependency Inversion Principle
        }
    }
}
