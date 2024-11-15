using StockOfMachineParts.Data;
using StockOfMachineParts.Repositories;
using StockOfMachineParts.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IPartsRepository, PartsRepository>();
builder.Services.AddScoped<IPartsService, PartsService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
