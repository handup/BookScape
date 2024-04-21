namespace BookScape.Models;

public class Book {
    public Book(){
        Title = "";
        AuthorId = -1;
    }
        public long Id { get; set; }
    public string Title { get; set; }
    public long AuthorId { get; set;}
    public Author? Author { get; set; }
    public string? Language { get; set; }
}

public class Author {
    public Author(){
       FullName = "";
       Country = "";
       Gender = "";
    }
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Country { get; set; }
    public string Gender {get; set; }
}
