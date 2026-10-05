1. Why is a single 20-parameter constructor a problem?

A 20-parameter constructor is difficult to read and maintain because the caller has to provide many values in a specific order.

This makes the call site hard to understand and increases the risk of passing values in the wrong order, especially when multiple parameters have the same type, such as string or decimal.


2. Is this only a long-constructor problem?

No. The problem is deeper than just having a long constructor.

The Invoice contains several groups of loosely related data, such as billing address, shipping address, and order/payment information.

For example, the five billing address fields represent one logical concept: an address. The same applies to the shipping address.

These concepts can be represented by separate objects and composed into the Invoice.


Why Is the Composed Builder Better?

The composed builder version is better because each builder has a clear and focused responsibility.

The AddressBuilder is responsible only for constructing and validating an Address.

The OrderBuilder is responsible only for constructing the order and payment information.

The InvoiceBuilder then composes these already-built objects into the final Invoice.

Independent Validation

This design allows independent validation.

For example, AddressBuilder can verify that an address contains all required information without the InvoiceBuilder knowing the details of address validation.

Similarly, OrderBuilder can validate the required order and payment information independently.

Reuse

The same AddressBuilder can be reused for both the billing address and the shipping address.

We do not need separate builders such as BillingAddressBuilder and ShippingAddressBuilder, because both represent the same concept: an Address.

Readability

The call site is easier to understand because each part of the Invoice is built according to its own concept.

Instead of one large builder containing all address, order, and payment details, the construction is divided into smaller and more focused steps.