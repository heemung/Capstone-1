using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            bool userContinue = true, userCheckInput = true;

            Console.WriteLine("Welcome to the Pig Latin Translator!\n");

            while (userContinue)
            {
                while (userCheckInput == true)
                {
                    Console.WriteLine("Enter a line to be translated:");
                    toBeTranslated = Console.ReadLine();

                    if (toBeTranslated != "")
                    {
                        userCheckInput = false;
                    }
                }
                    TestWordVowel(toBeTranslated);
                    old(positionOfVowel);

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
                    Console.WriteLine("first vowel is at position {0}", positionOfVowel);
                    break;
                }

                positionOfVowel = positionOfVowel + 1;
            }
        }

        /*static string BuildSentance()
        {
            vowels[i];
        }*/

        static void old(int tempStore)
        {
            int g = toBeTranslated.Length - tempStore;

            string firstLetters = toBeTranslated.Substring(0, tempStore);

            if(tempStore == 0)
            {
                Console.WriteLine("Sub String1: " + toBeTranslated.Substring(tempStore, g)
                + firstLetters + "way");
            }
            else
            {
                Console.WriteLine("Sub String1: " + toBeTranslated.Substring(tempStore, g)
                        + firstLetters + "ay");
            }

        }
    }
}
