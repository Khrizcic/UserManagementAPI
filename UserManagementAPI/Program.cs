using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Data;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Mutation;
using UserManagementAPI.Query;
using UserManagementAPI.Schema;
using UserManagementAPI.Services;
using UserManagementAPI.Type;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUser, UserService>();
builder.Services.AddTransient<UserType>();
builder.Services.AddTransient<UserQuery>();
builder.Services.AddTransient<UserMutation>();
builder.Services.AddTransient<UserInputType>();
builder.Services.AddTransient<UserSchema>();
builder.Services.AddTransient<ISchema, UserSchema>();
builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = false;
}).AddSystemTextJson();
builder.Services.AddDbContext<GraphQLDbContext>(option => option.UseSqlServer(@"Data Source= (localdb)\MSSQLLocalDB;Initial Catalog=UserManagement;Integrated Security = True"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GraphQLDbContext>();
    dbContext.Database.EnsureCreated();

}

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

app.Run();
