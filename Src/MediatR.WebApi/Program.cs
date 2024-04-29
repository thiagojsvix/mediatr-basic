using DemoMediatR.WebApi.Filters;
using DemoMediatR.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//registra serviços do negocio
builder.Services.AddInfrastructure(builder.Configuration);

//registra filtro de exceção
builder.Services.AddMvc(option => option.Filters.Add(new CustomExceptionFilter()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
