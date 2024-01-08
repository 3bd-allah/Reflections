using System.Globalization;
using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {

            do
            {                
                var nameOfAssembly = typeof(Program).Assembly.GetName().Name;
                var input = $"{nameOfAssembly}.{Console.ReadLine()}";  
                object obj = null;
                try
                {
                    var enemy = Activator.CreateInstance(nameOfAssembly, input);
                    obj = enemy.Unwrap();
                }
                catch
                {
                }
                switch (obj)
                {
                    case Goon g:
                        Console.WriteLine(g);
                        break;
                    case Agar a:
                        Console.WriteLine(a);
                        break; 
                    case Pixa p:
                        Console.WriteLine(p);
                        break;
                    default:
                        Console.WriteLine("Enemy is unknown");
                        break;
                }
                    

            } while (true);
        }
    }

    class Goon
    {
        public override string ToString()
        {
            return $"{{speed: {15} health: {100} strength: {50}}}";
        }
    }


    class Agar
    {
        public override string ToString()
        {
            return $"{{speed: {20} health: {150} strength: {70}}}";
        }
    }
    class Pixa
    {
        public override string ToString()
        {
            return $"{{speed: {25} health: {200} strength: {90}}}";
        }
    }
}