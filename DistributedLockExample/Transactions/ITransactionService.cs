namespace DistributedLockExample.Transactions;

public interface ITransactionService
{
    Task CreateTransaction(TransactionCommand transaction);
}