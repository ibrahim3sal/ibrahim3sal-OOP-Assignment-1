namespace Part1_ProceduralToOOP;

public class OrderSystem
{
    private readonly List<Customer> customers = new();
    private readonly List<Product> products = new();
    private readonly List<Order> orders = new();

    public void AddCustomer(int id, string name, string email, string city, bool isVip)
    {
        if (customers.Any(c => c.Id == id))
        {
            Console.WriteLine($"ERROR: customer id {id} already exists.");
            return;
        }

        customers.Add(
            new Customer(id, name, email, city, isVip));
    }

    public void AddProduct(int id, string name, double price, int stock)
    {
        if (products.Any(p => p.Id == id))
        {
            Console.WriteLine($"ERROR: product id {id} already exists.");
            return;
        }

        products.Add(
            new Product(id, name, price, stock));
    }

    public Order? CreateOrder(int orderId, int customerId, string date)
    {
        if (orders.Any(o => o.Id == orderId))
        {
            Console.WriteLine($"ERROR: order id {orderId} already exists.");
            return null;
        }

        Customer? customer = customers.FirstOrDefault(
            c => c.Id == customerId);

        if (customer == null)
        {
            Console.WriteLine(
                $"ERROR: customer id {customerId} not found.");
            return null;
        }

        Order order = new Order(orderId, customer, date);

        orders.Add(order);

        return order;
    }

    public void PrintCustomers()
    {
        Console.WriteLine(
            $"\n=== CUSTOMERS ({customers.Count}) ===");

        foreach (Customer customer in customers)
        {
            Console.WriteLine(
                $"#{customer.Id}  " +
                $"{customer.Name}  " +
                $"<{customer.Email}>  " +
                $"{customer.City}  " +
                $"vip={(customer.IsVip ? "yes" : "no")}");
        }
    }

    public void PrintProducts()
    {
        Console.WriteLine(
            $"\n=== PRODUCTS ({products.Count}) ===");

        foreach (Product product in products)
        {
            Console.WriteLine(
                $"#{product.Id}  " +
                $"{product.Name}  " +
                $"price={product.Price:F2}  " +
                $"stock={product.Stock}");
        }
    }

    public void PrintOrder(int orderId)
    {
        Order? order = orders.FirstOrDefault(
            o => o.Id == orderId);

        if (order == null)
        {
            Console.WriteLine(
                $"ERROR: order id {orderId} not found.");
            return;
        }

        Console.WriteLine(
            $"\n=== ORDER #{order.Id} ===");

        Console.WriteLine($"Date: {order.Date}");

        Console.WriteLine(
            $"Customer: {order.Customer.Name} " +
            $"(#{order.Customer.Id})");

        Console.WriteLine(
            $"Paid: {(order.IsPaid ? "yes" : "no")}");

        Console.WriteLine("Lines:");

        foreach (OrderLine line in order.OrderLines)
        {
            double lineTotal =
                line.Product.Price * line.Quantity;

            Console.WriteLine(
                $"  - {line.Product.Name}  " +
                $"x{line.Quantity}  " +
                $"@{line.Product.Price:F2}  " +
                $"= {lineTotal:F2}");
        }

        Console.WriteLine(
            $"TOTAL: {order.CalculateTotal():F2}");
    }

    public void PrintAllOrders()
    {
        Console.WriteLine(
            $"\n=== ALL ORDERS ({orders.Count}) ===");

        foreach (Order order in orders)
        {
            PrintOrder(order.Id);
        }
    }

    public double TotalSalesPaidOnly()
    {
        double sum = 0.0;

        foreach (Order order in orders)
        {
            if (order.IsPaid)
            {
                sum += order.CalculateTotal();
            }
        }

        return sum;
    }

    public Product? GetProduct(int productId)
    {
        return products.FirstOrDefault(p => p.Id == productId);
    }

    public Order? GetOrder(int orderId)
    {
        return orders.FirstOrDefault(o => o.Id == orderId);
    }
}