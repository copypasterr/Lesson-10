using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson9Text
{
    internal class Program
    {
        static string isNumber(string researchString)
        {
            char Spliter = ',';
            string pattern = @"[0-9]";
            Regex currencyRegex = new Regex(pattern);


            string[] splt = researchString.Split(Spliter);
            for (int i = 0; i < splt.Length; i++)
            {
                if (currencyRegex.IsMatch(splt[i]))
                {
                    return splt[i];
                }
            }

            return null;
        }

        static string isSurname(string researchString)
        {
            char Spliter = ',';
            string pattern = @"[a-zA-Z]";
            Regex currencyRegex = new Regex(pattern);


            string[] splt = researchString.Split(Spliter);
            if (currencyRegex.IsMatch(splt[0]))
            {
                return splt[0];
            }

            return null;
        }

        static string isName(string researchString)
        {
            char Spliter = ',';
            string pattern = @"[a-zA-Z]";
            Regex currencyRegex = new Regex(pattern);

            string[] splt = researchString.Split(Spliter);
            if (currencyRegex.IsMatch(splt[1]))
            {
                return splt[1];
            }

            return null;
        }


        static string StringSearch(string Allfile, string Keyword, char SplitSymbol)
        {
            try
            {
                if (Keyword.Length < 3) throw new ArgumentException("Less than 3 symbols");
                string[] splt = Allfile.Split(SplitSymbol);


                for (int i = 0; i < splt.Length; i++)
                {
                    if (splt[i].Contains(Keyword))
                    {
                        return splt[i];
                    }
                }
            }

            catch (ArgumentException)
            {
                Console.WriteLine("Less than 3 symbols");
            }

            catch (FormatException)
            {
                Console.WriteLine("Format Exception error");
            }

            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Out of range");
            }

            return null;
        }


        static int countLines(string Allfile)
        {
            int count = 0;

            char SplitSymbol = '\r';

            string[] splt = Allfile.Split(SplitSymbol);

            for (int i = 0; i < splt.Length; i++)
            {
                if (splt[i].Contains(SplitSymbol)) count++;
            }

            return count;
        }

        static void Sorter(string AllFile)
        {

            int ArraySize = countLines(AllFile);
            char SplitSymbol = '\r';

            string[] splt = AllFile.Split(SplitSymbol);
            string[] sortingitem = new string[splt.Length];

            for (int i = 0; i < splt.Length; i++)
            {
                if (!string.IsNullOrEmpty(splt[i]))
                {
                    sortingitem[i] = isSurname(splt[i]);

                    Console.WriteLine(sortingitem[i]);
                }
            }
            Array.Sort(splt);

            foreach (var item in splt)
            {
                Console.WriteLine(item);
            }
        }



        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter searching name, surname or phone number");
                string path = "TextFile1.txt";
                string lines = File.ReadAllText(path);
                char Spliter = '\r';
                string SearchingName = Console.ReadLine();
                Console.WriteLine(StringSearch(lines, SearchingName, Spliter));
            }

            catch (FormatException)
            {
                Console.WriteLine("Format Exception error");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }


            //Sorter(lines);



        }
    }
}
