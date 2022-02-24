using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pig_Latin.Models
{
    public class TranslatePigLatin
    {
        private string ToIntialCap(string word)
        {
            string firstLetter = word.Substring(0, 1).ToUpper();
            string otherLetters = word.Substring(1).ToLower();
            return firstLetter + otherLetters;
        }

        private bool IsLower(char c)
        {
            if (c >= 97 && c <=122 || c.ToString() == "'")
                return true;
            else
                return false;
        }

        private bool IsUpper(char c)
        {
            if (c >= 65 && c <= 90 || c.ToString() == "'")
                return true;
            else
                return false;
        }

        private bool IsIntialCap(string word)
        {
            char firstLetter = word[0];
            string otherLetters = word.Remove(0, 1);

            if (IsUpper(firstLetter) && IsLower(otherLetters))
                return true;
            else
                return false;
   
        }

        private bool IsLower(string word)
        {
            for (int i =0; i < word.Length; i++)
                if(IsLower(word[i]) ==false)
                    return false;
            return true;
        }

        private bool IsUpper(string word)
        {
            for (int i = 0; i < word.Length; i++)
                if (IsUpper(word[i]) == false)
                    return false;
            return true;
        }

        private string TranslateWord(string word)
        {
            char c = word[0];

            if (c == 'a' || c == 'e' || c == 'i' || 
                c == 'o' || c == 'u' || 
                c == 'A' || c == 'E' || c == 'I' || 
                c == 'O' || c == 'U')
            {
                word += "way";

            }
            else
            {
                if(c == 'y' || c == 'Y')
                {
                    word = word.Remove(0, 1);
                    word += c.ToString();
                     c= word[0];
                }

                int i =0;
                while((c != 'a' && c != 'e' && c != 'i' &&
                c != 'o' && c != 'u' &&
                c != 'A' && c != 'E' && c != 'I' &&
                c != 'O' && c != 'U' && 
                c != 'y' && c!= 'Y') && i < word.Length)
                {
                    word = word.Remove(0, 1);
                    word += c.ToString();
                    c = word[0];
                    i++;
                }

                if (c == 'a' || c == 'e' || c == 'i' ||
                c == 'o' || c == 'u' ||
                c == 'A' || c == 'E' || c == 'I' ||
                c == 'O' || c == 'U')
                {
                    word += "ay";

                }
            }
            return word;
        }
        private string TranslateWordWithCaps(string word)
        {
            string punct = "";

            if(word.EndsWith("."))
            {
                word = word.Remove(word.Length - 1, 1);
                punct = ".";
            }
            if (word.EndsWith(","))
            {
                word = word.Remove(word.Length - 1, 1);
                punct = ",";
            }
            if (word.EndsWith(";"))
            {
                word = word.Remove(word.Length - 1, 1);
                punct = ";";

            }
            if (word.EndsWith(":"))
            {
                word = word.Remove(word.Length - 1, 1);
                punct = ":";
            }
            if (word.EndsWith("!"))
            {
                word = word.Remove(word.Length - 1, 1);
                punct = "!";

            }
            if (word.EndsWith("?"))
            {
                word = word.Remove(word.Length - 1, 1);
                punct = "?";
            }

            if(IsIntialCap(word))
                word = ToIntialCap(TranslateWord(word));
            if(IsUpper(word))
                word = TranslateWord(word).ToUpper();
            if(IsLower(word))
                word= TranslateWord(word).ToLower();

            word += punct;

            return word;
        }
        public string Translate(string english)
        {
            string[] words = english.Trim().Split(' ');
            string pigLatin = "";

            foreach (string word in words)
                pigLatin += TranslateWordWithCaps(word) + " ";

            return pigLatin;
        }

    }
}