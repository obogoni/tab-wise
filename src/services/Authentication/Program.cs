var builder = WebApplication.CreateBuilder(args);

builder.AddKeycloak();

var app = builder.Build();

app.AddFeatures();
app.Run();
