using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    internal class User
    {
        public delegate void UpgradeHandler(string message, string issue);
        public event UpgradeHandler? UpgradeNotify;

        UpgradeHandler UpgradeHandle = (str1, str2) => Console.WriteLine(str1 + '\t' + str2);

        public delegate void workHandler();
        public event workHandler? workNotify;

        int lvlCup = 0;
        public void Upgrade()
        {
            UpgradeHandle($"{lvlCup}", "lvl");
            Console.WriteLine("Upgrades maaaaaaan");
        }

        public void Work()
        {
            lvlCup++;
            if (lvlCup % 4 == 0)
            {
                workNotify?.Invoke();
            }
        }
    }
}
