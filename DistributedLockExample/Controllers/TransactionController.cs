using DistributedLockExample.Exceptions;
using DistributedLockExample.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace DistributedLockExample.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] TransactionCommand transaction)
    {
        try
        {
            await _transactionService.CreateTransaction(transaction);
            return Created($"transaction/{transaction.Id}", transaction);
        }
        catch (TransactionLockException e)
        {
            //Aqui é quando não consegue obter o lock no tempo padrão do timeout, teria que add na fila dnv ou algo do tipo
            // e.Transaction
            return new StatusCodeResult(StatusCodes.Status423Locked);
        }
    }
}