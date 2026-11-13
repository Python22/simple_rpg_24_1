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
        public int BaseDamageStaminaCost { get; set; }          // ****
        public int SimpleRangeStaminaCost { get; set; }         // *****
        public int AimedRangeStaminaCost { get; set; }          // *****

        public Archer(int id, string type, string name, int current_hp,
                       int max_hp, int current_stamina, int max_stamina,
                       int current_mana, int max_mana, int position_x,
                       int position_y, bool is_alive, bool is_enemy, int base_damage) : base(id, type, name, current_hp, max_hp, current_stamina, max_stamina, current_mana, max_mana, position_x, position_y, is_alive, is_enemy, base_damage)
        {
            SimpleRangeDamage = 20;
            AimedRangeDamage = 40;
            BaseDamageStaminaCost = 30;                         // *****
            SimpleRangeStaminaCost = 40;                        // *****
            AimedRangeStaminaCost = 90;                         // *****
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

        public void RangeSimpleAttack(Unit target)
        {
            if (CurrentStamina < SimpleRangeStaminaCost)
            {
                Console.WriteLine($"Для удара не хватило выносливости...{Name} упал...");
                return;
            }
            Console.WriteLine($"{Type} {Name} наносит простой урон в дальнем бою по {target.Name}");
            target.TakeDamage(SimpleRangeDamage);
            CurrentStamina -= SimpleRangeStaminaCost;
        }
        public void RangeAimedAttack(Unit target)
        {
            if (CurrentStamina < AimedRangeStaminaCost)
            {
                Console.WriteLine($"Для удара не хватило выносливости...{Name} упал...");
                return;
            }
            Console.WriteLine($"{Type} {Name} наносит прицельный урон в дальнем бою по {target.Name}");
            target.TakeDamage(AimedRangeDamage);
            CurrentStamina -= AimedRangeStaminaCost;
        }

        public override void ShowAttacksAndCosts()
        {
            Console.WriteLine("Возможные атаки:");
            Console.WriteLine($"\t1) Базовая атака.\n\t\tУрон: {BaseDamage}\n\t\tСтоимость выносливости: {BaseDamageStaminaCost}");
            Console.WriteLine($"\t2) Простая дальняя атака.\n\t\tУрон: {SimpleRangeDamage}\n\t\tСтоимость выносливости: {SimpleRangeStaminaCost}");
            Console.WriteLine($"\t3) Прицельная дальняя атака.\n\t\tУрон: {AimedRangeDamage}\n\t\tСтоимость выносливости: {AimedRangeStaminaCost}");
        }

        public override void UserChoiceAttack(string user_choice, Unit target) 
        {
            switch (user_choice)
            {
                case "1": BasicAttack(target); break;
                case "2": RangeSimpleAttack(target); break;
                case "3": RangeAimedAttack(target); break;
                case "0": Console.WriteLine($"{Type} {Name} пропускает этот ход."); break;
                default: Console.WriteLine("Неизвестная команда...Нет такой атаки..."); break;
            }
        }
    }
}
