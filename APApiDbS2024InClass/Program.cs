//using APApiDbS2024InClass.Middleware;

using APApiDbS2024InClass.Middleware;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
          

app.UseRouting();

app.UseAuthentication(); // Add authentication middleware if needed
app.UseMiddleware<BasicAuthenticationMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();

