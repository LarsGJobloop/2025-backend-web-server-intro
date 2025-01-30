var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
  // return Results.Ok(new { message = "Hello", content = "Testing testing" });
  var jsonPayload = new { message = "Hello", content = "Testing testing" };
  return Results.Ok(jsonPayload);
});

app.MapPost("/", (BorrowRequest requestBody) =>
{
  Console.WriteLine($"Message: {requestBody.Message}");
  Console.WriteLine($"Number: {requestBody.Number}");

  return Results.Accepted();
});

app.MapPut("/{articlId}", (int articlId) =>
{
  Console.WriteLine($"At dynamic segment: {articlId}");
  return Results.Accepted();
});

app.MapDelete("/", () =>
{
  return Results.Created();
});

app.Run();
