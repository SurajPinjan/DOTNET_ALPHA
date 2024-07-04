
using AutomateLIMS.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/run", (Query _query) =>
{
    // Execute the query from dbSERVICE FUNCTION.
    DBJob _dbJob = new DBJob();
    _dbJob.runDBQuery(_query.QueryString);
});

app.Run();
