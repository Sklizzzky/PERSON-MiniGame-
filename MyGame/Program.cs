using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите информацию о игроке:");
        GameCharacter player = new GameCharacter("", 0, 0, true, 100);
        player.InputCharacterInfo();

        Console.WriteLine("Введите количество персонажей:");
        int numberOfEnemies = int.Parse(Console.ReadLine());

        // Создаем список врагов для удобства удаления
        List<GameCharacter> enemies = new List<GameCharacter>();
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Console.WriteLine($"Введите информацию о враге {i + 1}:");
            GameCharacter enemy = new GameCharacter("", 0, 0, false, 50);
            enemy.InputCharacterInfo();
            enemies.Add(enemy);
        }

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Переместиться вправо");
            Console.WriteLine("2. Переместиться влево");
            Console.WriteLine("3. Переместиться вверх");
            Console.WriteLine("4. Переместиться вниз");
            Console.WriteLine("5. Атаковать врагов");
            Console.WriteLine("6. Восстановить здоровье");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    player.MoveX(1);
                    break;
                case 2:
                    player.MoveX(-1);
                    break;
                case 3:
                    player.MoveY(1);
                    break;
                case 4:
                    player.MoveY(-1);
                    break;
                case 5:
                    // Атаковать каждого врага
                    foreach (var enemy in enemies.ToArray())
                    {
                        player.Fight(enemy);

                        // Если враг был побежден, удаляем его из списка
                        if (enemy.IsDead())
                        {
                            enemies.Remove(enemy);
                        }
                    }
                    break;
                case 6:
                    player.FullRestore();
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
            }

            // Атаковать игрока, если он на клетке врага
            foreach (var enemy in enemies)
            {
                enemy.AttackPlayer(player);
            }

            // Печать информации о персонаже и врагах после каждого действия
            player.Print();
            foreach (var enemy in enemies)
            {
                enemy.Print();
            }
        }
    }
}
