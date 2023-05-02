using DistributedLockExample.Transactions;

namespace DistributedLockExample.Exceptions;

public class TransactionLockException : Exception
{
    public TransactionCommand Transaction { get; }

    public TransactionLockException(TransactionCommand transaction)
    {
        Transaction = transaction;
    }
}