using System.Security.Cryptography.X509Certificates;

namespace TeknologiHashing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int shift = 23;
            string text;

            Console.Write("Indtast string: ");
            text = Console.ReadLine();

            int[] textShifted = new int[text.Length];

            int i = 0;

            foreach (char c in text)
            {
                int index = (int)c % 32;

                textShifted[i] = index + shift;

                i++;
            }

            foreach (int l in textShifted)
            {
                Console.Write($"{l}, ");
            }

        }
    }
}
