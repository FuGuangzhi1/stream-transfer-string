var builder = WebApplication.CreateBuilder(args);


//����
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
//����
app.UseCors("ALL");

app.MapControllers();

app.Run();
