using LINQApp.Model;

namespace LINQApp
{
    internal class Program
    {
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }

        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t.Pub, (pid, title) => new { Key = pid, TitleCount = title.Count() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
            }
        }

        void PrintSalesDetails ()
        {
            pubsContext context = new pubsContext();
            context.Sales.GroupBy(
                    sale => sale.TitleId,
                    sale => sale.
                )
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            program.PrintTheBooksPulisherwise();
        }
    }
}
