﻿using _991667498NoopurPatel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _991667498NoopurPatel
{
    class Program
    {
        // List to store the books in the library
        static List<Book> books = new List<Book>();

        static void Main(string[] args)
        {
            // Populate the list with sample data
            PopulateSampleData();
            bool exit = false;

            // Main loop to display the menu and handle user input
            while (!exit)
            {
                // Display the menu
                Console.WriteLine("=====================================");
                Console.WriteLine("      Library Management System      ");
                Console.WriteLine("=====================================");
                Console.WriteLine();
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Edit Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. View Books");
                Console.WriteLine("5. Search Book");
                Console.WriteLine("6. Exit");
                Console.WriteLine();
                Console.WriteLine("=====================================");
                Console.Write("Select an option (1-6): ");

                // Handle user input
                switch (Console.ReadLine())
                {
                    case "1":
                        AddBookMenu();
                        break;
                    case "2":
                        EditBookMenu();
                        break;
                    case "3":
                        DeleteBookMenu();
                        break;
                    case "4":
                        ViewBooks();
                        break;
                    case "5":
                        SearchBooks();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        // Method to populate the list with sample books
        static void PopulateSampleData()
        {
            // Fiction Books
            books.Add(new FictionBook("To Kill a Mockingbird", "Harper Lee", 1960) { Price = 10.99m });
            books.Add(new FictionBook("1984", "George Orwell", 1949) { Price = 14.99m });
            books.Add(new FictionBook("The Great Gatsby", "F. Scott Fitzgerald", 1925) { Price = 12.99m });

            // Non-Fiction Books
            books.Add(new NonFictionBook("Sapiens: A Brief History of Humankind", "Yuval Noah Harari", 2011) { Price = 22.99m });
            books.Add(new NonFictionBook("Educated", "Tara Westover", 2018) { Price = 18.99m });
            books.Add(new NonFictionBook("Becoming", "Michelle Obama", 2018) { Price = 19.99m });

            // Reference Books
            books.Add(new ReferenceBook("The Elements of Style", "William Strunk Jr.", 1918) { Price = 8.99m });
            books.Add(new ReferenceBook("Encyclopedia Britannica", "Various", 1768) { Price = 149.99m });
            books.Add(new ReferenceBook("Gray's Anatomy", "Henry Gray", 1858) { Price = 34.99m });

            // Magazines
            books.Add(new Magazine("National Geographic", "Various", 2023) { Price = 6.99m });
            books.Add(new Magazine("TIME", "Various", 2023) { Price = 5.99m });
            books.Add(new Magazine("The Economist", "Various", 2023) { Price = 7.99m });
        }

        // Method to display the menu for adding a book
        static void AddBookMenu()
        {
            Console.WriteLine("1. Add Fiction Book");
            Console.WriteLine("2. Add Non-Fiction Book");
            Console.WriteLine("3. Add Reference Book");
            Console.WriteLine("4. Add Magazine");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddBook(BookType.Fiction);
                    break;
                case "2":
                    AddBook(BookType.NonFiction);
                    break;
                case "3":
                    AddBook(BookType.Reference);
                    break;
                case "4":
                    AddBook(BookType.Magazine);
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }

        // Method to add a book of a specific type
        static void AddBook(BookType bookType)
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter Publication Year: ");
            if (!int.TryParse(Console.ReadLine(), out int publicationYear))
            {
                Console.WriteLine("Invalid year. Please try again.");
                return;
            }
            Console.Write("Enter Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price. Please try again.");
                return;
            }

            // Create a new book based on the type and add it to the list
            Book newBook = bookType switch
            {
                BookType.Fiction => new FictionBook(title, author, publicationYear) { Price = price },
                BookType.NonFiction => new NonFictionBook(title, author, publicationYear) { Price = price },
                BookType.Reference => new ReferenceBook(title, author, publicationYear) { Price = price },
                BookType.Magazine => new Magazine(title, author, publicationYear) { Price = price },
                _ => null
            };

            books.Add(newBook);
            Console.WriteLine("Book added successfully.");
            DisplayBooksByType(bookType);
        }

        // Method to display the menu for editing a book
        static void EditBookMenu()
        {
            Console.WriteLine("1. Edit Fiction Book");
            Console.WriteLine("2. Edit Non-Fiction Book");
            Console.WriteLine("3. Edit Reference Book");
            Console.WriteLine("4. Edit Magazine");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    EditBook(BookType.Fiction);
                    break;
                case "2":
                    EditBook(BookType.NonFiction);
                    break;
                case "3":
                    EditBook(BookType.Reference);
                    break;
                case "4":
                    EditBook(BookType.Magazine);
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }

        // Method to edit a book of a specific type
        static void EditBook(BookType bookType)
        {
            // Display the books of the specified type
            DisplayBooksByType(bookType);
            Console.Write("Enter Book ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Invalid ID. Please try again.");
                return;
            }

            // Find the book to edit
            Book book = books.FirstOrDefault(b => b.BookId == bookId && b.BookType == bookType);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            // Get new details from the user
            Console.Write("Enter new Title: ");
            book.Title = Console.ReadLine();
            Console.Write("Enter new Author: ");
            book.Author = Console.ReadLine();
            Console.Write("Enter new Publication Year: ");
            if (!int.TryParse(Console.ReadLine(), out int publicationYear))
            {
                Console.WriteLine("Invalid year. Please try again.");
                return;
            }
            book.PublicationYear = publicationYear;
            Console.Write("Enter new Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price. Please try again.");
                return;
            }
            book.Price = price;

            Console.WriteLine("Book edited successfully.");
            DisplayBooksByType(bookType);
        }

        // Method to display the menu for deleting a book
        static void DeleteBookMenu()
        {
            Console.WriteLine("1. Delete Fiction Book");
            Console.WriteLine("2. Delete Non-Fiction Book");
            Console.WriteLine("3. Delete Reference Book");
            Console.WriteLine("4. Delete Magazine");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    DeleteBook(BookType.Fiction);
                    break;
                case "2":
                    DeleteBook(BookType.NonFiction);
                    break;
                case "3":
                    DeleteBook(BookType.Reference);
                    break;
                case "4":
                    DeleteBook(BookType.Magazine);
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }

        // Method to delete a book of a specific type
        static void DeleteBook(BookType bookType)
        {
            // Display the books of the specified type
            DisplayBooksByType(bookType);
            Console.Write("Enter Book ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Invalid ID. Please try again.");
                return;
            }

            // Find the book to delete
            Book book = books.FirstOrDefault(b => b.BookId == bookId && b.BookType == bookType);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            // Remove the book from the list
            books.Remove(book);
            Console.WriteLine("Book deleted successfully.");
            DisplayBooksByType(bookType);
        }

        // Method to display all books
        static void ViewBooks()
        {
            DisplayBooksByType(BookType.Fiction);
            DisplayBooksByType(BookType.NonFiction);
            DisplayBooksByType(BookType.Reference);
            DisplayBooksByType(BookType.Magazine);
        }

        // Method to search for books by title
        static void SearchBooks()
        {
            Console.Write("Enter book title to search: ");
            string keyword = Console.ReadLine();

            // Find books that match the keyword
            var results = books.Where(b => b.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            // Display the search results
            if (results.Count == 0)
            {
                Console.WriteLine("No books found.");
            }
            else
            {
                Console.WriteLine($"Found {results.Count} book(s):");
                DisplayBooks(results);
            }
        }

        // Method to display books of a specific type
        static void DisplayBooksByType(BookType bookType)
        {
            var filteredBooks = books.Where(b => b.BookType == bookType).ToList();
            if (filteredBooks.Count > 0)
            {
                Console.WriteLine($"--- {bookType} Books ---");
                DisplayBooks(filteredBooks);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"No {bookType} books available.");
            }
        }

        // Method to display a list of books
        static void DisplayBooks(List<Book> bookList)
        {
            // Display the header
            Console.WriteLine("{0,-5} {1,-30} {2,-20} {3,-15} {4,10} {5,10}", "ID", "Title", "Author", "Year", "Type", "Price");
            foreach (var book in bookList)
            {
                // Display each book's details
                Console.WriteLine("{0,-5} {1,-30} {2,-20} {3,-15} {4,10} {5,10:C}", book.BookId, book.Title, book.Author, book.PublicationYear, book.BookType, book.Price);
            }
        }
    }
}
