using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Char
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int DM { get; set; }

        public Char(string name,int hp,int dm)
        {
            Name = name;
            HP = hp;
            DM = dm;
        }
    }
}
