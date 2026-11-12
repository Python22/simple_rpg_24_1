using simple_rpg_24_1.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_rpg_24_1.Interfaces
{
    internal interface IRangedUnit
    {
        public void RangeSimpleAttack(Unit target);
        public void RangeAimedAttack(Unit target);
    }
}
