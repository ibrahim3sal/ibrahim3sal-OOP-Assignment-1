namespace Part1_ProceduralToOOP;

class Program
{
    static void Main(string[] args)
    {
        OrderSystem system = new OrderSystem();
        system.AddCustomer(1, "Mona Ali", "mona@example.com", "Cairo", true);

        system.AddCustomer(2, "Omar Hassan", "omar@example.com", "Alexandria", false);

        system.AddCustomer(3, "Sara Nabil", "sara@example.com", "Giza", false);

        system.AddProduct(101, "USB Cable", 50.0, 100);

        system.AddProduct(102, "Wireless Mouse", 250.0, 40);

        system.AddProduct(103, "Mechanical Keyboard", 1200.0, 15);

        system.AddProduct(104, "Laptop Stand", 400.0, 25);

        Order? order1 = system.CreateOrder(1001, 1, "2026-09-15");

        order1?.AddLine(system.GetProduct(101)!, 2);

        order1?.AddLine(system.GetProduct(102)!, 1);

        order1?.AddLine(system.GetProduct(103)!, 1);

        order1?.MarkAsPaid();

        Order? order2 = system.CreateOrder(1002, 2, "2026-09-15");

        order2?.AddLine(system.GetProduct(103)!, 1);

        order2?.AddLine(system.GetProduct(104)!, 1);

        Order? order3 = system.CreateOrder(1003, 3, "2026-09-16");

        order3?.AddLine(system.GetProduct(101)!, 5);

        order3?.MarkAsPaid();

        system.PrintCustomers();

        system.PrintProducts();

        system.PrintAllOrders();

        Console.WriteLine($"\nPaid sales total after demo: {system.TotalSalesPaidOnly():F2}");

        RunInteractiveMenu(system);
    }

    static void PrintMenu()
    {
        Console.WriteLine("\n---------- MENU ----------");
        Console.WriteLine("1) Print customers");
        Console.WriteLine("2) Print products");
        Console.WriteLine("3) Print all orders");
        Console.WriteLine("4) Print one order by id");
        Console.WriteLine("5) Create order");
        Console.WriteLine("6) Add line to order");
        Console.WriteLine("7) Mark order paid");
        Console.WriteLine("8) Show paid sales total");
        Console.WriteLine("0) Exit");
        Console.Write("Choice: ");
    }

    static void RunInteractiveMenu(OrderSystem system)
    {
        int choice = -1;

        while (choice != 0)
        {
            PrintMenu();

            choice = int.Parse(Console.ReadLine()!);

            if (choice == 1)
            {
                system.PrintCustomers();
            }
            else if (choice == 2)
            {
                system.PrintProducts();
            }
            else if (choice == 3)
            {
                system.PrintAllOrders();
            }
            else if (choice == 4)
            {
                Console.Write("Order id: ");
                int orderId = int.Parse(Console.ReadLine()!);

                system.PrintOrder(orderId);
            }
            else if (choice == 5)
            {
                Console.Write("Order id: ");
                int orderId = int.Parse(Console.ReadLine()!);

                Console.Write("Customer id: ");
                int customerId = int.Parse(Console.ReadLine()!);

                Console.Write("Date (YYYY-MM-DD): ");
                string date = Console.ReadLine()!;

                system.CreateOrder(
                    orderId,
                    customerId,
                    date);
            }
            else if (choice == 6)
            {
                Console.Write("Order id: ");
                int orderId = int.Parse(Console.ReadLine()!);

                Console.Write("Product id: ");
                int productId = int.Parse(Console.ReadLine()!);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine()!);

                Order? order = system.GetOrder(orderId);

                if (order == null)
                {
                    Console.WriteLine(
                        $"ERROR: order id {orderId} not found.");
                    continue;
                }

                Product? product = system.GetProduct(productId);

                if (product == null)
                {
                    Console.WriteLine(
                        $"ERROR: product id {productId} not found.");
                    continue;
                }

                order.AddLine(product, quantity);
            }
            else if (choice == 7)
            {
                Console.Write("Order id: ");
                int orderId = int.Parse(Console.ReadLine()!);

                Order? order = system.GetOrder(orderId);

                if (order == null)
                {
                    Console.WriteLine(
                        $"ERROR: order id {orderId} not found.");
                    continue;
                }

                order.MarkAsPaid();
            }
            else if (choice == 8)
            {
                Console.WriteLine(
                    $"Paid sales total: {system.TotalSalesPaidOnly():F2}");
            }
            else if (choice == 0)
            {
                Console.WriteLine("See you later!");
            }
            else
            {
                Console.WriteLine("Unknown choice.");
            }
        }
    }
}