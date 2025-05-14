namespace Stockino3.Services;

public class TransactionEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public OperationType OperationType { get; set; } // OPEN or CLOSE
    public decimal Volume { get; set; }
    public DateTime ExecutionTime { get; set; } // Unified execution time for all operations
    public decimal UnitPrice { get; set; } // Single price for transaction
    public decimal TotalPrice { get; set; } // Single price for transaction

    public decimal TotalCost { get; set; }

    public string BuyInCurrency { get; set; }
    public decimal? Margin { get; set; }
    public decimal? Commission { get; set; }
    public decimal? Swap { get; set; }
    public decimal? GrossPL { get; set; }
}
