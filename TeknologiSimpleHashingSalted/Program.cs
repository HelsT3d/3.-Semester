using System;
/*
 !!!DENNE OPGAVE ER LAVET AF CLAUDE CODE!!!
 Jeg skulle lige prøve og promptede med OOP principper, løs kobling og flere programmerings principper
 med best practice
 
 
 */
// Program afhænger kun af interfacet (løs kobling)
ISaltedHasher hasher = new SaltedHasher(new Random());

Console.Write("Indtast password: ");
string password = Console.ReadLine() ?? "";
Console.WriteLine(hasher.GetSaltedHashValue(password));

// Abstraktion: beskriver HVAD, ikke HVORDAN
public interface ISaltedHasher
{
    string GetSaltedHashValue(string password);
}

// Implementering: ét ansvar – salte og hashe et password
public class SaltedHasher : ISaltedHasher
{
    private readonly Random _random;

    // Dependency injection: Random gives udefra (kan erstattes i test)
    public SaltedHasher(Random random) => _random = random;

    public string GetSaltedHashValue(string password)
    {
        string salt = CreateSalt();
        return $"{ComputeHash(password + salt)}:{salt}";
    }

    // Tilfældigt salt på 3-5 små bogstaver
    private string CreateSalt()
    {
        int length = _random.Next(3, 6);
        string salt = "";
        for (int i = 0; i < length; i++)
            salt += (char)_random.Next('a', 'z' + 1);
        return salt;
    }

    // Hash-værdi mellem 0 og 99
    private static int ComputeHash(string text)
    {
        int hash = 0;
        foreach (char c in text)
            hash = (hash * 31 + c) % 100;
        return hash;
    }
}