namespace DistributedLockExample.Transactions;

public record TransactionCommand(string FromAccount, string ToAccount, decimal Amount)
{
    public Guid Id => Guid.NewGuid();
}