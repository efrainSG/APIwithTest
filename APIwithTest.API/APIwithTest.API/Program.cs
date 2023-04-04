using APIwithTest.Services.Interfaces;
using APIwithTest.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add singleton services to the container. This kind of services lives during the whole life of the application, independiently of
// the instance of request.

// Add scoped services to the container. This kind services lives during each instance.
builder.Services.AddScoped<ITypeCatalogService, TypeCatalogService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();

// Add transient services to the container. This kind of services lives during each request.

// Add controllers to the container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

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

app.Run();
