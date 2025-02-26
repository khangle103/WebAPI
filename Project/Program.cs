using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Data;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký Controller
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cấu hình CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Thay domain Next.js nếu khác
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// Cấu hình pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// **Thêm dòng này để kích hoạt CORS**
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.MapControllers();
app.Run();
