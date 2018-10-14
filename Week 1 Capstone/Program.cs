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
        static int tempStore;
        static masterString;
        static char vow, word, capVow, capWord;
        static bool exitLoop;
        static string toBeTranslated;

        static void Main(string[] args)
        {

            bool userContinue = true;

            while (userContinue)
            {
                Console.WriteLine("Welcome to the Pig Latin Translator!\nEnter a line to be translated:");
                toBeTranslated = Console.ReadLine();

                userContinue = Console.ReadLine().ToLower() == "y";

            }



        }

        static void TestWordVowel(string eachWord)
        {
            exitLoop = false;
            tempStore = 0;

            for (int v = 0; v < eachWord.Length; v++)
            {
                word = eachWord[v];
                capWord = eachWord[v];

                for (int i = 0; i < vowels.Length; i++)
                    {
                        vow = vowels[i];
                        capVow = vowels[i];
                    if (vow.Equals(word) == true || capVow.Equals(capWord) == true)
                        {
                            exitLoop = true;
                            break;
                        }
                    }

                if (exitLoop == true)
                {
                    Console.WriteLine("first vowel is at position {0}", tempStore);
                    break;
                }

                tempStore = tempStore + 1;
            }
        }

        static string BuildSentance()
        {
            vowels[i];
        }

        static string old()
        {
            int g = toBeTranslated.Length - tempStore;

            string firstLetters = toBeTranslated.Substring(0, tempStore);

            // retrieve the substring from index 0 to length 8
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
