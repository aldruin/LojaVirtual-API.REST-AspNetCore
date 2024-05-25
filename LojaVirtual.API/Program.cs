using LojaVirtual.Infrastructure;
using LojaVirtual.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .RegisterApplication(builder.Configuration)
    .RegisterRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
//app.UseAuthorization();
app.MapControllers();

app.Run();
