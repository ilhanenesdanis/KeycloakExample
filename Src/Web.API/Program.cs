var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddKeycloakJwtBearer("keycloak", realm: "Stocks", options =>
{
    options.RequireHttpsMetadata = false;
    options.Audience = "account";

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/GetNumber", async () =>
{
    var number = Enumerable.Range(0, 1000);

    return Results.Ok(number);
}).RequireAuthorization();


app.UseAuthentication();
app.UseAuthorization();

app.Run();

