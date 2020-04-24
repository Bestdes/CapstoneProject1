using System;
using System.Globalization;
using System.Text;

namespace PigLatin
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Boolean runProgram = true;

            while (runProgram)
            {
            Console.WriteLine("Welcome to the Pig Latin Language Translator");
            Console.WriteLine("Please enter a phrase that you want converted.");

            string input = Console.ReadLine();

                if (input != "")
                {

                    if (!CheckIfStringContainsNum(input))
                    {
                        StringBuilder finalStringBuild = new StringBuilder();

                        foreach (string separatedWord in SplitToStringArray(input))
                        {
                            finalStringBuild.AppendFormat("{0} ", ChangeBackToCase(separatedWord, transformIntoPLatin(separatedWord)));

                        }
                        Console.WriteLine(finalStringBuild);
                        runProgram = CheckIfProgramShouldReRun();
                    }
                    else
                    {
                        Console.WriteLine("You enter a word that contains a number character. Please try again using only alphabetical characters.");
                    }
                }
                else
                {
                    Console.WriteLine("It seems that no text was entered, please try again.");
                }
            }

        }

        public static string transformIntoPLatin(string toBeTranslated)
        {
            toBeTranslated = toBeTranslated.ToLower();

            if (CheckIf1stLetterVowel(toBeTranslated))
            {
                toBeTranslated = toBeTranslated + "way";
            }
            else
            {
                while (!CheckIf1stLetterVowel(toBeTranslated))
                {
                    string convertedWord = toBeTranslated.Substring(1).Insert(toBeTranslated.Length - 1, toBeTranslated.Substring(0, 1));
                    toBeTranslated = convertedWord;


                    if (CheckIf1stLetterVowel(toBeTranslated))
                    {
                        toBeTranslated = toBeTranslated + "ay";
                    }
                }
            }
                return toBeTranslated;
            
        }

        public static Boolean CheckIf1stLetterVowel(string checkedWord)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

                foreach (char testedChar in vowels)
                {
                    if (checkedWord.StartsWith(testedChar))
                    {
                    return true;
                    }
                }
            return false;
        }

        public static string ChangeBackToCase(string originalText, string pigLatinTranslation)
        {
            char[] OriginalArray = originalText.ToCharArray();
            int counterUpper = 0;
            char testingChar = '0';

            // Creates a TextInfo based on the "en-US" culture.
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            // Need to revist to figure out why end condition had to be extended to OriginalArray.Length from 3
            for (int i = 0; i < OriginalArray.Length; i++)
            {
                testingChar = OriginalArray[i];

                if (Char.IsUpper(testingChar))
                {
                    counterUpper++;
                }
            }

            if (counterUpper == 1)
            {
                pigLatinTranslation = myTI.ToTitleCase(pigLatinTranslation);
                return pigLatinTranslation;
            }
            else if (counterUpper >= 2)
            {
                pigLatinTranslation = pigLatinTranslation.ToUpper();
                return pigLatinTranslation;
            }
            else
            {
                return pigLatinTranslation;
            }
        }

        public static Boolean CheckIfProgramShouldReRun()
        {
            Boolean askRerun = true;

            while (askRerun)
            {
            Console.WriteLine("Do you want run the Pig Latin Converter Again? (y/n)");
            string reRunInput = Console.ReadLine();

                if(reRunInput == "y")
                {
                    askRerun = false;
                }
                else if (reRunInput == "n")
                {
                    Console.WriteLine("Thank you for using the Pig Latin Converter. Have nice day!");
                    askRerun = false;
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please input y for yes or n for no.");
                }
            }
            return true;
        }

        public static Boolean CheckIfStringContainsNum(string toBeChecked)
        {
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] checkedChars = toBeChecked.ToCharArray();

            foreach (char testedNum in numbers)
            {
                foreach(char testedChar in checkedChars)
                {
                    if(testedChar == testedNum)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string[] SplitToStringArray(string toBeSplit)
        {
            string[] splitWords = toBeSplit.Split(null);

            return splitWords;
        }
    }
}
