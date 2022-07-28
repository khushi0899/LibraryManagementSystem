using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Threading;

namespace cc_con_Assign2
{
    class Program
    {
      //  static List<Book_Add> book = new List<Book_Add>();

       // static List<Newspaper> newspaper = new List<Newspaper>();

       // static List<Borrower> Borrowers_Details = new List<Borrower>();

        static void Main(string[] args)
        {

            Borrower bor = new Borrower();
         
            string c;

            int value;

            int choice;                               //Menu option

            int choice_book;                          //Book option

            int choice_news;                          // option for news

            int choice_borrower;                      // option borrower

            int Libranian_choice;

            Console.WriteLine();
            Console.WriteLine(String.Format("{0,70}", "::LIBRARY MANAGEMENT SYSTEM::"));
            Thread.Sleep(1000);
            Console.WriteLine();

            Book_Add b1 = new Book_Add();
            b1.avilable_book();

            Newspaper n1 = new Newspaper();
            n1.available_news();

            Borrower user = new Borrower();
            user.available_Details();

            do
            {
                Console.WriteLine(String.Format("{0,20}", "Menu"));
                Console.WriteLine(String.Format("{0,20}", "------------------------------"));
                //Console.WriteLine();
                Console.WriteLine(String.Format("{0,20}", "Who are you -"));
                Console.WriteLine(String.Format("{0,19}", "[1] LIBRARIAN"));
                Console.WriteLine(String.Format("{0,18}", "[2] BORROWER"));
                Console.WriteLine(String.Format("{0,14}", "[3] EXIT"));

                Console.WriteLine();
                Console.WriteLine("Please enter your choice -");
                c = Console.ReadLine();
                choice = int.Parse(c);

               
                if (choice == 1)
                    {
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine(String.Format("{0,20}", "------------------------------"));
                        Console.WriteLine(String.Format("{0,60}", "LIBRARIAN"));
                        Console.WriteLine(String.Format("{0,25}", "What do you want to manage today -"));
                        Console.WriteLine(String.Format("{0,15}", "1. Book"));
                        Console.WriteLine(String.Format("{0,20}", "2. Newspaper"));
                        Console.WriteLine(String.Format("{0,18}", "3. Go Back"));

                        Console.WriteLine();
                        Console.WriteLine(String.Format("Your Choice: "));
                        Libranian_choice = int.Parse(Console.ReadLine());

                        if (Libranian_choice == 1)
                        {

                            Console.WriteLine(String.Format("{0,60}", "BOOK - LIBRARY CONTROLLER"));
                            Console.WriteLine();

                            do
                            {
                                Console.WriteLine(String.Format("{0,20}", "MENU"));
                                Console.WriteLine(String.Format("{0,20}", "------------------------------"));
                                Console.WriteLine(String.Format("{0,19}", "1.Add Book"));
                                Console.WriteLine(String.Format("{0,21}", "2.View Books"));
                                Console.WriteLine(String.Format("{0,22}", "3.Search Book"));
                                Console.WriteLine(String.Format("{0,22}", "4.Remove Book"));
                                Console.WriteLine(String.Format("{0,28}", "5.Back to Main Menu"));
                                Console.WriteLine();
                                Console.WriteLine("Please enter your choice -");

                                c = Console.ReadLine();
                                choice_book = int.Parse(c);
                                Console.WriteLine();
                                
                                switch (choice_book)

                                {
                                    case 1:
                                        b1.Add();
                                        break;

                                    case 2:
                                        b1.view();
                                        break;

                                    case 3:
                                        b1.search();
                                        break;

                                    case 4:
                                        b1.delete();
                                        break;

                                    case 5:
                                        Console.WriteLine("Thank you for entering inside Book Library Controller");
                                        Console.WriteLine();
                                        break;
                                }
                            } while (choice_book != 5);
                            Console.WriteLine(String.Format("{0,20}", "------------------------------"));
                            Console.WriteLine();
                        }

                        else if (Libranian_choice == 2)
                        {

                            Console.WriteLine(String.Format("{0,70}", "NEWSPAPER - LIBRARY CONTROLLER"));
                            Console.WriteLine();

                            do
                            {
                                Console.WriteLine(String.Format("{0,20}", "MENU"));
                                Console.WriteLine(String.Format("{0,20}", "------------------------------"));
                                
                                Console.WriteLine(String.Format("{0,24}", "1.Add NEWSPAPER"));
                                Console.WriteLine(String.Format("{0,29}", "2.View All NEWSPAPER"));
                                Console.WriteLine(String.Format("{0,27}", "3.Search NEWSPAPER"));
                                Console.WriteLine(String.Format("{0,27}", "4.Remove NEWSPAPER"));
                                Console.WriteLine(String.Format("{0,28}", "5.Back to Main Menu"));
                                Console.WriteLine();
                                Console.WriteLine("Please enter your choice -");

                                choice_news = int.Parse(Console.ReadLine());
                              
                                Console.WriteLine();
                                
                                switch (choice_news)

                                {
                                    case 1:
                                        n1.Add();
                                        break;

                                    case 2:
                                        n1.view();
                                       
                                        break;

                                    case 3:
                                        n1.search();
                                       
                                        break;
                                        
                                    case 4:
                                        n1.delete();
                                        break;

                                    case 5:
                                        Console.WriteLine("Thank you for entering inside Newspaper Library Controller");
                                        Console.WriteLine();
                                        break;
                                }
                            } while (choice_news != 5);


                            Console.WriteLine(String.Format("{0,20}", "------------------------------"));
                            Console.WriteLine();
                        }
                        if (Libranian_choice != 3 && Libranian_choice != 2 && Libranian_choice != 1)
                        {
                            Console.WriteLine("\tInvalid option");
                            Console.WriteLine("Please enter Valid option.");
                            Console.WriteLine();
                            Console.WriteLine();
                        }

                    } while (Libranian_choice != 3);

                }


                    else if (choice == 2)
                    {

                            Console.WriteLine();
                            Console.WriteLine(String.Format("{0,20}", "------------------------------"));
                            Console.WriteLine(String.Format("{0,60}", "BORROWER"));
                            Console.WriteLine();

                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine(String.Format("{0,18}", "BORROWER MENU"));
                            Console.WriteLine(String.Format("{0,20}", "------------------------------"));
                            Console.WriteLine(String.Format("{0,16}", "1.Book "));
                            Console.WriteLine(String.Format("{0,20}", "2.Newspaper"));
                           // Console.WriteLine(String.Format("{0,29}", "3.View all Borrowers"));
                            Console.WriteLine(String.Format("{0,28}", "3.Back to Main Menu"));
                           
                            Console.WriteLine();
                            Console.WriteLine("What do you want to borrow  -");

                            choice_borrower = int.Parse(Console.ReadLine());

                            Console.WriteLine();

                            // Borrower user = new Borrower();
                            Book_Add borrower = new Book_Add();
                            Program program = new Program();


                            switch (choice_borrower)

                            {
                                case 1:
                                do
                                {
                                    Console.WriteLine(String.Format("{0,15}", "BOOK"));
                                    Console.WriteLine(String.Format("{0,20}", "------------------------------"));
                                    Console.WriteLine(String.Format("  {0,20}", "1.BORROW BOOK"));
                                    Console.WriteLine(String.Format("  {0,20}", "2.RETURN BOOK"));
                                    Console.WriteLine(String.Format("  {0,33}", "3.VIEW BOOK BORROWERS LIST"));
                                    Console.WriteLine(String.Format("  {0,26}", "4.Back to Main Menu"));
                                    
                                    Console.WriteLine();


                                    Console.WriteLine("Enter your choice: ");
                                    value = int.Parse(Console.ReadLine());
                                    switch (value)
                                    {
                                        case 1:
                                            b1.borrow_book();
                                            break;
                                        case 2:
                                            b1.return_book();
                                            // n1.borrow_newspaper();
                                            break;
                                        case 3:
                                            b1.Display_BBook();
                                            break;
                                        case 4:
                                            Console.WriteLine("  {0,20}","Thank you for Borrow Book");
                                                break;
                                        default:
                                            Console.WriteLine("Invalid option");
                                            break;
                                    }
                                } while (value != 4);
                                    break;


                                case 2:
                                do
                                {
                                    Console.WriteLine(String.Format("{0,20}", "NEWSPAPER"));
                                    Console.WriteLine(String.Format("{0,20}", "------------------------------"));
                                    Console.WriteLine(String.Format(" {0,25}", "1.BORROW NEWSPAPER"));
                                    Console.WriteLine(String.Format(" {0,25}", "2.RETURN NEWSPAPER"));
                                    Console.WriteLine(String.Format(" {0,37}", "3.VIEW NEWSPAPER BORROWER LIST"));
                                    Console.WriteLine(String.Format(" {0,26}", "4.Back to Main Menu"));
                                    Console.WriteLine("Enter your choice: ");
                                    value = int.Parse(Console.ReadLine());
                                    switch (value)
                                    {
                                        case 1:
                                            n1.borrow_newspaper();
                                            break;
                                        case 2:
                                            n1.return_newspaper();
                                            break;
                                        case 3:
                                            n1.Display_NewsList();
                                            break;
                                        case 4:
                                            Console.WriteLine("  {0,20}", "Thank you for Borrow Newspaper");
                                            break;
                                        default:
                                            Console.WriteLine("Invalid option");
                                            break;
                                    }
                                }while (value != 4);
                                break;

                            case 3:
                                Console.WriteLine();
                                Console.WriteLine("Thank you for Borrow");
                                Console.WriteLine();
                                break;

                            default:
                                Console.WriteLine("Invalid option");
                                break;
                        }
                        } while (choice_borrower != 3);
                    }
                if(choice!=3 && choice !=2 && choice !=1)
                {
                    Console.WriteLine("\tInvalid option");
                    Console.WriteLine("Please enter Valid option.");
                    Console.WriteLine();
                    Console.WriteLine();
                }
               
            } while (choice != 3);

            Console.WriteLine(" \t\tTHANK YOU....!");
            Console.WriteLine();
        }
      
    }
}


