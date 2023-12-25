using System;
class GameCharacter
{
    // Поля, представляющие характеристики персонажа
    private string name;            // Имя персонажа
    private int x, y;                // Координаты персонажа на игровом поле
    private bool isAlly;             // Персонаж является союзником или врагом
    private int maxHealth;           // Максимальное здоровье персонажа
    private int currentHealth;       // Текущее здоровье персонажа
    private int victories;           // Количество побед персонажа
    private int attackStrength;      // Сила атаки персонажа

    // Конструктор для создания объекта GameCharacter с начальными параметрами
    public GameCharacter(string name, int x, int y, bool isAlly, int maxHealth)
    {
        this.name = name;
        this.x = x;
        this.y = y;
        this.isAlly = isAlly;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.victories = 0;
        this.attackStrength = 0;
    }

    // Метод для заполнения информации о персонаже
    public void FillInfo(string name, int x, int y, bool isAlly, int maxHealth)
    {
        this.name = name;
        this.x = x;
        this.y = y;
        this.isAlly = isAlly;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.victories = 0;
        this.attackStrength = 0;
    }

    // Метод для вывода информации о персонаже
    public void Print()
    {
        Console.WriteLine($"Имя: {name}, Координаты: ({x}, {y}), Лагерь: {(isAlly ? "Друг" : "Враг")}, " +
            $"Максимальное здоровье: {maxHealth}, Текущее здоровье: {currentHealth}, Победы: {victories}");
    }

    // Метод для перемещения по горизонтали
    public void MoveX(int dx)
    {
        x += dx;
    }

    // Метод для перемещения по вертикали
    public void MoveY(int dy)
    {
        y += dy;
    }

    // Метод для уничтожения персонажа
    public void Destroy()
    {
        Console.WriteLine($"{name} уничтожен!");
    }

    // Метод для нанесения урона
    public void InflictDamage(int du)
    {
        if (!isAlly)
        {
            int damage = new Random().Next(1, maxHealth + 1);
            currentHealth -= damage;
            Console.WriteLine($"{name} получил урон {damage}!");
        }
    }

    // Метод для лечения персонажа
    public void Heal(int du)
    {
        if (isAlly)
        {
            currentHealth += du;
            Console.WriteLine($"{name} был вылечен на {du} единиц здоровья!");
        }
    }

    // Метод для полного восстановления здоровья после 5 побед
    public void FullRestore()
    {
        if (victories >= 5)
        {
            currentHealth = maxHealth;
            Console.WriteLine($"{name} полностью восстановил здоровье!");
        }
        else
        {
            Console.WriteLine($"{name} не может использовать полное восстановление. Необходимо 5 побед.");
        }
    }

    // Метод для проверки принадлежности лагерю
    public bool IsAlly()
    {
        return isAlly;
    }

    // Метод для проведения драки
    public void Fight(GameCharacter enemy)
    {
        if (x == enemy.x && y == enemy.y && isAlly != enemy.isAlly)
        {
            int damage = new Random().Next(1, maxHealth + 1);
            enemy.currentHealth -= damage;
            Console.WriteLine($"{name} атакует {enemy.name} и наносит {damage} урона!");
            if (enemy.currentHealth <= 0)
            {
                Console.WriteLine($"{enemy.name} был побежден!");
                victories++;
            }
        }
        else
        {
            Console.WriteLine($"{name} не может атаковать {enemy.name}. Недоступный противник.");
        }
    }

    // Метод для проверки наличия противника на текущих координатах
    public bool IsOnEnemy(GameCharacter enemy)
    {
        return x == enemy.x && y == enemy.y && isAlly != enemy.isAlly;
    }

    // Метод для атаки игрока (противника)
    public void AttackPlayer(GameCharacter player)
    {
        if (IsOnEnemy(player))
        {
            int damage = new Random().Next(1, maxHealth + 1);
            player.currentHealth -= damage;
            Console.WriteLine($"{name} атакует {player.name} и наносит {damage} урона!");
        }
    }

    // Метод для проверки смерти персонажа
    public bool IsDead()
    {
        return currentHealth <= 0;
    }
    public void InputCharacterInfo()
    {
        Console.WriteLine("Введите имя персонажа:");
        name = Console.ReadLine();

        Console.WriteLine("Выберите лагерь (1 - Друг, 2 - Враг):");
        int campChoice = int.Parse(Console.ReadLine());
        isAlly = (campChoice == 1);

        Console.WriteLine("Введите стартовые координаты X ");
        int coordinatesX = int.Parse(Console.ReadLine());
        x = coordinatesX;
        Console.WriteLine("Введите стартовые координаты Y ");
        int coordinatesY = int.Parse(Console.ReadLine());
        y = coordinatesY;
    }
}
