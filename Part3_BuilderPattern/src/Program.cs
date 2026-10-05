using Part3_BuilderPattern;

var invoice = new InvoiceBuilder()
    .SetInvoiceId(1)
    .SetCustomerName("Ibrahim")
    .SetCustomerEmail("ibrahim@gmail.com")
    .SetCustomerPhone("01000000000")

    .SetBillingAddress(
        "Street 1",
        "Zagazig",
        "Sharqia",
        "44511",
        "Egypt")

    .SetShippingAddress(
        "Street 2",
        "Cairo",
        "Cairo",
        "11511",
        "Egypt")

    .SetOrderDate(DateTime.Now)
    .SetPaymentMethod("Credit Card")
    .SetCurrency("EGP")
    .SetSubTotal(1000)
    .SetDiscountAmount(100)
    .SetTaxAmount(50)
    .SetTotalAmount(950)

    .Build();

Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
Console.WriteLine($"Customer: {invoice.CustomerName}");
Console.WriteLine($"Email: {invoice.CustomerEmail}");

Console.WriteLine(
    $"Billing City: {invoice.BillingCity}");

Console.WriteLine(
    $"Shipping City: {invoice.ShippingCity}");

Console.WriteLine(
    $"Payment: {invoice.PaymentMethod}");

Console.WriteLine(
    $"Total: {invoice.TotalAmount}");