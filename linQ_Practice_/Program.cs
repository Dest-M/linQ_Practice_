using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Practice
{
    internal class Program
    {
        public delegate void br();

        static void brMethod()
        {
            Console.WriteLine("\n=============================\n");
        }

        static void display(List<string> str)
        {
            foreach (string s in str)
            {
                Console.WriteLine(s);
            }
        }
        public static void Main(string[] args)
        {
            br Br = new br(brMethod);
            List<string> Q1strings = new List<string> { "123", "2D4", "456", "ABC" };
            var q1 = Q1strings.Where(x => x.Any(Char.IsLetter) == false).ToList();
            display(q1);
            Br();

            List<int> Q2numbers = new List<int> { -2, 4, -6, 8, 10, -12 };
            var q2Min = Q2numbers.Where(x => x >= 0).Min();
            var q2Max = Q2numbers.Where(x => x >= 0).Max();
            Console.Write("Min is: " + q2Min.ToString() + "\tMax is: " + q2Max.ToString() + "\n");
            Br();

            List<string> Q3strings = new List<string> { "apple", "tomato", "pear", "apple", "apple", "tomato" };
            var q3 = Q3strings.GroupBy(s => s).Where(i => i.Count() > 1).OrderByDescending(i => i.Count()).Select(i => i.Key).Take(1).ToList();
            Console.Write("Most common: ");
            foreach (var a in q3)
            {
                Console.Write(a.ToString() + "\n");
            }
            Br();

            List<string> Q4strings = new List<string> { "aaa", "aaaaa", "cc", "bbb", "ccccc", "bb", "bbbbb", "ccc", "aa" };
            var q4 = Q4strings.OrderByDescending(a => a.Length).ThenBy(a => a.First()).ToList();
            display(q4);
            Br();

            List<DateTime> dates = new List<DateTime> { new DateTime(2022, 1, 1), new DateTime(2022, 3, 15), new DateTime(2022, 2, 10) };
            var dayDifference = dates.Max().Subtract(dates.Min());
            Console.WriteLine(dayDifference.ToString("dd"));
            Br();
        }
    }
}   