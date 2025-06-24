using System;
using System.Collections.Generic;
using System.Linq;


public class User{
    public int id;
    public string name;
    public bool gender;
    public User(int idd, string n1, bool gen)
    {
        id = idd;
        name = n1;
        gender= gen;
    }
}
public class Book{
    public int isbn;
    public string title;
    public int quantity;
    public Book(int isb, string titl, int quan )
    {
        isbn = isb;
        title = titl;
        if (quantity > 0)
        {
        quantity = quan;
        }
        else{
            quantity=1;
        }
            
    }
}

public class Borrow{
    int sid;
    int Bid;
    public Borrow(int si, int Bi)
    {
        sid= si;
        Bid = Bi;
    }
}
public class LibraryService{
    List<User> users = new List<User>();
    List<Book> books = new List<Book>();
    List<Borrow> borrows = new List<Borrow>();
    public void AddUser(User userDetails)
    {
        users.Add(userDetails);
    }
    public void AddBook(Book bookDetails)
    {
        books.Add(bookDetails);
    }
    public void BorrowBook(int isbn, int userId)
    {
       foreach (var book in books)
        {
            if (book.isbn == isbn)
            {
                if (book.quantity > 0)
                {
                    borrows.Add(new Borrow(userId, isbn));
                    book.quantity -= 1;
                    Console.WriteLine($"{userId} borrowed {isbn}");
                    break;
                }
                else
                {
                    Console.WriteLine("Book out of stock.");
                    return;
                }
            }
        }

        Console.WriteLine("\nBooks remaining:");
        foreach (var book in books)
        {
            Console.WriteLine(book.title);
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Book b1 = new Book(1,"book1",3);
        User u1 = new User(1,"Saim",false);
        LibraryService  L1 = new LibraryService();
        L1.AddUser(u1);
        L1.AddBook(b1);
        L1.BorrowBook(1,1);
        
    }
}