using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc_con_Assign2
{

    class Book_Add : Methods
    {
        string date = DateTime.UtcNow.ToString("MM-dd-yyyy");

        public int Id { get; set; }

        public string Name { get; set; }

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

        static List<Borrower> Borrowers_Details = new List<Borrower>();

        public void avilable_book()
        {
            book.Add(new Book_Add() { Id = 1, Name = "Book1 ", AvaiBookCopys = 2 });
            book.Add(new Book_Add() { Id = 2, Name = "Book2", AvaiBookCopys = 4 });
            book.Add(new Book_Add() { Id = 3, Name = "Book3", AvaiBookCopys = 5 });
            book.Add(new Book_Add() { Id = 4, Name = "Book4", AvaiBookCopys = 8 });
            book.Add(new Book_Add() { Id = 5, Name = "Book5" , AvaiBookCopys = 5});
        }

        public override void Add()                 //Add book
        {

            Console.WriteLine("How many Book do you want to add");
            int insert = int.Parse(Console.ReadLine());
            for (int i = 0; i < insert; i++)
            {
                Console.WriteLine("\tEnter Book Name :");
                string name = Console.ReadLine();
                Console.WriteLine("\tEnter Book Id: ");
                int id = int.Parse(Console.ReadLine());
                book.Add(new Book_Add() { Id = id, Name = name});
            }
        }

        Book_Add[] Book_Copy = new Book_Add[book.Count];
        // book.CopyTo(Book_Copy);

        public override void search()                         //search book
        {
            Console.WriteLine("Enter Book Id:");
            int b_id = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Format("{0,20}", "Search Deatils"));
            Console.WriteLine();
            Console.WriteLine("{0,5} {1,18}", "Id", "Name");

            var v = from b in book
                    where b.Id == b_id
                    select b;

            foreach (Book_Add b in v)
            {
                Console.WriteLine("{0,5} {1,20}", b.Id, b.Name);
            }
            Console.WriteLine();
        }



        public override void delete()                          //delete book
        {
            Console.WriteLine("Enter Book Id:");
            int b_id = int.Parse(Console.ReadLine());

            var remove_item = book.Single(r => r.Id == b_id);
            book.Remove(remove_item);

            Console.WriteLine("Sucessfully Deleted ");
            Console.WriteLine();
            Console.WriteLine("\tAfter Deletion All Available Book:");
            Console.WriteLine();
            Console.WriteLine("{0,15} {1,15}", "Id","Name");
            foreach (Book_Add b in book)
            {
                Console.WriteLine("{0,15} {1,15}",b.Id,b.Name);
            }
            Console.WriteLine();
        }
        public override void view()                         //view book
        {
            Console.WriteLine(String.Format("{0,20}", "ALL AVAILABLE BOOKS"));
            Console.WriteLine();
            Console.WriteLine("{0,-5} {1,-15},{2,-15}", "Id", "Name", "Available Copies");
            foreach (Book_Add b in book)
            {
                Console.WriteLine("{0,-5} {1,-15} {2,-15}", b.Id, b.Name,b.AvaiBookCopys);
            }
        }


        public void borrow_book()
        {
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            Console.WriteLine("All Books");
            Console.WriteLine();
            Console.WriteLine("{0,-5} {1,-15} {2,-15}", "Id", "Name","Available Copies");
            foreach (Book_Add b in book)
            {
                Console.WriteLine("{0,-5} {1,-15} {2,15}", b.Id, b.Name,b.AvaiBookCopys);
            }
            Console.WriteLine();
            Console.WriteLine("Enter Book Id that you want :");
            int b_id = int.Parse(Console.ReadLine());

            //var bk = book.Where(b => b.Id == b_id).Select(b => { b.AvaiBookCopys =AvaiBookCopys-1; return b; });
            
            var v = from b in book
                    where b.Id == b_id
                    select b;

            
            Console.WriteLine();
            foreach (Book_Add b in v)
            {
                
                Console.WriteLine(" Book Id  : {0,-5} Book Name:   {1,-15}", b.Id, b.Name);
            }

            Console.WriteLine(" Borrow Date :{0}", date);
            Console.WriteLine();
            Console.WriteLine(" Hey Borrower...You got the book");

            book.Where(b => b.Id == b_id).ToList().ForEach(s => s.AvaiBookCopys = s.AvaiBookCopys-1);


            //add borrow book details 

            

        }

        public void return_book()
        {
            Console.WriteLine("\tEnter  Return Book Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("\tEnter Return Book Name :");
            string name = Console.ReadLine();
            book.Add(new Book_Add() { Id =id, Name =name });

            Console.WriteLine("\tBook Returned Sucessfully");
        }

    }


}