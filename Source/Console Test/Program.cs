using Libraries;

namespace Console_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Library.IsValidCharacters("12345"));
            Console.WriteLine(Library.IsValidCharacters("123¤bc"));
            Console.WriteLine(Library.IsValidCharacters("no183h_+`3T#@t23T@#T"));
            Console.WriteLine(Library.IsValidCharacters("kl0k0`~g3pokgo😉"));
        }
    }
}