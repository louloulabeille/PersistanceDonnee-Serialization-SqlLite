using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace PDDSerialisation
{
    // JSON
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString;
            string jsonDeserialize;
            string path = @"d:\data\client.json";
            Client cli  = new Client("Loulou", "lili");
            Client cli1 = new Client("Justine", "ahah");
            Client cli2 = new Client("Tatiana", "hihi");

            List<Client> lstClient = new List<Client>();
            lstClient.Add(cli);
            lstClient.Add(cli1);
            lstClient.Add(cli2);

            // serialisation
            //jsonString = JsonSerializer.Serialize(cli);
            jsonString = JsonSerializer.Serialize(lstClient);   // directement la liste des clients

            if ( !Directory.Exists(path.Substring( 0, path.LastIndexOf("\\")+1) ))
            {
                Directory.CreateDirectory(path.Substring(0, path.LastIndexOf("\\") + 1));
            }

            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
            }

            // -- écriture dans le fichier
            //File.WriteAllText(path, jsonString );
            
            // ou
            using (StreamWriter sw = new StreamWriter(path))
            {
               sw.WriteLine(jsonString);
            }

            // supprime les enregistrements de la liste
            lstClient.Clear();

            //lecture du fichier json
            //jsonDeserialize = File.ReadAllText(path);

            //
            using(StreamReader sr = new StreamReader(path)) {
                jsonDeserialize = sr.ReadLine();//lecture de la première ligne
            }

            lstClient = JsonSerializer.Deserialize<List<Client>>(jsonDeserialize);  
            // désrialize une liste de client
            //Client cliDeserialize = JsonSerializer.Deserialize<Client>(jsonDeserialize);
            //Console.WriteLine(cliDeserialize.ToString());

            foreach (Client client in lstClient)
            {
                Console.WriteLine(client.ToString());
            }

            Console.ReadLine();

        }
    }
}
