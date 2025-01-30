var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

RentingService rentingService = new RentingService();

app.MapGet("/books", () =>
{
  var bookInventory = rentingService.ListAllBooks();
  var booksList = bookInventory.Select(inventoryEntry => inventoryEntry.Key);

  return Results.Ok(booksList);
});

app.MapPost("/borrow", (BorrowRequest borrowRequest) =>
{
  BorrowReciept? reciept = rentingService.BorrowBook(borrowRequest.BookTitle);

  if (reciept == null)
  {
    return Results.BadRequest("Not Available");
  }
  else
  {
    return Results.Ok(reciept);
  }
});

app.Run();
