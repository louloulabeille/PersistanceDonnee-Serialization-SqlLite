using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDEnvironnement
{
    internal class Program
    {
        // class environnement de C# pour avoir les chemins de l'environnement du systeme d'exploitation
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            Console.WriteLine(Environment.MachineName);
            Console.WriteLine(Environment.Version);
            Console.WriteLine(Environment.CurrentManagedThreadId);
            Console.WriteLine(Environment.Is64BitOperatingSystem);

            Console.ReadLine();
        }
    }
}
