using DistributedLockExample.Transactions;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("example", policyBuilder =>
    {
        policyBuilder.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    return ConnectionMultiplexer.Connect(sp.GetService<IConfiguration>()["redis"]);
});

var app = builder.Build();
//Swagger não esta só em dev. para facilitar testes
app.UseSwaggerUI();
app.UseSwagger();

app.UseCors("example");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();