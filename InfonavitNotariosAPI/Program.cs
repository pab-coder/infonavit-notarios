var builder = WebApplication.CreateBuilder(args);

//  Controllers
builder.Services.AddControllers();

//  Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//  Swagger (solo en desarrollo)
//if (app.Environment.IsDevelopment())
//{
// se deja para que swagger entre en produccion en Render
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseDefaultFiles();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();

app.Run();