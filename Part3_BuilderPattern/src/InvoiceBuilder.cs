namespace Part3_BuilderPattern;

public class InvoiceBuilder
{
    private int _invoiceId;

    private string? _customerName;
    private string? _customerEmail;
    private string? _customerPhone;

    private string? _billingStreet;
    private string? _billingCity;
    private string? _billingState;
    private string? _billingZipCode;
    private string? _billingCountry;

    private string? _shippingStreet;
    private string? _shippingCity;
    private string? _shippingState;
    private string? _shippingZipCode;
    private string? _shippingCountry;

    private DateTime _orderDate;
    private string? _paymentMethod;
    private string? _currency;

    private decimal _subTotal;
    private decimal? _discountAmount;
    private decimal? _taxAmount;
    private decimal? _totalAmount;

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

    public InvoiceBuilder SetBillingAddress(
        string street,
        string city,
        string state,
        string zipCode,
        string country)
    {
        _billingStreet = street;
        _billingCity = city;
        _billingState = state;
        _billingZipCode = zipCode;
        _billingCountry = country;

        return this;
    }

    public InvoiceBuilder SetShippingAddress(
        string street,
        string city,
        string state,
        string zipCode,
        string country)
    {
        _shippingStreet = street;
        _shippingCity = city;
        _shippingState = state;
        _shippingZipCode = zipCode;
        _shippingCountry = country;

        return this;
    }

    public InvoiceBuilder SetOrderDate(DateTime orderDate)
    {
        _orderDate = orderDate;
        return this;
    }

    public InvoiceBuilder SetPaymentMethod(string paymentMethod)
    {
        _paymentMethod = paymentMethod;
        return this;
    }

    public InvoiceBuilder SetCurrency(string currency)
    {
        _currency = currency;
        return this;
    }

    public InvoiceBuilder SetSubTotal(decimal subTotal)
    {
        _subTotal = subTotal;
        return this;
    }

    public InvoiceBuilder SetDiscountAmount(decimal discountAmount)
    {
        _discountAmount = discountAmount;
        return this;
    }

    public InvoiceBuilder SetTaxAmount(decimal taxAmount)
    {
        _taxAmount = taxAmount;
        return this;
    }

    public InvoiceBuilder SetTotalAmount(decimal totalAmount)
    {
        _totalAmount = totalAmount;
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

        if (string.IsNullOrWhiteSpace(_paymentMethod))
            throw new InvalidOperationException(
                "Payment method is required.");

        if (string.IsNullOrWhiteSpace(_currency))
            throw new InvalidOperationException(
                "Currency is required.");

        return new Invoice(
            _invoiceId,
            _customerName,
            _customerEmail,
            _customerPhone,

            _billingStreet,
            _billingCity,
            _billingState,
            _billingZipCode,
            _billingCountry,

            _shippingStreet,
            _shippingCity,
            _shippingState,
            _shippingZipCode,
            _shippingCountry,

            _orderDate,
            _paymentMethod,
            _currency,

            _subTotal,
            _discountAmount,
            _taxAmount,
            _totalAmount);
    }
}