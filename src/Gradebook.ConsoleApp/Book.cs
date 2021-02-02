using System.Collections.Generic;
using System.Linq;
using System;

namespace Gradebook.ConsoleApp
{
    public class Book
    {
        // constructor
        public Book(string bookName)
        {
            Grades = new List<double>();
            BookName = bookName;
        }


        // props
        public List<double> Grades { get; set; }

        public string BookName { get; set; }


        // methods
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);
            }
            else
            {
                System.Console.WriteLine("Invalid grade.");
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(100);
                    break;
                case 'B':
                    AddGrade(89);
                    break;
                case 'C':
                    AddGrade(79);
                    break;
                case 'D':
                    AddGrade(69);
                    break;
                case 'F':
                    AddGrade(59);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public BookStatistics GetStatistics()
        {
            // avg results
            double total = 0;
            double avg = 0;
            double minGrade = Grades.Min();
            double maxGrade = Grades.Max();
            var results = new BookStatistics();

            foreach (double grade in Grades)
            {
                total += grade;
            }
            avg = (total / Grades.Count);

            results.Average = avg;
            results.Highest = maxGrade;
            results.Lowest = minGrade;

            switch (avg)
            {
                case var d when d >= 90.0:
                    results.Letter = 'A';
                    break;

                case var d when d <= 89.9 && d >= 80.0:
                    results.Letter = 'B';
                    break;

                case var d when d <= 79.9 && d >= 70.0:
                    results.Letter = 'C';
                    break;

                case var d when d <= 69.9 && d >= 60.0:
                    results.Letter = 'D';
                    break;

                case var d when d <= 59.9:
                    results.Letter = 'F';
                    break;
            }

            return results;
        }
    }
}