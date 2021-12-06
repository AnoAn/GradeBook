// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Ano's notebook");
            /*book.AddGrade(58.2);
            book.AddGrade(12.5);
            book.AddGrade(84.6);*/
            
            /*List<double> grades = new List<double>() {34.2, 10.3, 6.11, 4.1};
            grades.Add(15.2);*/

            while(true)
            {
                Console.WriteLine("Enter a grade or press 'q' to quit & compute stats");
                var input = Console.ReadLine();
                if(input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);    
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**"); // runs regardless of try/catch
                }
                
            }


            var stats = book.GetStatistics();

            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

    }
}