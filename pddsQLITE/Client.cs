using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDSqlite
{
    public class Client
    {
        private string _nom;
        private string _prenom;

        public Client() { }

        public Client(string nom, string prenom)
        {
            _nom = nom;
            _prenom = prenom;
        }

        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }

        public override string ToString()
        {
            return "Nom et prénom de la personne :" + _nom + " " + _prenom;
        }

    }
}
