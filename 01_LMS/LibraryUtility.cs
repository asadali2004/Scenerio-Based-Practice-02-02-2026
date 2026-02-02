using System.Collections.Concurrent;
namespace LMS
{
    public class LibraryUtility
    {
        public void AddBook(string title, string author, string genre, int year)
        {
            UserInterface.BookDetails.Add(UserInterface.BookDetails.Count + 1, new Book(title, author, genre, year));
        }

        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            return new SortedDictionary<string, List<Book>>
            (UserInterface.BookDetails.Values
                .GroupBy(b => b.Genre)
                .OrderBy(e => e.Key)
                .ToDictionary(k => k.Key, b => b.ToList())
            );
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return UserInterface.BookDetails.Values.Where(b => b.Author == author).ToList();
        }

        public int GetTotalBooksCount()
        {
            return UserInterface.BookDetails.Count;
        }
    }
}