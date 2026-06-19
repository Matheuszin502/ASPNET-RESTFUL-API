using RestWithASPNET.Configurations;
using RestWithASPNET.Hypermedia.Filters;
using RestWithASPNET.Repositories;
using RestWithASPNET.Repositories.Impl;
using RestWithASPNET.Services;
using RestWithASPNET.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers(options =>
    {
        options.Filters.Add<HypermediaFilter>();
    })
    .AddContentNegotiation();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenAPIConfig();
builder.Services.AddSwaggerConfig();
builder.Services.AddRouteConfig();

builder.Services.AddCorsConfiguration(builder.Configuration);
builder.Services.AddHATEOASConfiguration();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);

builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddScoped<IBookServices, BookServicesImpl>();
builder.Services.AddScoped<PersonServicesImplV2>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
//app.UseCorsConfiguration();
app.UseCorsConfiguration(builder.Configuration);

app.MapControllers();

app.UseHATEOASRoutes();

app.UseSwaggerSpecification();
app.UseScalarConfiguration();

app.Run();
