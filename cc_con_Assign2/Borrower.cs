using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc_con_Assign2
{

    class Borrower
    {
        static int count = 100;

       public static List<Borrower> Borrowers_Details = new List<Borrower>();
       


        public string Name { get; set; }

        public int MemberId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

       

        public void available_Details()
        {
            Borrowers_Details.Add(new Borrower() { MemberId = 98, Name = "Rohan", City = "Bhopal", Email = "rohan@email", Phone = "8934567893"});
            Borrowers_Details.Add(new Borrower() { MemberId = 100, Name = "Khushbu", City = "Seoni", Email = "khush@email", Phone = "9834590893" });
        }

        public void add()                 //Add book
        {
                Console.WriteLine("\tEnter Your Name :");
                string name = Console.ReadLine();
                Console.WriteLine("\tEnter Your Email: ");
                string email =Console.ReadLine();
                 Console.WriteLine("\tEnter Your City: ");
                 string city = Console.ReadLine();
                Console.WriteLine("\tEnter Your phone: ");
                string phone =Console.ReadLine();

                Borrowers_Details.Add(new Borrower() { MemberId = count + 1, Name = name, City=city, Email=email,Phone =phone});
 
        }

        Borrower[] Borrower_Copy = new Borrower[Borrowers_Details.Count];

        public void view()                         //view book
        {
            Console.WriteLine(String.Format("{0,20}", "USER DETAILS"));
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,20}", "---------------------------------------------------------------"));
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "User Id ", "Name", "Email","City","Phone");
            foreach (Borrower b in Borrowers_Details)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", b.MemberId, b.Name, b.Email,b.City,b.Phone);
            }
            Console.WriteLine(String.Format("{0,20}", "---------------------------------------------------------------"));
        }


    }
}
