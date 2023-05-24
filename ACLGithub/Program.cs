using ACLGithub.Adapters;
using ACLGithub.Adapters.Implementations;
using ACLGithub.Mediators;
using ACLGithub.Mediators.Implementations;
using ACLGithub.Services;
using ACLGithub.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGithubRestMethodAdapter, GithubSimplesRestMethodAdapter>();
builder.Services.AddScoped<IGithubMediator, GithubSimpleMediator>();
builder.Services.AddScoped<IGithubService, GithubService>();

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