using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace PDDSqlite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string pathBdd = @"d:\data\bdd.sqlite";
            
            GestionBddSdlite bdd = new GestionBddSdlite(path: @"d:\data\bdd.sqlite", "bdd");
            bdd.CreateBdd();

            // ajouter des données
            /*
            bdd.AddData("Loulou", "lili");
            bdd.AddData("Tatiana", "hihi"); 
            */

            //bdd.ReadAll();
            bdd.ReadClient("Loulou");

            Console.ReadLine();
        }
    }
}
