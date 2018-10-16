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
        //inintating for to be used in methods
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

            //yes or no continue loop
            while (userContinue)
            {
                masterString = "";
                userCheckInput = true;

                //loop to check for input
                while (userCheckInput)
                {
                    Console.WriteLine("Enter a line to be translated:");
                    toBeTranslated = Console.ReadLine();

                    if (toBeTranslated != "")
                    {
                        userCheckInput = false;
                    }
                }
                    //Calls method passes string and writes masterstring
                    BuildSentance(toBeTranslated);
                    Console.WriteLine(masterString);
                    Console.WriteLine("Do you wish to Continue? y/n?");
                    userContinue = Console.ReadLine().ToLower() == "y";
                
            }
        }

        //method to check where the position of the vowel is.
        static void TestWordVowel(string eachWord)
        {
            exitLoop = false;
            positionOfVowel = 0;

            //for loop to non vowel
            for (int v = 0; v < eachWord.Length; v++)
            {
                word = eachWord[v];

                //for loop for vowel
                for (int i = 0; i < vowels.Length; i++)
                    {
                        vow = vowels[i];
                        capVow = capVowels[i];
                    //tests all vowels againt 1 conts then loops
                   //breaks out of loop if true
                    if ((vow.Equals(word) == true) || (capVow.Equals(word) == true))
                        {
                            exitLoop = true;
                            break;
                        }
                    }
                //breaks out of 2nd loop if true
                if (exitLoop == true)
                {
                    break;
                }
                //each time loop runs the position of the vowel is +1
                positionOfVowel = positionOfVowel + 1;
            }
        }

        //takes a line of strings and puts them into arrays to be tested then builds
        //masterstring word by word
        static void BuildSentance(string userInput)
        {
            string[] splits = userInput.Split(' ');
            foreach (string x in splits)
            {
                TestWordVowel(x);
                masterString += WordArguments(positionOfVowel, x) + " ";
            }
        }

        //Edits each word takes in vow position from loop and current word
        static string WordArguments(int vowPosition, string tempWord)
        {
            //string array for punctuation to be tested
            string[] punctuation = { ".", ",", "!", "?", ":" };
            //grabing the new length of the word - the ammount to be taken off
            int letterDifference = tempWord.Length - vowPosition;

            //stores the ammount taken off into new string
            string firstLetters = tempWord.Substring(0, vowPosition);

            //if else statments tetst for all challenges and puts way and ay based
            //if vowel is first or not

            //if the whole word is digit or contains @ will return normal word
            if(tempWord.All(char.IsDigit) || tempWord.Contains('@'))
            {
                return tempWord;
            }
            //compares an array of punctuation to the end of the string then stores
            //punucation in string . Next tests for vowel 1st or not then adds the string 
            //back together
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
            //Main test. if there is a vowel on the first letter add way 
            else if(vowPosition == 0)
            {
                tempWord = tempWord.Substring(vowPosition, 
                    letterDifference) + firstLetters + "way";
                return tempWord;
            }
            //Main test. if there is not a vow on the first letter add ay
            else if (vowPosition > 0)
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
