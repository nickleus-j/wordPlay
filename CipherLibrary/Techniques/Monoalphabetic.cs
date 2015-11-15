using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherLibrary.Techniques
{
    public class Monoalphabetic
    {
        readonly int key;
        readonly Dictionary<char, char> _alphabetShuffled;
        readonly Dictionary<char, char> _alphabetShuffledReverse;
        public readonly static char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public Monoalphabetic()
        {
            _alphabetShuffledReverse = new Dictionary<char, char>();
            _alphabetShuffled = new Dictionary<char, char>();
            ShuffleAlphabet();
        }

        private static T[] Shuffle<T>(T[] OriginalArray)
        {
            var matrix = new SortedList();
            var r = new Random();

            for (var x = 0; x <= OriginalArray.GetUpperBound(0); x++)
            {
                var i = r.Next();

                while (matrix.ContainsKey(i)) { i = r.Next(); }

                matrix.Add(i, OriginalArray[x]);
            }

            var OutputArray = new T[OriginalArray.Length];

            matrix.Values.CopyTo(OutputArray, 0);

            return OutputArray;
        }

        public string Encrypt(string textMessage)
        {
            return Encrypt(textMessage, 3);
        }

        public string Encrypt(string textMessage, int addend)
        {
            string result = "";
            for (int i = 0; i < textMessage.Length; i++)
            {
                if (indexOfChar(alphabet, textMessage[i]) >= 0)
                    result += _alphabetShuffled[textMessage[i]];
                else result += textMessage[i];
            }
            
            return result;
        }

        public string Decrypt(string textMessage)
        {
            string result = "";
            for (int i = 0; i < textMessage.Length; i++)
            {
                if (indexOfChar(alphabet, textMessage[i]) >= 0)
                    result += _alphabetShuffledReverse[textMessage[i]];
                else
                    result += textMessage[i];
            }

            return result;
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
        private void ShuffleAlphabet()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            var alphabetCopy = alphabet.ToList();
            foreach (var character in alphabet)
            {
                int characterPosition = r.Next(0, alphabetCopy.Count());
                char randomCharacter = alphabetCopy[characterPosition];
                _alphabetShuffled.Add(character, randomCharacter);
                _alphabetShuffledReverse.Add(randomCharacter, character);
                alphabetCopy.RemoveAt(characterPosition);
            }
        }
    }
}
