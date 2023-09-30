using System;
namespace AlgorithmTest.CipherAlgorithm
{
	public class HashCipher
	{
		public HashCipher()
		{
		}

        //Метод генерації масиву пар (ключі - значення)
        public KeyValuePair<char, long>[] Generate()
        {
            Random random = new Random();

            KeyValuePair<char, long>[] keyValuePair = new KeyValuePair<char, long>[52];
            int index = 0;

            for (char i = 'A'; i <= 'Z'; i++)
            {
                char sym = i;

                long hash = random.Next();

                keyValuePair[index] = new KeyValuePair<char, long>(sym, hash);

                index++;
            }

            for (char i = 'a'; i <= 'z'; i++)
            {
                char sym = i;

                long hash = random.Next();

                keyValuePair[index] = new KeyValuePair<char, long>(sym, hash);

                index++;
            }

            return keyValuePair;
        }

    }
}

