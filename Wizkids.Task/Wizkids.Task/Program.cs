using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wizkids.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            var a = ReplaceValidEmail("i am asw@gmail.com     and i ");
            //Task 1: Write a method that determines if a string is a palindrome or not.
            Console.WriteLine("Task 1: Write a method that determines if a string is a palindrome or not.");
            //Testcase 1: Check valid palindrome
            Console.WriteLine("Check valid palindrome= Input: madam, OutPut: {0}", CheckPalindrome("madam"));
            //Testcase 1: Check invalid palindrome
            Console.WriteLine("Check invalid palindrome= Input: invalidstring, OutPut: {0}", CheckPalindrome("invalidstring"));

            //Task 2: Write a method that prints the numbers from 1 to 100, but for multiples of 3 print Foo, for multiples of 5 print Bar and for numbers that are multiples of both 3 and 5 print FooBar.
            Console.WriteLine("Task 2: Write a method that prints the numbers from 1 to 100, but for multiples of 3 print Foo, for multiples of 5 print Bar and for numbers that are multiples of both 3 and 5 print FooBar.");
            Console.WriteLine("PrintNumber= Output:");
            PrintNumber(1, 100);


            //Task 3: Write a method that can find and replace valid email adresses in a string.
            Console.WriteLine("Task 3:Write a method that can find and replace valid email adresses in a string.");
            string input = @"Christian has the email address christian+123@gmail.com.
Christian's friend, John Cave-Brown, has the email address john.cave-brown@gmail.com.
John's daughter Kira studies at Oxford University and has the email adress Kira123@oxford.co.uk.
Her Twitter handle is @kira.cavebrown.";
            Console.WriteLine("ReplaceValidEmail= Input :{0}", input);
            Console.WriteLine("ReplaceValidEmail= Output :{0}", ReplaceValidEmail(input));
            Console.ReadKey();
        }

        static bool CheckPalindrome(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                    return false;
            }
            return true;
        }

        static void PrintNumber(int startRange, int endRange)
        {
            for(int i = startRange; i<=endRange; i++)
            {
                string tempResult = string.Empty;
                bool isDividedBy3 = i % 3 == 0;
                bool isDividedBy5 = i % 5 == 0;
                if (isDividedBy3 && isDividedBy5)
                   tempResult =  "FooBar";
                else if (isDividedBy3)
                    tempResult = "Foo";
                else if (isDividedBy5)
                    tempResult = "Bar";

                if (!string.IsNullOrEmpty(tempResult))
                    Console.WriteLine("{0} : {1}",i , tempResult);
            }
        }

        static string ReplaceValidEmail(string text)
        {
            var emailRegex = new Regex(
        @"^\s*[\w\-\+_']+(\.[\w\-\+_']+)*\@[A-Za-z0-9]([\w\.-]*[A-Za-z0-9])?\.[A-Za-z][A-Za-z\.]*[A-Za-z]$");
            var textArray = text.Split(' ');
            for (int i = 0; i < textArray.Length; i++)
            {
                bool hasFullStop= false;
                if(!string.IsNullOrWhiteSpace(textArray[i]) && textArray[i].Last() == '.')
                {
                    hasFullStop = true;
                    textArray[i] = textArray[i].PadRight(1);
                }
                if (emailRegex.IsMatch(textArray[i]))
                {
                    textArray[i] = "**********@****.com";
                    if(hasFullStop)
                    {
                        textArray[i] = textArray[i] + ".";
                    }
                }
            }
            
            return string.Join(" ", textArray);
        }
    }
}
