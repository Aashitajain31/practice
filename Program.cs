using System;
using System.Collections.Generic;

class OnlineShoppingPortal
{
    // List to store purchased products and their quantities
    static List<(string Product, int Quantity)> purchasedItems = new List<(string Product, int Quantity)>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Online Shopping Portal!");

        // Credentials for login
        string defaultUsername = "Customer";
        string defaultPassword = "ShopEasy123";

        // Prompt user for username
        Console.Write("Please enter your username: ");
        string enteredUsername = Console.ReadLine();

        // Prompt user for password
        Console.Write("Please enter your password: ");
        string enteredPassword = Console.ReadLine();

        // Validate login credentials
        if (enteredUsername == defaultUsername && enteredPassword == defaultPassword)
        {
            Console.WriteLine("Login successful! Please proceed.");
            // Navigate to product selection screen
            DisplayProducts();
        }
        else
        {
            Console.WriteLine("Incorrect credentials. Please try again.");
        }
    }

    // Product selection screen
    static void DisplayProducts()
    {
        Console.WriteLine("Available products:");
        Console.WriteLine("1. Apple");
        Console.WriteLine("2. Banana");
        Console.WriteLine("3. Mango");
        Console.WriteLine("4. Guava");

        Console.Write("Enter the number of the product you wish to purchase: ");
        
        if (int.TryParse(Console.ReadLine(), out int selectedProduct) && selectedProduct >= 1 && selectedProduct < 4)
        {
            string productName = selectedProduct switch
            {
                1 => "Apple",
                2 => "Banana",
                3 => "Mango",
                4 => "Guava",
                _ => throw new ArgumentOutOfRangeException()
            };

            Console.WriteLine($"You selected: {productName}");

            // Navigate to quantity selection screen
            EnterQuantity(productName);
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
            DisplayProducts();
        }
    }

    // Quantity selection screen
    static void EnterQuantity(string productName)
    {
        Console.Write($"Enter the quantity for {productName}: ");
        if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
        {
            Console.WriteLine($"You have added {quantity} {product}(s) to your cart."); 

            purchasedItems.Add((productName, quantity));

            // Navigate to the menu screen
            ShowMenu();
        }
        else
        {
            Console.WriteLine("Invalid quantity. Please try again.");
            EnterQuantity(productName);
        }
    }

    // Menu screen to choose next action
    static void ShowMenu()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Proceed to checkout");
        Console.WriteLine("2. Continue shopping");

        Console.Write("Enter your choice: ");
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice == 1)
            {
                // Navigate to checkout screen
                ProceedToCheckout();
            }
            else if (choice == 2)
            {
                // Navigate back to product selection screen
                DisplayProducts();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                ShowMenu();
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            ShowMenu();
        }
    }

    // Checkout screen
    static void ProceedToCheckout()
    {
        Console.WriteLine("Proceeding to checkout. Please wait...");
        DisplayPurchasedItems();
    }

    // Display purchased items
    static void DisplayPurchasedItems()
    {
        Console.WriteLine("Your purchased items:");
        foreach (var item in purchasedItems)
        {
            Console.WriteLine($"{item.Product}: {item.Quantity}");
        }
        Console.WriteLine("Thank you for shopping with us! Have a great day!");
    }
}
