using System;

class MovieTicketApp
{
    static void Main()
    {
        string userName = "";
        int age = 0;
        int ticketChoice = 0;
        double price = 0;
        double finalPrice = 0;
        string ticketType = "";
        string discountCode = "";
        bool discountApplied = false;

        // Ask for user's name
        while (true)
        {
            Console.Write("Enter your name: ");
            userName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(userName))
                break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        // Ask for user's age
        while (true)
        {
            Console.Write("Enter your age: ");
            if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                break;
            Console.WriteLine("Invalid age. Please enter a positive number.");
        }

        // Ticket selection with validation
        while (true)
        {
            Console.WriteLine("\nSelect Ticket Type:");
            Console.WriteLine("1: Child Ticket (€5) - under 12 years");
            Console.WriteLine("2: Adult Ticket (€10) - 12 to 64 years");
            Console.WriteLine("3: Senior Ticket (€7) - 65+ years");

            Console.Write("Enter choice (1-3): ");
            if (int.TryParse(Console.ReadLine(), out ticketChoice))
            {
                if (ticketChoice == 1 && age < 12)
                {
                    price = 5;
                    ticketType = "Child Ticket";
                    break;
                }
                else if (ticketChoice == 2 && age >= 12 && age <= 64)
                {
                    price = 10;
                    ticketType = "Adult Ticket";
                    break;
                }
                else if (ticketChoice == 3 && age >= 65)
                {
                    price = 7;
                    ticketType = "Senior Ticket";
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection for your age group. Please try again.\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
            }
        }

        // Discount Code
        finalPrice = price;
        while (true)
        {
            Console.Write("\nDo you have a discount code? (yes/no): ");
            string hasCode = Console.ReadLine().ToLower();

            if (hasCode == "yes")
            {
                Console.Write("Enter discount code: ");
                discountCode = Console.ReadLine();

                if (discountCode == "SALE20")
                {
                    finalPrice = price * 0.8; // Apply 20% discount
                    discountApplied = true;
                    Console.WriteLine("Discount applied successfully!");
                    break;
                }
                else
                {
                    Console.Write("Invalid code. Do you want to try again? (yes/no): ");
                    string tryAgain = Console.ReadLine().ToLower();
                    if (tryAgain != "yes")
                        break;
                }
            }
            else if (hasCode == "no")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please answer with 'yes' or 'no'.");
            }
        }

        // Summary
        Console.WriteLine("\n--- Ticket Summary ---");
        Console.WriteLine($"Name: {userName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Ticket Type: {ticketType}");
        Console.WriteLine($"Original Price: €{price}");
        if (discountApplied)
        {
            Console.WriteLine($"Discount Applied: 20% (Code: {discountCode})");
        }
        else
        {
            Console.WriteLine("No Discount Applied");
        }
        Console.WriteLine($"Final Price: €{finalPrice}");
        Console.WriteLine("\nThank you for your purchase!");
    }
}

