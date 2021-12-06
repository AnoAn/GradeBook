using System;

namespace GradeBook //define same namespace
{
    public class Book //define class
    {
        public Book(string name) //defines init behavior
        {
            grades = new List<double>();
            Name = name; //this = python self
        }
        public void AddGrade(double grade) //a method
        {
            if(grade <=100 && grade >0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
                //Console.WriteLine("Invalid value");
            }
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case('A'): AddGrade(90); break;
                case('B'): AddGrade(80); break;
                case('C'): AddGrade(70); break;

                default: AddGrade(0); break;
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(double grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                
                default:
                    result.Letter = 'F';
                    break;
            }
            
            return result;
        }
        //istantiate private variables
        public List<double> grades;
        public string Name; //convention: public variables are uppercase
    }
}
