using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc_con_Assign2
{
    class Newspaper:Methods
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AvaiNewspaperCopys;
        public override int ItemCopys
        {
            get
            {
                return AvaiNewspaperCopys;

            }
            set
            {
                AvaiNewspaperCopys = value;
            }
        }
        static List<Newspaper> newspaper = new List<Newspaper>();

        public void available_news()
        {
            newspaper.Add(new Newspaper() { Id = 1, Name = "Timeline Newspaper",AvaiNewspaperCopys=2});
            newspaper.Add(new Newspaper() { Id = 2, Name = "English Newspaper", AvaiNewspaperCopys = 3 });
            newspaper.Add(new Newspaper() { Id = 3, Name = "Hindustan Newspaper", AvaiNewspaperCopys =2});
            newspaper.Add(new Newspaper() { Id = 4, Name = "World Newspaper", AvaiNewspaperCopys =1});


        }

        public override void Add()                 //Add book
        {
            Console.WriteLine("How many Newspaper do you want to add");
            int insert = int.Parse(Console.ReadLine());
            for (int i = 0; i < insert; i++)
            {
                Console.WriteLine("\tEnter Newspaper Name :");
                string name = Console.ReadLine();
                Console.WriteLine("\tEnter Newspaper Id: ");
                int id = int.Parse(Console.ReadLine());
                
                newspaper.Add(new Newspaper() { Id = id, Name = name});
            }
        }
        
        Book_Add[] Newspaper_Copy = new Book_Add[newspaper.Count];

        public override void search()                         //search book
        {
            Console.WriteLine("Enter Newspaper Id:");
            int b_id = int.Parse(Console.ReadLine());
            Console.WriteLine(String.Format("{0,20}", "Search Details :"));
            Console.WriteLine("{0,-20} {1,-20}", "Id", "Name");

            var v = from n in newspaper
                    where n.Id == b_id
                    select n;
            foreach (Newspaper n in v)
            {
                Console.WriteLine("{0,-20} {1,-20}", n.Id, n.Name);
            }
            Console.WriteLine();
        }
        public override void delete()                          //delete book
        {
            Console.WriteLine("Enter Book Id:");
            int b_id = int.Parse(Console.ReadLine());

            var remove_item = newspaper.Single(r => r.Id == b_id);
            newspaper.Remove(remove_item);

            Console.WriteLine(String.Format("{0,20}", "After Deletion :"));
            Console.WriteLine("{0,-20} {1,-20}", "Id", "Name");
            foreach (Newspaper n in newspaper)
            {
                Console.WriteLine("{0,-20} {1,-20}", n.Id, n.Name);
            }
            Console.WriteLine();

        }


        public override void view()                         //view book
        {
            Console.WriteLine(String.Format("{0,20}", "ALL NEWSPAPERS"));
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Id", "Name","Available Copies");
            Console.WriteLine("");
            foreach (Newspaper n in newspaper)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", n.Id, n.Name,n.AvaiNewspaperCopys);
            }
            Console.WriteLine("");
        }


        public void borrow_newspaper()
        {
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            Console.WriteLine("All NEWSPAPER");
            Console.WriteLine();
            Console.WriteLine("{0,-5} {1,-15}", "Id", "Name");
            foreach (Newspaper n in newspaper)
            {
                Console.WriteLine("{0,-5} {1,-15}", n.Id, n.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Enter Newspaper Id that you want :");
            int b_id = int.Parse(Console.ReadLine());

            var v = from n in newspaper
                    where n.Id == b_id
                    select n;

            Console.WriteLine();
            foreach (Newspaper n in v)
            {
                Console.WriteLine(" Newspaper Id  : {0,-5} Newspaper Name:   {1,-15}", n.Id, n.Name);
            }

            Console.WriteLine(" Borrow Date :{0}", date);
            Console.WriteLine();
            Console.WriteLine(" Hey Borrower...You got the Newspaper");

            var remove_item = newspaper.Single(r => r.Id == b_id);
            newspaper.Remove(remove_item);

        }

        public void return_newspaper()
        {
            Console.WriteLine("\tEnter  Return Newspaper Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("\tEnter Return Newspaper Name :");
            string name = Console.ReadLine();
            newspaper.Add(new Newspaper() { Id = id, Name = name });

            Console.WriteLine("\tNewspaper Returned Sucessfully");
        }

    }
}
