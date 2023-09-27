using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PDDSqlite
{
    internal class GestionBddSdlite
    {
        private string _path;
        private string _name;

        public GestionBddSdlite(string path, string name)
        {
            _path = path;
            _name = name;
        }

        public string Path { get => _path; set => _path = value; }
        public string Name { get => _name; set => _name = value; }

        //vérifie si la base existe sino va la créer
        public void CreateBdd ()
        {
            try
            {
                // recherche si  le repertoire existe sinon il va le créer
                if (!Directory.Exists(_path.Substring(0, _path.LastIndexOf("\\") + 1)))
                {
                    Directory.CreateDirectory(_path);
                }

                // recherche si le fichier existe sinon il le créée
                if (!File.Exists(_path))
                {
                    SQLiteConnection.CreateFile(_path);
                    using (SQLiteConnection con = new SQLiteConnection("Data Source=" + _path + ";Version=3;"))
                    {
                        string sql = "create table Clients (nom varchar(20), prenom varchar(20) )";
                        con.Open();

                        //SQLiteCommand cmd = new SQLiteCommand(sql, con);  // cela marche aussi mais enlever cette ligne cmd.CommandText = sql;
                        SQLiteCommand cmd = con.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public int AddData(string n, string m)
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + _path + ";Version=3;"))
            {
                try
                {
                    string sql = $"INSERT into Clients(nom,prenom) Values('{n.Trim()}','{m.Trim()}')";

                    con.Open();
                    SQLiteCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            return 1;
        }

        public int ReadAll() {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + _path + ";Version=3;"))
            {
                try
                {
                    string sql = $"select * from Clients";

                    con.Open();
                    SQLiteCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql;
                    
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"Nom : {reader.GetString(0)}" );
                        Console.WriteLine($"Prenom : {reader.GetString(1)}");
                    }

                    reader.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            return 1;
        }

        public int ReadClient(string n)
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + _path + ";Version=3;"))
            {
                try
                {
                    string sql = $"select * from Clients where nom='"+n.Trim()+"'";

                    con.Open();
                    SQLiteCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql;

                    SQLiteDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    Console.WriteLine($"Nom : {reader.GetString(0)}");
                    Console.WriteLine($"Prenom : {reader.GetString(1)}");
                    

                    reader.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            return 1;
        }
    }
}
