using Microsoft.EntityFrameworkCore;
using VShop.ProductApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(mySqlConnection, 
                ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//duvida: qual a melhor forma para registrar serviços?
//duvida: remover cache
//duvida: por qual motivo a brgaap não utiliza UnitOfWork? E como salva as alterações?
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
