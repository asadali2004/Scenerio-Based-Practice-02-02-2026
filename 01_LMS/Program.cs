namespace LMS
{
    public class UserInterface
    {
        public static SortedDictionary<int, Book> BookDetails = new SortedDictionary<int, Book>();
        public static void Main(string[] args)
        {
            LibraryUtility util = new LibraryUtility();

            // Use Case 1: Add Fiction, Non-Fiction, Mystery books with sample data
            Console.WriteLine("========== Adding Books to Library ==========\n");
            
            util.AddBook("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 1925);
            util.AddBook("1984", "George Orwell", "Fiction", 1949);
            util.AddBook("The Catcher in the Rye", "J.D. Salinger", "Fiction", 1951);
            
            util.AddBook("A Brief History of Time", "Stephen Hawking", "Non-Fiction", 1988);
            util.AddBook("Sapiens", "Yuval Noah Harari", "Non-Fiction", 2011);
            util.AddBook("Thinking, Fast and Slow", "Daniel Kahneman", "Non-Fiction", 2011);
            
            util.AddBook("Murder on the Orient Express", "Agatha Christie", "Mystery", 1934);
            util.AddBook("The Girl with the Dragon Tattoo", "Stieg Larsson", "Mystery", 2005);
            util.AddBook("The Da Vinci Code", "Dan Brown", "Mystery", 2003);

            Console.WriteLine("✓ 9 books added successfully!\n");

            // Use Case 2: Display books grouped by genre
            Console.WriteLine("========== Books Grouped by Genre (Alphabetically) ==========\n");
            var groupedBooks = util.GroupBooksByGenre();
            foreach (var genre in groupedBooks)
            {
                Console.WriteLine($"📚 Genre: {genre.Key}");
                foreach (var book in genre.Value)
                {
                    Console.WriteLine($"   - {book.Title} by {book.Author} ({book.PublicationYear})");
                }
                Console.WriteLine();
            }

            // Use Case 3: Search books by specific author
            Console.WriteLine("========== Books by Specific Authors ==========\n");
            
            string[] authorsToSearch = { "Agatha Christie", "Dan Brown", "F. Scott Fitzgerald" };
            foreach (var author in authorsToSearch)
            {
                var booksByAuthor = util.GetBooksByAuthor(author);
                Console.WriteLine($"📖 Books by {author}:");
                if (booksByAuthor.Count > 0)
                {
                    foreach (var book in booksByAuthor)
                    {
                        Console.WriteLine($"   - {book.Title} ({book.PublicationYear})");
                    }
                }
                else
                {
                    Console.WriteLine("   No books found");
                }
                Console.WriteLine();
            }

            // Use Case 4: Show statistics
            Console.WriteLine("========== Library Statistics ==========\n");
            Console.WriteLine($"📊 Total Books in Library: {util.GetTotalBooksCount()}");
            Console.WriteLine($"📊 Books per Genre:");
            foreach (var genre in groupedBooks)
            {
                Console.WriteLine($"   - {genre.Key}: {genre.Value.Count} books");
            }
            Console.WriteLine($"📊 Total Genres: {groupedBooks.Count}");
        }
    }
}