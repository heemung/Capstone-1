using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            string vowels = "aeiou";
            char vow, word;
            string question = "Heather";
            int tempStore = 0;
            bool exitLoop = false;
            //StringBuilder quests = new StringBuilder(question);
            //StringBuilder tempVowels = new StringBuilder(vowels);

            for (int v = 0; v < question.Length; v++)
            {

                word = question[v];

                for (int i = 0; i < vowels.Length; i++)
                {
                    vow = vowels[i];
                    if (vow.Equals(word) == true)
                    {
                        exitLoop = true;
                        break;
                    }

                }

                if (exitLoop == true)
                    break;

                tempStore = tempStore + 1;

            }

            Console.WriteLine("first vowel is at position {0}", tempStore);

            int g = question.Length - tempStore;

            string firstLetters = question.Substring(0, tempStore);

            // retrieve the substring from index 0 to length 8
            Console.WriteLine("Sub String1: " + question.Substring(tempStore,g) 
                + firstLetters + "ay");

            // retrieve the substring from index 5 to length 3

            Console.ReadLine();
            // Output: How does Microsoft Word deal with the Caps Lock key?       
        }
    }
}
