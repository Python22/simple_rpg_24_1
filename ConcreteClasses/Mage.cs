using simple_rpg_24_1.AbstractClasses;
using simple_rpg_24_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_rpg_24_1.ConcreteClasses
{
    public class Mage : Unit, IBattleMageUnit, IHealerUnit
    {
        public int BaseDamageStaminaCost { get; set; }
        public int FireballAttackManaCost { get; set; }
        public int ElectricAttackManaCost { get; set; }
        public int HealManaCost { get; set; }

        public int FireballAttackDamage { get; set; }
        public int ElectricAttackDamage { get; set; }
        public int HealValue { get; set; }

        public Mage(int id, string type, string name, int current_hp,
                       int max_hp, int current_stamina, int max_stamina,
                       int current_mana, int max_mana, int position_x,
                       int position_y, bool is_alive, bool is_enemy, int base_damage) : base(id, type, name, current_hp, max_hp, current_stamina, max_stamina, current_mana, max_mana, position_x, position_y, is_alive, is_enemy, base_damage)
        {
            BaseDamageStaminaCost = 70;                         // *****
            FireballAttackManaCost = 30;
            ElectricAttackManaCost = 40;
            HealManaCost = 50;
            FireballAttackDamage = 50;
            ElectricAttackDamage = 60;
            HealValue = 30;
        }
        public override void BasicAttack(Unit target)
        {
            if (CurrentStamina < BaseDamageStaminaCost)
            {
                Console.WriteLine($"Для удара не хватило выносливости...{Name} упал...");
                return;
            }
            Console.WriteLine($"{Type} {Name} наносит простой урон в ближнем бою по {target.Name}");
            target.TakeDamage(BaseDamage);
            CurrentStamina -= BaseDamageStaminaCost;
        }

        public void FireballAttack(Unit target) 
        { 
            if (CurrentMana < FireballAttackManaCost)
            {
                Console.WriteLine($"Для атаки не хватило маны...{Name} уснул...");
                return;
            }
            Console.WriteLine($"{Type} {Name} наносит урон файерболом по {target.Name}");
            target.TakeDamage(FireballAttackDamage);
            CurrentMana -= FireballAttackManaCost;
        }
        public void ElectricAttack(Unit target)             // **
        {
            if (CurrentMana < ElectricAttackManaCost)       // **
            {
                Console.WriteLine($"Для атаки не хватило маны...{Name} уснул...");
                return;
            }
            Console.WriteLine($"{Type} {Name} наносит урон файерболом по {target.Name}");
            target.TakeDamage(ElectricAttackDamage);        // **
            CurrentMana -= ElectricAttackManaCost;          // **
        }
        public void HealTarget(Unit target)                 // **
        {
            if (CurrentMana < HealManaCost)       // **
            {
                Console.WriteLine($"Для хилки не хватило маны...{Name} уснул...");  // **
                return;
            }
            Console.WriteLine($"{Type} {Name} лечит {target.Name}");                // **
            target.RestoreHp(HealValue);        // **
            CurrentMana -= HealManaCost;        // **
        }
    }
}
