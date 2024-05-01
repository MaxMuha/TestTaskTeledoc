using Microsoft.EntityFrameworkCore;
using TestTaskTeledoc.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("TeledocConnection");

// ��������� �������� DatabaseContext � �������� ������� � ����������
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IClients, ClientsDbRepository>();

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
