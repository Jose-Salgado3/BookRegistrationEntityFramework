using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEntityFramework
{
    /// <summary>
    /// Contains helper methods to manipulate books in the database
    /// </summary>
    static class BookDb
    {
        /// <summary>
        /// Retrieves all books sorted in alphabetical order by title.
        /// </summary>
        /// <returns></returns>
        public static List<Book> GetBooks()
        {
            //The using statement will force the compiler to create a try/finally. The finally
            // will dispose of the db context
            using (var context = new BookRegistrationEntities())
            {
                //LINQ Method Syntax
                return context
                    .Book
                    .OrderBy(b => b.Title)
                    .ToList();

                //LINQ Query Syntax
                //List<Book> books =
                //    (from b in context.Book
                //     orderby b.Title ascending
                //     select b).ToList();
                //return books;
            }
        }
    }
}
