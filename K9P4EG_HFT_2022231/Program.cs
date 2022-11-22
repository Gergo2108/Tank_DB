using K9P4EG_HFT_2022231.Repository.Database;
using System;
using System.Linq;

namespace K9P4EG_HFT_2022231
{
    class Program
    {
        static void Main(string[] args)
        {
            TankDbContex db = new TankDbContex();
            var q1 = db.Tanks.ToArray();
            ;
        }
    }
}
