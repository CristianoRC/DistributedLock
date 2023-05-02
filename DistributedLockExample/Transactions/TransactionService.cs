using DistributedLockExample.Exceptions;
using Medallion.Threading.Redis;
using StackExchange.Redis;

namespace DistributedLockExample.Transactions;

public class TransactionService : ITransactionService
{
    private readonly IConnectionMultiplexer _redisConnection;

    public TransactionService(IConnectionMultiplexer redisConnection)
    {
        _redisConnection = redisConnection;
    }

    public async Task CreateTransaction(TransactionCommand transaction)
    {
        var lockRedis = new RedisDistributedLock(GenerateLockKey(transaction), _redisConnection.GetDatabase());
        await using var lockResponse = await lockRedis.TryAcquireAsync(timeout: TimeSpan.FromSeconds(5));

        try
        {
            var accountTransactionLocked = lockResponse is null;
            if (accountTransactionLocked) throw new TransactionLockException(transaction);

            //"Create Transaction"
            await Task.Delay(TimeSpan.FromSeconds(7));
        }
        finally
        {
            if (lockResponse is not null)
                await lockResponse.DisposeAsync();
        }
    }

    private static string GenerateLockKey(TransactionCommand transaction)
    {
        return $"lock:{transaction.FromAccount}:transaction";
    }
}