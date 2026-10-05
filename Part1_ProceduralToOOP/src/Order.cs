namespace Part1_ProceduralToOOP;

public class Order
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public string Date { get; set; }
    public bool IsPaid { get; set; }

    public List<OrderLine> OrderLines { get; set; }

    public Order(int id, Customer customer, string date)
    {
        Id = id;
        Customer = customer;
        Date = date;
        IsPaid = false;
        OrderLines = new List<OrderLine>();
    }

    public void AddLine(Product product, int quantity)
    {
        if (IsPaid)
        {
            Console.WriteLine("ERROR: cannot change a paid order.");
            return;
        }

        if (OrderLines.Count >= 20)
        {
            Console.WriteLine("ERROR: order has too many lines.");
            return;
        }

        if (quantity <= 0)
        {
            Console.WriteLine("ERROR: quantity must be positive.");
            return;
        }

        if (product.Stock < quantity)
        {
            Console.WriteLine(
                $"ERROR: not enough stock for product #{product.Id}.");
            return;
        }

        product.Stock -= quantity;

        OrderLines.Add(new OrderLine(product, quantity));
    }

    public double CalculateTotal()
    {
        double total = 0.0;

        foreach (OrderLine line in OrderLines)
        {
            total += line.Product.Price * line.Quantity;
        }

        if (Customer.IsVip)
        {
            total = total * 0.90;
        }

        return total;
    }

    public void MarkAsPaid()
    {
        if (OrderLines.Count == 0)
        {
            Console.WriteLine("ERROR: cannot pay an empty order.");
            return;
        }

        IsPaid = true;
    }
}