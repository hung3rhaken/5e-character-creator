using CharacterCreator.Backend.Endpoints.Character;

var builder = WebApplication.CreateBuilder(args);

// Optional: Configure JSON options if needed (e.g., for indented output)
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.WriteIndented = true;
});

// Add services to the container.
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

app.AddCharacterEndpoints();

app.UseHttpsRedirection();

app.Run();