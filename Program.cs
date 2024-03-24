var builder = WebApplication.CreateBuilder(args);


//øÁ”Ú
builder.Services.AddCors(options =>
{
    options.AddPolicy("ALL",
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
}).AddMvcCore();


var app = builder.Build();
//øÁ”Ú
app.UseCors("ALL");

app.MapControllers();

app.Run();
