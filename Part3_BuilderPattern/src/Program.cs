using Part3_BuilderPattern;

var billingAddress = new AddressBuilder()
    .SetStreet("Street 1")
    .SetCity("Zagazig")
    .SetState("Sharqia")
    .SetZipCode("44511")
    .SetCountry("Egypt")
    .Build();

var shippingAddress = new AddressBuilder()
    .SetStreet("Street 2")
    .SetCity("Cairo")
    .SetState("Cairo")
    .SetZipCode("11511")
    .SetCountry("Egypt")
    .Build();

var orderInfo = new OrderBuilder()
    .SetOrderDate(DateTime.Now)
    .SetPaymentMethod("Credit Card")
    .SetCurrency("EGP")
    .SetSubTotal(1000)
    .SetDiscountAmount(100)
    .SetTaxAmount(50)
    .SetTotalAmount(950)
    .Build();

var invoice = new InvoiceBuilder()
    .SetInvoiceId(1)
    .SetCustomerName("Ibrahim")
    .SetCustomerEmail("ibrahim@gmail.com")
    .SetCustomerPhone("01000000000")
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrderInfo(orderInfo)
    .Build();

Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
Console.WriteLine($"Customer: {invoice.CustomerName}");
Console.WriteLine($"Email: {invoice.CustomerEmail}");
Console.WriteLine($"Billing City: {invoice.BillingAddress?.City}");
Console.WriteLine($"Shipping City: {invoice.ShippingAddress?.City}");
Console.WriteLine($"Payment: {invoice.OrderInfo.PaymentMethod}");
Console.WriteLine($"Total: {invoice.OrderInfo.TotalAmount}");