using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // 註冊控制器
builder.Services.AddEndpointsApiExplorer(); // 啟用終端點探索
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My Waiter API",
        Version = "v1",
        Description = "A simple API for placing orders."
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // 啟用 Swagger UI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Waiter API V1");
    });
}

app.UseHttpsRedirection();

app.MapControllers(); // 映射控制器路由

app.Run();