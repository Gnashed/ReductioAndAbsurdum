namespace ReductioAndAbsurdum;

public class MagicProduct
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }
    public string ProductTypeId { get; set; }
    
    // Constructor
    public MagicProduct
    (
        int productId,
        string productName,
        string productTypeId,
        decimal price,
        bool inStock
    )
    {
        // Validate before constructing objects.
        if (string.IsNullOrWhiteSpace(productName)) throw new ArgumentNullException(nameof(productName));
        if (string.IsNullOrWhiteSpace(productTypeId)) throw new ArgumentNullException(nameof(productTypeId));
        ArgumentOutOfRangeException.ThrowIfNegative(price);
        
        ProductName = productName;
        ProductTypeId = productTypeId;
        Price = price;
        InStock = inStock;
        ProductId = productId;
    }
}