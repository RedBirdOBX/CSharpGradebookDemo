﻿using System;

namespace Gradebook.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //System.Console.Clear();
            System.Console.WriteLine("GradeBook Program:");
            System.Console.Write("Provide the grade book name: ");

            // build the gradebook
            //string bookName = Console.ReadLine();
            string bookName = "foobar";
            
            var book = new Book(bookName);

            // add the grades
            string grade = string.Empty;
            ConsoleKeyInfo action;
            do
            {
                System.Console.Write("Enter a grade: ");
                //grade = Console.ReadLine();
                grade= "ddd";

                try
                {
                    book.AddGrade(grade);
                }
                catch (System.ArgumentException ex)
                {
                    //throw ex;
                    Console.WriteLine(ex);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine($"** {grade} added **");

                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine("Press any key to continue or Q to quit.");
                action = Console.ReadKey();
                Console.ResetColor();
                Console.WriteLine();
            }
            while (!action.KeyChar.Equals('Q') && !action.KeyChar.Equals('q'));

            var statistics = book.GetStatistics();
            Console.WriteLine("");
            Console.WriteLine("STATISTICS");
            System.Console.WriteLine($"There are {book.Grades.Count} grades in {book.BookName}.");
            System.Console.WriteLine($"The avg grade is {statistics.Average}.");
            System.Console.WriteLine($"Lowest is {statistics.Lowest}.");
            System.Console.WriteLine($"Highest is {statistics.Highest}.");
            System.Console.WriteLine($"Letter grade is {statistics.Letter}.");
            Console.WriteLine("");
        }
    }
}
