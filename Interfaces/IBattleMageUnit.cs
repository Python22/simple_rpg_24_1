using simple_rpg_24_1.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_rpg_24_1.Interfaces
{
    internal interface IBattleMageUnit
    {
        public void FireballAttack(Unit target);
        public void ElectricAttack(Unit target);

    }
}
