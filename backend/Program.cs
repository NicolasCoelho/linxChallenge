using backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BackendContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConnection")
));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var OriginSpecifications = "OriginPolicy";
builder.Services.AddCors(options => {
    options.AddPolicy(
        name: OriginSpecifications, 
        builder => {
            builder.WithOrigins("http://localhost:5000", "http://localhost:8080")
            .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        }
    );
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseFileServer(new FileServerOptions(){
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Static")
    ),
    RequestPath= "/static"
});

app.UseCors(OriginSpecifications);

app.UseAuthorization();

app.MapControllers();

app.Run();
