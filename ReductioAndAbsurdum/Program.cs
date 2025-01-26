// See https://aka.ms/new-console-template for more information

// ===================================== DATA SOURCE =====================================

using ReductioAndAbsurdum;

List<MagicProduct> magicProducts = new List<MagicProduct>()
{
    new MagicProduct(1, "Magic Wand", "tool", 250.00M, true, new DateTime(2025, 1, 25), 23),
    new MagicProduct(2, "Spell Book", "tool", 19.99M, true, new DateTime(2025, 1, 25), 23),
    new MagicProduct(3, "Crystal ball", "tool", 100.00M, true, new DateTime(2024, 9, 29), 119),
    new MagicProduct(4, "Force Field", "tool", 750.00M, true, new DateTime(2024, 9, 29), 119),
    new MagicProduct(5, "Shape-shifting outfit", "tool", 10_000.00M, true, new DateTime(2024, 9, 20), 110),
    new MagicProduct(6, "Invisible Cloak", "tool", 1_500.00M, true, new DateTime(2024, 9, 20), 110),
    new MagicProduct(7, "Reverso - reverses time by a maximum of 5 seconds, once per Earth year.", "spells", 100.00M, true, new DateTime(2024, 9, 20), 110),
    new MagicProduct(8, "Extendu-kno - Increases learning and memorization x5 for one hour each month.", "spells", 299.99M, true, new DateTime(2024, 9, 20), 110),
    new MagicProduct(9, "Anti Peppibism - Gives your victims immense heartburn, indigestion, and diarrhea. ", "spells", 59.00M, true, new DateTime(2024, 9, 20), 110),
    new MagicProduct(10, "Earth Roach", "food", 0.99M, true, new DateTime(2024, 8, 30), 90),
    new MagicProduct(11, "Plant-based soup with herbs and spices from planet Zoriah.", "food", 50.00M, true, new DateTime(2024, 8, 30), 90),
    new MagicProduct(12, "Rare BBQ Gooper thighs from planet Mars. (preserved since the Martian War of 2799).", "food", 1250.00M, true, new DateTime(2024, 8, 30), 90),
};

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
        Console.WriteLine("e: Filter products by type.");
        Console.WriteLine("f: <Feature coming soon>");
        Console.WriteLine("g: <Feature coming soon>");
        Console.WriteLine("q: Exit the program.");
        Console.WriteLine();
        string? response = Console.ReadLine()?.Trim();

        // PROCESS MENU RESPONSE
        switch (response?.ToLower().Trim())
        {
            case "a":
                Console.Clear();
                Console.WriteLine("Now viewing all products:");
                DisplayProducts();
                continue;
            case "b":
                Console.Clear();
                CreateProduct();
                continue;
            case "c":
                Console.Clear();
                Console.WriteLine("Update the information: ");
                UpdateProduct();
                continue;
            case "d":
                Console.Clear();
                Console.WriteLine("Which item would you like to remove?");
                DeleteProduct();
                continue;
            case "e":
                Console.Clear();
                FilterProductList();
                continue;
            case "f":
                Console.Clear();
                Console.WriteLine("Stay tuned for this feature!");
                continue;
            case "g":
                Console.Clear();
                Console.WriteLine("We know you are excited. New features are coming soon!");
                continue;
            case "q":
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
        
        Console.Write("Product name: ");
        string? productName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(productName))
        {
            Console.WriteLine("Please enter a valid product name.");
            continue;
        }
        
        Console.Write("Product type: ");
        string? productType = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(productType))
        {
            Console.WriteLine("Please enter something about the product type.");
            continue;
        }
        
        Console.Write("How much should this item cost? Enter a dollar value. Ex. 29.99: ");
        if (!decimal.TryParse(Console.ReadLine(), out var productPrice))
        {
            Console.WriteLine("Please enter a valid product type.");
            continue;
        }
        
        // Process information.
        Console.WriteLine("Test variables: ");
        Console.WriteLine($"{(nameof(productName))}: {productName}");
        Console.WriteLine($"{(nameof(productType))}: {productType}");
        Console.WriteLine($"{(nameof(productPrice))}: {productPrice}");
        
        // Payload
        MagicProduct payload =
            new MagicProduct((magicProducts.Count + 1), productName, productType, productPrice, true, new DateTime().Date, 0);

        // Create a new record.
        magicProducts.Add(payload);
        
        // Confirmation.
        Console.WriteLine($"{payload.ProductName} was successfully added to the inventory.");
        break;
    }
};

void DisplayProducts()
{
    foreach (MagicProduct product in magicProducts)
    {
        Console.WriteLine($"\t{product.ProductName} {(product.InStock ? $"---- IN STOCK. Price is {product.Price}" : 
            "---- SOLD OUT")}. Type --{product.ProductTypeId}");
        Console.WriteLine($"\t\tThis product was listed on {product.DateStocked} and has been " +
                          $"in stock for {product.DaysOnShelf} days.");
    }
    // List<MagicProduct> productsInStock = magicProducts.Where(mp => mp.InStock).ToList();
    // foreach (MagicProduct product in magicProducts)
    //     Console.WriteLine($"\n{product.ProductName}");
}

void UpdateProduct()
{
    while (true)
    {
        // Loop through product list.
        Console.WriteLine("Please enter number that corresponds to the product you are wanting to update: ");
        int counter = 0;
        foreach (MagicProduct product in magicProducts)
        {
            Console.WriteLine($"\t{++counter} -- {product.ProductName}");
        }

        // Prompt user to enter a number that corresponds to the product they want to update.
        string? response = Console.ReadLine()?.Trim();
        
        if (!int.TryParse(response, out counter) && counter < 1)
        {
            Console.WriteLine("Invalid entry. Please pick the number that corresponds to the product.");
            continue;
        }
        
        // Log the existing data to the console.
        Console.Write($"Product name: {magicProducts[--counter].ProductName}\n");
        
        // Ask user which field they want to update, then prompt user to enter new info for that field.
        Console.WriteLine("Which field would you like to change? ");
        Console.WriteLine("1 - Product Name");
        Console.WriteLine("2 - Product Type");
        Console.WriteLine("3 - Price");
        string? fieldToUpdate = Console.ReadLine();

        if (!int.TryParse(fieldToUpdate, out int changeInfo))
        {
            Console.WriteLine("Invalid entry. Please pick the number that corresponds to what you are trying to update.");
            continue;
        }
        
        switch (fieldToUpdate)
        {
            case "1":
                Console.WriteLine($"Enter a new product name: ");
                string? newProductName = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(newProductName))
                {
                    Console.WriteLine("Please enter a valid product name.");
                    continue;
                }
                // Update record's product name.
                magicProducts[counter].ProductName = newProductName;
                break;
            case "2":
                Console.WriteLine($"Enter a new product type - tool/spells/weapon/food: ");
                string? newProductType = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(newProductType))
                {
                    Console.WriteLine("Please enter a valid product type. Enter tool/spells/weapon/food:");
                    continue;
                }

                if (!newProductType.Equals("tool") && !newProductType.Equals("spells") && 
                    !newProductType.Equals("weapon") && !newProductType.Equals("food"))
                {
                    Console.WriteLine("Please enter a valid product type - tool / spells / weapon / food");
                    Console.WriteLine($"{nameof(newProductType)}: {newProductType}");
                    break;
                }
                // Update record's product type.
                Console.WriteLine($"{nameof(newProductType)}: {newProductType}");
                magicProducts[counter].ProductTypeId = newProductType;
                break;
            case "3":
                Console.WriteLine($"Enter a new product price: ");
                string? newPrice = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(newPrice) || !decimal.TryParse(newPrice, out _))
                {
                    Console.WriteLine("Please enter a valid product price. Must be a decimal number. Ex. 19.99");
                    continue;
                }
                // Update record's price.
                magicProducts[counter].Price = Convert.ToDecimal(newPrice);
                break;
        }
        
        break;
    }
}

void DeleteProduct()
{
    while (true)
    {
        try
        {
            Console.WriteLine("Please enter the number that corresponds to the product you are trying to remove: ");
            int counter = 0;
            foreach (MagicProduct product in magicProducts)
            {
                Console.WriteLine($"{++counter}. {product.ProductName}");
            }
            int response = Convert.ToInt32(Console.ReadLine());

            if (response < 1 || response > magicProducts.Count)
            {
                Console.WriteLine("Invalid entry. Please try again.");
                continue;
            }
            // If selection is valid, remove it from the list.
            MagicProduct chosenProduct = magicProducts[response - 1];
            magicProducts.Remove(chosenProduct);
            Console.WriteLine("Removed the product. Here is the updated list:");
            DisplayProducts();
            break; //
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid selection. Please pick a number from the list. ");
        }
    }
    MagicMenu();
}

void FilterProductList()
{
    while (true)
    {
        Console.WriteLine("Filter product list by product type - spells / weapon / food / tool ");
        string? response = Console.ReadLine()?.Trim().ToLower();
        if (!response.Equals("tool") && !response.Equals("spells") && 
            !response.Equals("weapon") && !response.Equals("food"))
        {
            Console.WriteLine("Please enter a valid product type - tool / spells / weapon / food");
            Console.WriteLine($"{nameof(response)}: {response}");
            break;
        }
        
        List<MagicProduct> filteredProducts = new List<MagicProduct>();
        foreach (MagicProduct product in magicProducts)
        {
            if (product.ProductTypeId == response)
            {
                filteredProducts.Add(product);
            }
        }
        Console.WriteLine("Filtered products: ");
        foreach (MagicProduct productObj in filteredProducts)
        {
            Console.WriteLine($"\t {productObj.ProductName} {(productObj.InStock ? $"is available for $" +
                $"{productObj.Price}." : "out of stock.")}");
        }
        break;
    }
}

// ==================== STARTUP GREETING AND PROMPT USER TO MAKE A SELECTION IN THE MENU. ====================

string greeting = "Welcome to Reductio & Absurdum Shop! This is the hot spot for high-quality magic supplies.";
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("============================================================================================");
Console.WriteLine(greeting);
MagicMenu();