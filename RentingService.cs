class RentingService
{
  private Dictionary<Book, int> bookInventory;
  private Dictionary<Book, int> currentlyBorrowed;

  public RentingService()
  {
    // Lage ett sett med bøker
    Book martian = new Book("Martian", "Jim");
    Book foundation = new Book("Foundation", "Jack");

    // Opprette data strukturen
    bookInventory = new Dictionary<Book, int>();
    currentlyBorrowed = new Dictionary<Book, int>();

    // Legg til bøker med antall
    bookInventory.Add(martian, 10);
    currentlyBorrowed.Add(martian, 0);
    bookInventory.Add(foundation, 2);
    currentlyBorrowed.Add(foundation, 0);
  }

  public Dictionary<Book, int> ListAllBooks()
  {
    return bookInventory;
  }

  public BorrowReciept? BorrowBook(string title)
  {
    // Sjekke om vi har boken med tittelen
    var inventoryEntry = bookInventory
      .Where(entry => entry.Key.Title == title) // Finne alle element som matcher
      .FirstOrDefault(); // Ta første elementet
    Book book = inventoryEntry.Key;
    int inventoryAmount = inventoryEntry.Value;

    if (book == null)
    {
      return null;
    }

    // Sjekke om vi har minste ett eksemplar tilgjengelig
    int borrowedAmount = currentlyBorrowed[book];
    bool isAvailable = inventoryAmount - borrowedAmount >= 1;

    // Hvis ikke return ingenting (null)
    if (!isAvailable)
    {
      return null;
    }

    // Hvis vi har et eksemplar tilgjengelig
    // Lage en ny kvittering
    BorrowReciept reciept = new BorrowReciept(book.Title);
    // Oppdatere antall utlånte eksemplarer
    // currentlyBorrowed[book] = currentlyBorrowed[book] + 1;
    currentlyBorrowed[book]++;
    // Returnere kvitteringen
    return reciept;
  }

  public ReturnReciept ReturnBook(string title)
  {
    throw new NotImplementedException();
  }
}

class Book
{
  public string Title { get; set; }
  public string Author { get; set; }

  public Book(string title, string author)
  {
    Title = title;
    Author = author;
  }
}

class BorrowReciept
{
  public DateTime BorrowingDate { get; set; }
  public DateTime DueDate { get; set; }
  public String BookTitle { get; set; }

  public BorrowReciept(string bookTitle)
  {
    BookTitle = bookTitle;
    BorrowingDate = DateTime.Today;
    DueDate = DateTime.Today.AddDays(30);
  }
}

class ReturnReciept
{

}