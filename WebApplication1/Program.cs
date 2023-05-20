using WebApplication1.Models;
using FluentValidation;
using FluentValidation.Results;
using WebApplication1.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// �����p�̃o���f�[�^�[��o�^
builder.Services.AddScoped<IValidator<Order>, OrderValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// OrderAPI���`
app.MapPost("/api/orders", async (IValidator<Order> validator, Order order) =>
{
    if (order == null) return Results.BadRequest();

    // ���N�G�X�g�̃o���f�[�V����
    ValidationResult validationResult = await validator.ValidateAsync(order);
    if (!validationResult.IsValid)
    {
        return Results.BadRequest(validationResult);
    }

    return Results.Ok(validationResult);
});

app.Run();
