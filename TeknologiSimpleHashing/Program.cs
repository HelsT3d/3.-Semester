namespace TeknologiSimpleHashing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Indtast dit kodeord:");
            string password = Console.ReadLine();
            Console.WriteLine(GetHashValue(password));

        }
        public static int GetHashValue(string password)
        {
            int encryptedCode = 0;
            int index = 100;
            for (int i = 0; i < password.Length; i++)
            {
                encryptedCode += password[i];
            }
            while (encryptedCode >= index)
                {
                    encryptedCode -= index;
                }
            
            return encryptedCode;

        }

    }
}
