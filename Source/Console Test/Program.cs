using Libraries;

namespace Console_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Library.ValidateIPAddress("222.111.111.111"));
            Console.WriteLine(Library.ValidateIPAddress("5555..555"));
        }
    }
}