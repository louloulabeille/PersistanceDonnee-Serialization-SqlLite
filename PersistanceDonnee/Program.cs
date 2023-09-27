using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceDonnee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string chemin = @"D:\data\test.txt";

            // creation du fichier et écriture
            /*using ( StreamWriter sw = new StreamWriter(chemin) )
            {
                sw.WriteLine("texte");
            }
            */

            // ouverture du fichier et écriture
            /*using (StreamWriter sw = File.AppendText(chemin))
            {
                sw.WriteLine("coucou");
            }*/

            // lecture du fichier et lecture ligne par ligne
            /*using (StreamReader sr = new StreamReader(chemin))
            {
                string line = null;
                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
            }*/


            // ouverture du fichier et lecture du fichier en entier
            /*using (StreamReader sr = new StreamReader(chemin))
            {
                string ligne = sr.ReadToEnd();
                Console.WriteLine(ligne);
            }*/

            try
            {
                Console.WriteLine(chemin.Substring(0, chemin.LastIndexOf("\\")));
                if (!Directory.Exists(chemin.Substring(0, chemin.LastIndexOf("\\") + 1)))
                {
                    Directory.CreateDirectory(chemin.Substring(0, chemin.LastIndexOf("\\") + 1));
                }

                if ( !File.Exists(chemin) )
                {
                    using (File.Create(chemin)) { }

                    // ouverture du flux d'écriture dans le fichier
                    using (StreamWriter sw = new StreamWriter(chemin))
                    {
                        sw.WriteLine("Coucou");
                        sw.WriteLine("je suis une crevette, pouquoi je ne sais pas.");
                        sw.WriteLine("et j'aime les frites");
                    }

                }
                else
                {
                    using (StreamReader sr = new StreamReader(chemin))
                    {
                        string ligne = null;
                        ligne = sr.ReadLine();
                        while (ligne != null)
                        {
                            Console.WriteLine(ligne);
                            ligne = sr.ReadLine();
                        }
                    }
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            

            Console.ReadLine();
        }
    }
}
