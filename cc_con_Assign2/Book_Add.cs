using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc_con_Assign2
{

    class Book_Add : Methods
    {
        DateTime dt = DateTime.Today;

        string date = DateTime.UtcNow.ToString("MM-dd-yyyy");

        static int count = 5;
        public int Id { get; set; }

        public string Name { get; set; }

        public string user_name { get; set; }

        public string borrow_date { get; set; }

        public string return_date { get; set; }

       
        public int AvaiBookCopys;
        public override int ItemCopys {
            get
            {
                return AvaiBookCopys;

            }
            set
            {
                AvaiBookCopys = value;
            }
        }

        static List<Book_Add> book = new List<Book_Add>();

        

        static List<Book_Add> Borrower_BookList = new List<Book_Add>();  //list of all borrowers



        public void avilable_book()
        {
            book.Add(new Book_Add() { Id =1, Name = "Think And Grow Rich ", AvaiBookCopys = 2 });
            book.Add(new Book_Add() { Id =2, Name = "Gratest Salesman", AvaiBookCopys = 4 });
            book.Add(new Book_Add() { Id =3, Name = "Power of Motivation", AvaiBookCopys = 5 });
            book.Add(new Book_Add() { Id =4, Name = "Your Favourit here", AvaiBookCopys = 8 });
            book.Add(new Book_Add() { Id = 5, Name = "Awaken the Giant" , AvaiBookCopys = 5});
        }

        public override void Add()                 //Add book
        {

            Console.WriteLine("How many Book do you want to add");
            int insert = int.Parse(Console.ReadLine());
            for (int i = 0; i < insert; i++)
            {
                Console.WriteLine("\tEnter Book Name :");
                string name = Console.ReadLine();
                Console.WriteLine("\tEnter No of Book Copies: ");
                int avaiBookCopys = int.Parse(Console.ReadLine());
                book.Add(new Book_Add() { Id = ++count,Name = name, AvaiBookCopys = avaiBookCopys
            });
            }
            Console.WriteLine("    {0}", "Book added sucessfully ");
            Console.WriteLine();
            Console.WriteLine();
                }

        Book_Add[] Book_Copy = new Book_Add[book.Count];
        // book.CopyTo(Book_Copy);

        public override void search()                         //search book
        {
            Console.WriteLine("Enter Book Id:");
            int b_id = int.Parse(Console.ReadLine());

            Console.WriteLine();
        
            Console.WriteLine(String.Format("{0,40}", "Search Deatils"));
            Console.WriteLine();
            Console.WriteLine("    {0,-20} {1,-20}   {2,-20}", "Id", "Name", "Available Copies");

            var v = from b in book
                    where b.Id == b_id
                    select b;

            foreach (Book_Add b in v)
            {
                Console.WriteLine("    {0,-20} {1,-20}   {2,-20}", b.Id, b.Name, b.AvaiBookCopys);
            }
            Console.WriteLine();
            Console.WriteLine();
         
        }



        public override void delete()                          //delete book
        {
            Console.WriteLine("Enter Book Id:");
            int b_id = int.Parse(Console.ReadLine());

            var remove_item = book.Single(r => r.Id == b_id);
            book.Remove(remove_item);

            Console.WriteLine("\t\tSucessfully Deleted ");
            Console.WriteLine();
            Console.WriteLine(String.Format(" {0,20}","\tAfter Deletion All Available Book:"));
            Console.WriteLine();
            Console.WriteLine("    {0,-20} {1,-20} {2,-20}", "Id", "Name", "Available Copies");
            Console.WriteLine();
            foreach (Book_Add b in book)
            {
                Console.WriteLine("    {0,-20} {1,-20} {2,-20}", b.Id, b.Name, b.AvaiBookCopys);
            }
            Console.WriteLine();
            Console.WriteLine();
          
        }
        public override void view()                         //view book
        {
            Console.WriteLine(String.Format(" {0,20}", "ALL AVAILABLE BOOKS"));
            Console.WriteLine();
            Console.WriteLine("   {0,-20} {1,-20} {2,-20}", "Id", "Name", "Available Copies");
            Console.WriteLine();
            foreach (Book_Add b in book)
            {
                Console.WriteLine("   {0,-20} {1,-20} {2,-20}", b.Id, b.Name,b.AvaiBookCopys);
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        public void borrow_book()
        {
            int check;
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            Console.WriteLine();
            Console.WriteLine(String.Format(" {0,20}", "------------------------------"));
            Console.WriteLine(String.Format("   {0,30}","All Available Books"));
            Console.WriteLine();
            Console.WriteLine("    {0,-20} {1,-20} {2,-20}", "Id", "Name","Available Copies");
            Console.WriteLine();
            foreach (Book_Add b in book)
            {
                Console.WriteLine("    {0,-20} {1,-20} {2,-20}", b.Id, b.Name,b.AvaiBookCopys);
            }
            Console.WriteLine(String.Format("{0,20}", "------------------------------"));
            Console.WriteLine();
            Console.WriteLine();
           
            Console.WriteLine("Enter Book Id that you want :");
            int b_id = int.Parse(Console.ReadLine());

            
            var v = from b in book
                    where b.Id == b_id
                    select b;

            
            Console.WriteLine();
            foreach (Book_Add b in v)
            {
                check = b.AvaiBookCopys;
                if (check > 0)
                {
                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine();
                 
                    Console.WriteLine("  Book Id  : {0,-5} \n  Book Name: {1,-15}", b.Id, b.Name);
                    Console.WriteLine(" Borrow Date :{0}", date);
                    Console.WriteLine();
                    Console.WriteLine(" Hey {0}...You got the book",name);
                    Console.WriteLine();
                    Console.WriteLine();

                    Borrower_BookList.Add(new Book_Add() { Id = b.Id, Name = b.Name, user_name = name, borrow_date = dt.ToString("D"), return_date="Not return"}); 
                    book.Where(bk => bk.Id == b_id).ToList().ForEach(s => s.AvaiBookCopys = s.AvaiBookCopys - 1);


                }
                else
                {
                    Console.WriteLine("Book is not available.");
                }
            }
            

        }

        public void return_book()
        {
            Console.WriteLine("\tEnter  Return Book Id: ");
            int id = int.Parse(Console.ReadLine());
          

            var v = from b in Borrower_BookList
                    where b.Id == id    
                    select b;

            foreach(Book_Add bl in v)
            {
                if (id == bl.Id)
                {
                    book.Where(b => b.Id == id).ToList().ForEach(s => s.AvaiBookCopys = s.AvaiBookCopys + 1);

                    Borrower_BookList.Where(bk => bk.Id == bl.Id).ToList().ForEach(s => s.return_date = date);

                    Console.WriteLine("\tBook Returned Sucessfully");
                    break;
                }
                
            }
            Console.WriteLine();
            Console.WriteLine();

        }

        public void Display_BBook()
        {
            Console.WriteLine(String.Format("{0,20}", "---------------------------------------------------------"));
            Console.WriteLine(String.Format("  {0,60}", "ALL BORROWER BOOK DETAILS"));
            Console.WriteLine();
            Console.WriteLine("    {0,-20} {1,-20}    {2,-25} {3,-25}      {4,-30}", "Id", "Book Name", "User Name" ,"Borrow Date and Time", "Return Date");
            //Console.WriteLine();
            foreach (Book_Add b in Borrower_BookList)
            {
                Console.WriteLine("    {0,-20} {1,-20}    {2,-25} {3,-25}      {4,-20}", b.Id, b.Name, b.user_name,b.borrow_date,b.return_date);
            }
            Console.WriteLine(String.Format("{0,20}", "---------------------------------------------------------"));
            Console.WriteLine();
        }

    }


}