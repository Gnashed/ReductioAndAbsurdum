// See https://aka.ms/new-console-template for more information

// ===================================== MENU =====================================

void MagicMenu()
{
    while (true)
    {
        Console.WriteLine("============================================================================================");
        Console.WriteLine();
        Console.WriteLine("Please choose one of the following options: ");
        Console.WriteLine("a: View our entire collection of magic products.");
        Console.WriteLine("b: Add a product to the inventory.");
        Console.WriteLine("c: Update the information of a product in the inventory.");
        Console.WriteLine("d: Remove a product from inventory.");
        Console.WriteLine("e: <Feature coming soon>");
        Console.WriteLine("f: <Feature coming soon>");
        Console.WriteLine("g: <Feature coming soon>");
        Console.WriteLine("exit: Exit the program.");
        Console.WriteLine();
        string? response = Console.ReadLine()?.Trim();

        // PROCESS MENU RESPONSE
        switch (response?.ToLower().Trim())
        {
            case "a":
                Console.Clear();
                Console.WriteLine("Now viewing all products:");
                continue;
            case "b":
                Console.Clear();
                Console.WriteLine("Please provide the details about the product:");
                continue;
            case "c":
                Console.Clear();
                Console.WriteLine("Update the information: ");
                continue;
            case "d":
                Console.Clear();
                Console.WriteLine("Which item would you like to remove?");
                continue;
            case "e":
                Console.Clear();
                Console.WriteLine("This feature is coming soon.");
                continue;
            case "f":
                Console.Clear();
                Console.WriteLine("Stay tuned for this feature!");
                continue;
            case "g":
                Console.Clear();
                Console.WriteLine("We know you are excited. New features are coming soon!");
                continue;
            case "exit":
                Console.WriteLine("Terminating program...");
                break;
            default:
                Console.WriteLine("Invalid response. Please try again. ");
                Console.WriteLine();
                // Console.Clear();
                continue;
        }
        break;
    }
}

// ===================================== CRUD METHODS FOR MAGIC MENU =====================================

void CreateProduct()
{
    while (true)
    {
        Console.WriteLine("Please enter the following information about the product:");
        
        Console.Write("Product name");
        string productName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(productName))
        {
            Console.WriteLine("Please enter a valid product name.");
            continue;
        }
        
        Console.Write("Product type: ");
        string productType = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(productType))
        {
            Console.WriteLine("Please enter a valid product type.");
            continue;
        }
        
        Console.Write("How much are you wanting? Enter a dollar value. Ex. 29.99: ");
        decimal productPrice;
        if (decimal.TryParse(Console.ReadLine(), out productPrice))
        {
            Console.WriteLine("Please enter a valid product type.");
            continue;
        }
        
        // Process information.
        
        
        // Create a new record.
    }
};

// ==================== STARTUP GREETING AND PROMPT USER TO MAKE A SELECTION IN THE MENU. ====================

string greeting = "Welcome to Reductio & Absurdum Shop! This is the hot spot for high-quality magic supplies.";
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("============================================================================================");
Console.WriteLine(greeting);
MagicMenu();