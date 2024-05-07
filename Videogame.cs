using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal class Videogame
    {

        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime Release {  get; set; }
        public int Id_software { get; set; }

        public Videogame(string name, string overview, DateTime release, int id)
        {
            Overview = overview;
            Name = name;
            Id_software = id;
            Release = release;
        }


    }
}
