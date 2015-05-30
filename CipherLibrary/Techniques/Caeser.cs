using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CipherLibrary.Base;

namespace CipherLibrary.Techniques
{
    public class Caeser : IEncryptionAlgorithm
    {
        readonly int key;
        public readonly static char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'I', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public  string Encrypt(string textMessage)
        {
            return Encrypt(textMessage,3);
        }

        public string Encrypt(string textMessage,int addend)
        {
            string result = string.Empty;
            foreach (char c in textMessage)
            {
                int charposition = indexOfChar(alphabet, c);
                int res = charposition + addend;

                if (charposition < 0)
                    result += c;
                else result += alphabet[res % alphabet.Length];

            }
            return result;
        }

        public  string Decrypt(string textMessage)
        {
            string result = string.Empty;
            foreach (char c in textMessage)
            {
                int charposition = indexOfChar(alphabet, c);
                int res = charposition - 3;

                if (charposition < 0)
                    result += c;
                else result += alphabet[res % alphabet.Length];
            } return result;
        }

        private int indexOfChar(char[] array, char given)
        {
            int index = 0, charposition = -1;
            char current;
            while (index < array.Length && charposition < 0)
            {
                current = array[index];
                if (array[index] == given)
                    charposition = index;
                index++;
            }
            return charposition;
        }

    }
}
