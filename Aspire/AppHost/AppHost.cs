var builder = DistributedApplication.CreateBuilder(args);

var userName = builder.AddParameter("KeycloakUserName");
var password = builder.AddParameter("KeycloakPassword");

var keycloak = builder.AddKeycloak("keycloak", 8080, userName, password)
                      .WithDataVolume()
                      .WithOtlpExporter();


builder.AddProject<Projects.Web_API>("API");

builder.Build().Run();
