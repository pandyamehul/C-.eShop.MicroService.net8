var builder = WebApplication.CreateBuilder(args);

//Add Services to container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

var app = builder.Build();

//Configure HTTP request pipeline
app.MapCarter();

app.Run();
