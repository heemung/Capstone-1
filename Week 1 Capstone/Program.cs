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
                    break;
                }

                positionOfVowel = positionOfVowel + 1;
            }
        }


        static void BuildSentance(string userInput)
        {
            string[] splits = userInput.Split(' ');
            foreach (string x in splits)
            {
                TestWordVowel(x);
                masterString += WordArguments(positionOfVowel, x) + " ";
            }
        }


        static string WordArguments(int vowPosition, string tempWord)
        {
            string[] punctuation = { ".", ",", "!", "?", ":" };
            int letterDifference = tempWord.Length - vowPosition;


            string firstLetters = tempWord.Substring(0, vowPosition);

            if(tempWord.All(char.IsDigit) || tempWord.Contains('@'))
            {
                return tempWord;
            }
            else if (punctuation.Any(s => tempWord.EndsWith(s)))
            {
                int grabPunctuationNum = tempWord.Length - 1;
                string punctuation1 = tempWord.Substring(grabPunctuationNum, 1);

                if(vowPosition == 0)
                {
                    tempWord = tempWord.Substring(vowPosition, 
                    letterDifference - 1) + firstLetters + "way" + punctuation1;
                    return tempWord;
                }
                else
                {
                    tempWord = tempWord.Substring(vowPosition, 
                    letterDifference - 1) + firstLetters + "ay" + punctuation1;
                    return tempWord;
                }
            }
            else if(vowPosition == 0)
            {
                tempWord = tempWord.Substring(vowPosition, 
                    letterDifference) + firstLetters + "way";
                return tempWord;
            }
            else if(vowPosition > 0)
            {
                tempWord = tempWord.Substring(vowPosition, 
                    letterDifference) + firstLetters + "ay";
                return tempWord;
            }
            else
            {
                return tempWord;
            }

        }
    }
}
