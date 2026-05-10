var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // add all controller classes as services calss
var app = builder.Build();

app.MapControllers(); // map all action methods in the controllers

app.Run();
