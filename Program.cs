using simple_rpg_24_1.AbstractClasses;
using simple_rpg_24_1.ConcreteClasses;

namespace simple_rpg_24_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Простая пошаговая рпг...");
            int units_id = 1;
            Archer vasya = new Archer(
                units_id,
                "лучник",
                "Вася",
                300,
                300,
                200,
                200,
                0,
                0,
                0,
                0,
                true,
                false,
                20
            );
            units_id++;

            Archer petya = new Archer(
                units_id,
                "лучник",
                "Петя",
                250,
                250,
                150,
                150,
                0,
                0,
                0,
                0,
                true,
                false,
                25
            );
            units_id++;

            Mage gendalf = new Mage(
                units_id,
                "маг",
                "Гендальф",
                250,
                250,
                150,
                150,
                200,
                200,
                0,
                0,
                true,
                false,
                25
            );
            units_id++;

            Mage boss = new Mage(
                units_id,
                "маг",
                "Селестия",
                1000,
                1000,
                1000,
                1000,
                1000,
                1000,
                0,
                0,
                true,
                true,
                60
            );
            units_id++;

            Unit[] party = { vasya, petya, gendalf };

            int round = 1;

            while (true)
            {
                Console.WriteLine($"Раунд {round}");
                foreach (var unit in party)
                {
                    unit.ShowInfo();
                }
                Console.Write("\nБосс: ");
                boss.ShowInfo();
                foreach (var unit in party)
                {
                    Console.WriteLine($"Сейчас ходит {unit.Name}...");
                    unit.ShowAttacksAndCosts();
                    Console.WriteLine("Введите номер атаки(0 для пропуска хода)");
                    string user_choice = Console.ReadLine();
                    unit.UserChoiceAttack(user_choice, boss);
                }

                // ход босса
                var random = new Random();
                int target_index = random.Next(0, party.Length);    // 0 1 2
                int random_attack_number = random.Next(2, 4);       // 1 2 3
                if (party[target_index].IsAlive)
                {
                    switch (random_attack_number) 
                    {
                        case 1: boss.BasicAttack(party[target_index]); break;
                        case 2: boss.FireballAttack(party[target_index]); break;
                        case 3: boss.ElectricAttack(party[target_index]); break;
                    }
                }
            }

        }
    }
}
