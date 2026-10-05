namespace Part3_BuilderPattern;

public class InvoiceBuilder
{
    private int _invoiceId;

    private string? _customerName;
    private string? _customerEmail;
    private string? _customerPhone;

    private Address? _billingAddress;
    private Address? _shippingAddress;

    private OrderInfo? _orderInfo;

    public InvoiceBuilder SetInvoiceId(int invoiceId)
    {
        _invoiceId = invoiceId;
        return this;
    }

    public InvoiceBuilder SetCustomerName(string customerName)
    {
        _customerName = customerName;
        return this;
    }

    public InvoiceBuilder SetCustomerEmail(string customerEmail)
    {
        _customerEmail = customerEmail;
        return this;
    }

    public InvoiceBuilder SetCustomerPhone(string customerPhone)
    {
        _customerPhone = customerPhone;
        return this;
    }

    public InvoiceBuilder SetBillingAddress(Address address)
    {
        _billingAddress = address;
        return this;
    }

    public InvoiceBuilder SetShippingAddress(Address address)
    {
        _shippingAddress = address;
        return this;
    }

    public InvoiceBuilder SetOrderInfo(OrderInfo orderInfo)
    {
        _orderInfo = orderInfo;
        return this;
    }

    public Invoice Build()
    {
        if (string.IsNullOrWhiteSpace(_customerName))
            throw new InvalidOperationException(
                "Customer name is required.");

        if (string.IsNullOrWhiteSpace(_customerEmail))
            throw new InvalidOperationException(
                "Customer email is required.");

        if (_orderInfo is null)
            throw new InvalidOperationException(
                "Order information is required.");

        return new Invoice(
            _invoiceId,
            _customerName,
            _customerEmail,
            _customerPhone,
            _billingAddress,
            _shippingAddress,
            _orderInfo);
    }
}