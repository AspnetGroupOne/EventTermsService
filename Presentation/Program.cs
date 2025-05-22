using Application.Data.Context;
using Application.Data.Repository;
using Application.External.Interfaces;
using Application.External.Models;
using Application.External.Services;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("AspDB")));

builder.Services.Configure<EventSettings>(builder.Configuration.GetSection("EventApi"));

builder.Services.AddHttpClient<IEventValidationService, EventValidationService>();


builder.Services.AddScoped<ITermsRepository, TermsRepository>();






var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();
app.MapControllers();
app.Run();
