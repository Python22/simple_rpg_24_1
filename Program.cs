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
                200,
                200,
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
                150,
                150,
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
                150,
                150,
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
                Console.ReadLine();
                foreach (var unit in party)
                {
                    Console.WriteLine($"Сейчас очередь {unit.Name}...");

                }
            }

        }
    }
}
