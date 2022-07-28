using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc_con_Assign2
{
    class Newspaper:Methods
    {
        DateTime dt = DateTime.Today;

        string date = DateTime.UtcNow.ToString("MM-dd-yyyy");

        static int count = 4;
        public int Id { get; set; }

        public string Name { get; set; }

        public string user_name { get; set; }

        public string news_borrow_date { get; set; }

        public string return_news_date { get; set; }

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

        static List<Newspaper>Borrow_Newsp_List=new List<Newspaper>();

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
                Console.WriteLine("\tEnter No of Newspaper Copies : ");
                int avaiNewspaperCopys = int.Parse(Console.ReadLine());
                
                newspaper.Add(new Newspaper() {Id= ++count, Name = name, AvaiNewspaperCopys = avaiNewspaperCopys });
            }
            Console.WriteLine("    {0}", "Book added sucessfully ");
            Console.WriteLine();
            Console.WriteLine();
        }
        
        Book_Add[] Newspaper_Copy = new Book_Add[newspaper.Count];

        public override void search()                         //search book
        {
            Console.WriteLine("Enter Newspaper Id:");
            int b_id = int.Parse(Console.ReadLine());
            
            Console.WriteLine(String.Format("{0,20}", "Search Details :"));
            Console.WriteLine();
            Console.WriteLine("    {0,-20} {1,-20} {2,-20}", "Id", "Name", "Available Newspaper Copies");

                var v = from n in newspaper
                        where n.Id == b_id
                        select n;

                foreach (Newspaper n in v)
                {
                    Console.WriteLine("    {0,-20} {1,-20} {2,-20}", n.Id, n.Name, n.AvaiNewspaperCopys);
                }
                Console.WriteLine();
          
        }
        public override void delete()                          //delete book
        {
            Console.WriteLine("Enter Book Id:");
            int b_id = int.Parse(Console.ReadLine());

            var remove_item = newspaper.Single(r => r.Id == b_id);
            newspaper.Remove(remove_item);

            Console.WriteLine(String.Format("    {0,30}", "After Deletion :"));
            Console.WriteLine("    {0,-20} {1,-20} {2,-20}", "Id", "Name","Available Newspaper Copies");
            foreach (Newspaper n in newspaper)
            {
                Console.WriteLine("    {0,-20} {1,-20} {2,-20}", n.Id, n.Name,n.AvaiNewspaperCopys);
            }
            Console.WriteLine();
            Console.WriteLine();

        }


        public override void view()                         //view book
        {
            Console.WriteLine(String.Format("   {0,30}", "ALL NEWSPAPERS"));
            Console.WriteLine();
            Console.WriteLine("    {0,-20} {1,-20} {2,-20}", "Id", "Name","Available Copies");
            Console.WriteLine("");
            foreach (Newspaper n in newspaper)
            {
                Console.WriteLine("     {0,-20} {1,-20} {2,-20}", n.Id, n.Name,n.AvaiNewspaperCopys);
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        public void borrow_newspaper()
        {
            int check;
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            Console.WriteLine();
            Console.WriteLine(String.Format(" {0,20}", "------------------------------"));
            Console.WriteLine(String.Format("   {0,30}", "All Available Newspaper"));
            Console.WriteLine();
            Console.WriteLine("    {0,-20} {1,-20} {2,-20}", "Id", "Name","Available Newspaper Copies");
            Console.WriteLine();

            foreach (Newspaper n in newspaper)
            {
                Console.WriteLine("    {0,-20} {1,-20} {2,-20}", n.Id, n.Name,n.AvaiNewspaperCopys);
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
                check = n.AvaiNewspaperCopys;
                if (check > 0)
                {
                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine();
                    Console.WriteLine("  Newspaper Id  :  {0,-20} \n  Newspaper Name:  {1,-20} ", n.Id, n.Name);
                    Console.WriteLine("  Borrow Date :{0}", date);
                    Console.WriteLine();
                    Console.WriteLine(" Hey Borrower...You got the Newspaper");
                    Console.WriteLine();
                    Console.WriteLine();

                    Borrow_Newsp_List.Add(new Newspaper() { Id = n.Id, Name = n.Name, user_name = name, news_borrow_date= dt.ToString("D"),return_news_date="Not return" });
                    newspaper.Where(b => b.Id == b_id).ToList().ForEach(s => s.AvaiNewspaperCopys = s.AvaiNewspaperCopys - 1);
                }
                else
                {
                    Console.WriteLine("Newspaper is not available.");
                    Console.WriteLine();
                }
            }
           
        }

        public void return_newspaper()
        {
            Console.WriteLine("\tEnter  Return Newspaper Id: ");
            int id = int.Parse(Console.ReadLine());

            var v = from b in Borrow_Newsp_List
                    where b.Id == id
                    select b;

            foreach (Newspaper bl in v)
            {
                if (id == bl.Id)
                {
                    newspaper.Where(b => b.Id == id).ToList().ForEach(s => s.AvaiNewspaperCopys = ++s.AvaiNewspaperCopys);
                    Borrow_Newsp_List.Where(b => b.Id == id).ToList().ForEach(s => s.return_news_date= date);
                    Console.WriteLine("\tNewspaper Returned Sucessfully");
                    Console.WriteLine();
                }
            }
        }

        public void Display_NewsList()
        {
            Console.WriteLine(String.Format("{0,20}", "---------------------------------------------------------"));
            Console.WriteLine(String.Format("  {0,60}", "ALL BORROWER BOOK DETAILS"));
            Console.WriteLine();
            Console.WriteLine("    {0,-20} {1,-20}    {2,-25} {3,-25}      {4,-30}", "Id", "Newspaper Name", "User Name", "Borrow Date and Time","Returned Date");
            foreach (Newspaper b in Borrow_Newsp_List)
            {
                Console.WriteLine("    {0,-20} {1,-20}    {2,-25} {3,-25}      {4,-20}", b.Id, b.Name, b.user_name, b.news_borrow_date,b.return_news_date);
            }
            Console.WriteLine();
        }

    }
}
