using simple_rpg_24_1.AbstractClasses;
using simple_rpg_24_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_rpg_24_1.ConcreteClasses
{
    public class Archer : Unit, IRangedUnit
    {
        public int SimpleRangeDamage { get; set; }
        public int AimedRangeDamage { get; set; }
        
        public Archer(int id, string type, string name, int current_hp,
                       int max_hp, int current_stamina, int max_stamina,
                       int current_mana, int max_mana, int position_x,
                       int position_y, bool is_alive, bool is_enemy, int base_damage) : base(id, type, name, current_hp, max_hp, current_stamina, max_stamina, current_mana, max_mana, position_x, position_y, is_alive, is_enemy, base_damage)
        {
            SimpleRangeDamage = 20;
            AimedRangeDamage = 40;
        }

        public override void BasicAttack(Unit target)
        {
            Console.WriteLine($"{Type} {Name} наносит простой урон в ближнем бою по {target.Name}");
            target.TakeDamage(BaseDamage);
            CurrentStamina -= 30;
        }

        public void RangeSimpleAttack(Unit target)
        {
            Console.WriteLine($"{Type} {Name} наносит простой урон в дальнем бою по {target.Name}");
            target.TakeDamage(SimpleRangeDamage);
            CurrentStamina -= 40;
        }
        public void RangeAimedAttack(Unit target)
        {
            Console.WriteLine($"{Type} {Name} наносит прицельный урон в дальнем бою по {target.Name}");
            target.TakeDamage(AimedRangeDamage);
            CurrentStamina -= 90;

        }

    }
}
