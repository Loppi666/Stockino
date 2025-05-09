namespace Stockino3.Services;

public class TransactionEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public OperationType OperationType { get; set; } // OPEN or CLOSE
    public double Volume { get; set; }
    public DateTime ExecutionTime { get; set; } // Unified execution time for all operations
    public double Price { get; set; } // Single price for transaction

    public string Currency { get; set; }
    public double? Margin { get; set; }
    public double? Commission { get; set; }
    public double? Swap { get; set; }
    public double? GrossPL { get; set; }
}
