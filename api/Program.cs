using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.MapScalarApiReference("docs", opt =>
{
	opt.WithTheme(ScalarTheme.DeepSpace);
});

app.UseHttpsRedirection();

app.MapGet("/", () => "Hi"); ;

app.MapGet("/random", () => new Random().Next());

app.Run();