var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var OriginSpecifications = "OriginPolicy";
builder.Services.AddCors(options => {
    options.AddPolicy(
        name: OriginSpecifications, 
        builder => {
            builder.WithOrigins("http://localhost:5000", "http://localhost:8080");
        }
    );
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(OriginSpecifications);

app.UseAuthorization();

app.MapControllers();

app.Run();
