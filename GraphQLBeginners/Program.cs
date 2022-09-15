using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLBeginners.Data;
using GraphQLBeginners.Interfaces;
using GraphQLBeginners.Mutation;
using GraphQLBeginners.Query;
using GraphQLBeginners.Schema;
using GraphQLBeginners.Services;
using GraphQLBeginners.Type;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GraphQLDbContext>(opt =>
opt.UseSqlServer(@"Data Source=.;Initial Catalog=GraphQLDb;Integrated Security=True;MultipleActiveResultSets=True")
, ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddTransient<IProduct, ProductService>();

builder.Services.AddSingleton<ProductType>();
builder.Services.AddSingleton<ProductQuery>();
builder.Services.AddSingleton<ProductMutation>();
builder.Services.AddSingleton<ISchema, ProductSchema>();

#pragma warning disable CS0612 // El tipo o el miembro están obsoletos
builder.Services.AddGraphQL(opt =>
{
    opt.EnableMetrics = false;
}).AddSystemTextJson();
#pragma warning restore CS0612 // El tipo o el miembro están obsoletos

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

app.UseAuthorization();

app.MapControllers();

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

app.Run();
