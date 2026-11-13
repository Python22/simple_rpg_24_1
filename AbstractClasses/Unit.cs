using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_rpg_24_1.AbstractClasses
{
    public abstract class Unit
    {
        public int UnitId {  get; set; }
        public string Type { get; set; }
        public string Name {  get; set; }
        public int CurrentHp {  get; set; }
        public int MaxHp {  get; set; }
        public int CurrentStamina {  get; set; }
        public int MaxStamina {  get; set; }
        public int CurrentMana { get; set; }
        public int MaxMana { get; set; }
        public int Position_x { get; set; }
        public int Position_y { get; set; }
        public bool IsAlive { get; set; }
        public bool IsEnemy { get; set; }
        public int BaseDamage { get; set; }     // ****************
        
        protected Unit(int id, string type, string name, int current_hp, 
                       int max_hp, int current_stamina, int max_stamina, 
                       int current_mana, int max_mana, int position_x, 
                       int position_y, bool is_alive, bool is_enemy, int base_damage)   // ************
        {
            UnitId = id;
            Type = type;
            Name = name;
            CurrentHp = current_hp;
            MaxHp = max_hp;
            CurrentStamina = current_stamina;
            MaxStamina = max_stamina;
            CurrentMana = current_mana;
            MaxMana = max_mana;
            Position_x = position_x;
            Position_y = position_y;
            IsAlive = is_alive;
            IsEnemy = is_enemy;
            BaseDamage = BaseDamage;            // ******************
        }

        public void TakeDamage(int value)
        {
            if (IsAlive)
            {
                CurrentHp -= value;
                Console.WriteLine($"{Type} {Name} получает урон {value}. Сейчас у него {CurrentHp} хп.");
                if (CurrentHp <= 0)
                {
                    CurrentHp = 0;
                    IsAlive = false;
                    Console.WriteLine($"{Name} умер!");
                }
            }
        }

        public void RestoreHp(int value)
        {
            if (IsAlive && value >= 0)
            {
                CurrentHp += value;
                if (CurrentHp > MaxHp)
                {
                    CurrentHp = MaxHp;
                }
                Console.WriteLine($"{Type} {Name} получает хилку. Сейчас у него {CurrentHp} хп.");
            }
        }

        public void RestoreMana(int value)
        {
            if (IsAlive && value >= 0)
            {
                CurrentMana += value;
                if (CurrentMana > MaxMana)
                {
                    CurrentMana = MaxMana;
                }
                Console.WriteLine($"{Type} {Name} получает восстановление маны. Сейчас у него {CurrentMana} маны.");
            }
        }
        public void RestoreStamina(int value)
        {
            if (IsAlive && value >= 0)
            {
                CurrentStamina += value;
                if (CurrentStamina > MaxStamina)
                {
                    CurrentStamina = MaxStamina;
                }
                Console.WriteLine($"{Type} {Name} получает восстановление выносливости. Сейчас у него {CurrentStamina}.");
            }
        }

        public abstract void BasicAttack(Unit target);
        public void ShowInfo() {
            if (IsAlive)
            {
                Console.Write($"{Type} {Name}. ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"HP: {CurrentHp}/{MaxHp}. ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Stamina: {CurrentStamina}/{MaxStamina}. ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Mana: {CurrentMana}/{MaxMana}.");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"МЁРТВ...{Type} {Name}. ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"HP: {CurrentHp}/{MaxHp}. ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Stamina: {CurrentStamina}/{MaxStamina}. ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Mana: {CurrentMana}/{MaxMana}.");
                Console.ResetColor();
            }
        }

        public abstract void ShowAttacksAndCosts();
        public abstract void UserChoiceAttack(string user_choice, Unit target);

    }
}
