using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week_1_Capstone
{
    class Program
    {
        const string vowels = "aeiou";
        const string capVowels = "AEIOU"; 
        static int positionOfVowel;
        static string masterString;
        static char vow, word, capVow;
        static bool exitLoop;
        static string toBeTranslated;

        static void Main(string[] args)
        {
            bool userContinue = true, userCheckInput;


            Console.WriteLine("Welcome to the Pig Latin Translator!\n");

            while (userContinue)
            {
                masterString = "";
                userCheckInput = true;
                while (userCheckInput)
                {
                    Console.WriteLine("Enter a line to be translated:");
                    toBeTranslated = Console.ReadLine();

                    if (toBeTranslated != "")
                    {
                        userCheckInput = false;
                    }
                }

                    BuildSentance(toBeTranslated);
                    Console.WriteLine(masterString);
                    Console.WriteLine("Do you wish to Continue? y/n?");
                    userContinue = Console.ReadLine().ToLower() == "y";
                
            }
        }

        static void TestWordVowel(string eachWord)
        {
            exitLoop = false;
            positionOfVowel = 0;

            for (int v = 0; v < eachWord.Length; v++)
            {
                word = eachWord[v];

                for (int i = 0; i < vowels.Length; i++)
                    {
                        vow = vowels[i];
                        capVow = capVowels[i];
                    if ((vow.Equals(word) == true) || (capVow.Equals(word) == true))
                        {
                            exitLoop = true;
                            break;
                        }
                    }

                if (exitLoop == true)
                {
                    //Console.WriteLine("Letters to be moved {0}", positionOfVowel);
                    break;
                }

                positionOfVowel = positionOfVowel + 1;
            }
        }

        static void BuildSentance(string userInput)
        {
            //clean up sentence using

           // string[] result =
            //Regex.Matches(userInput, @"[?!.,]").Cast<Match>().Select(m => m.Value).ToArray();
            string[] splits = userInput.Split(' ');
            foreach (string x in splits)
            {
                TestWordVowel(x);
                masterString += old(positionOfVowel, x) + " ";

            }

        }

        /*static string testMethod()
        {
            if (s.Length > 0)
                return s[s.Length - 1] + RecursivelyReverseString(s.Substring(0, s.Length - 1));
            else
                return s;
        }*/
        static string old(int tempStore, string tempWord)
        {
            int g = tempWord.Length - tempStore;

            string firstLetters = tempWord.Substring(0, tempStore);

            if(tempWord.All(char.IsDigit))
            {
                return tempWord;
            }
            else if (tempWord.Contains('@') || tempWord.Contains('.') ||
                tempWord.Contains('?') || tempWord.Contains('!'))
            {
                return tempWord;
            }
            else if(tempStore == 0)
            {
                tempWord = tempWord.Substring(tempStore, g) + firstLetters + "way";
                //Console.WriteLine(tempWord);
                return tempWord;
            }
            else
            {
                tempWord = tempWord.Substring(tempStore, g) + firstLetters + "ay";

                //Console.WriteLine(tempWord);
                return tempWord;
            }

        }
    }
}
