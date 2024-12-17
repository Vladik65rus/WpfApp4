using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    // Класс для представления юнита на поле
    public class Unit
    {
        private string v1;  // Приватные поля (не используются в коде)
        private UnitType warrior;  // Тип юнита
        private int v2;  // Здоровье или другие характеристики (не используются в коде)
        private int v3;  // Сила атаки или другие характеристики (не используются в коде)
        private int v4;  // Защита или другие характеристики (не используются в коде)
        private string v5;  // Дополнительные данные (не используются в коде)

        // Свойства юнита
        public string Name { get; set; }  // Имя юнита
        public UnitType Type { get; set; }  // Тип юнита (воин, лучник и т.д.)
        public int Health { get; set; }  // Здоровье юнита
        public int AttackPower { get; set; }  // Сила атаки юнита
        public int Defense { get; set; }  // Защита юнита
        public int X { get; set; }  // Координата X на поле
        public int Y { get; set; }  // Координата Y на поле
        public string UnicodeSymbol { get; set; }  // Юникод символ для шахматной фигуры

        // Конструктор для создания юнита
        public Unit(string name, UnitType type, int health, int attackPower, int defense, int mana = 0, string unicodeSymbol = null)
        {
            Name = name;
            Type = type;
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
            UnicodeSymbol = unicodeSymbol;  // Опциональный юникод символ
        }

        // Второй конструктор с параметрами для создания юнита
        public Unit(string v1, UnitType warrior, int v2, int v3, int v4, string v5)
        {
            this.v1 = v1;
            this.warrior = warrior;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;  // Дополнительный параметр
        }

        // Метод для получения урона юнитом
        public void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(damage - Defense, 0);  // Учитываем защиту
            Health -= actualDamage;  // Уменьшаем здоровье
        }

        // Проверка, жив ли юнит
        public bool IsAlive()
        {
            return Health > 0;  // Если здоровье больше 0, юнит жив
        }

        // Метод для применения уникальной способности в зависимости от типа юнита
        public void CastAbility()
        {
            switch (Type)
            {
                case UnitType.Warrior:
                    // Пример способности для воина (например, увеличение атаки)
                    AttackPower += 5;  // Увеличиваем силу атаки
                    break;
                case UnitType.Archer:
                    // Пример способности для лучника (например, дальняя атака)
                    AttackPower += 2;  // Увеличиваем силу атаки
                    break;
            }
        }
    }

    // Класс для поля игры
    public class Board
    {
        public Unit[,] Grid { get; set; }  // Игровое поле (матрица юнитов)

        // Конструктор поля с заданным размером
        public Board(int size)
        {
            Grid = new Unit[size, size];  // Инициализация матрицы поля
        }

        // Метод для размещения юнита на поле
        public void PlaceUnit(Unit unit, int x, int y)
        {
            if (Grid[x, y] == null)
            {
                Grid[x, y] = unit;  // Размещаем юнита в указанной клетке
                Console.WriteLine($"Юнит {unit.Name} добавлен в ({x}, {y})");
            }
            else
            {
                Console.WriteLine($"Клетка ({x}, {y}) уже занята!");  // Если клетка занята
            }
        }

        // Метод для удаления юнита из клетки
        public void RemoveUnit(int x, int y)
        {
            Grid[x, y] = null;  // Убираем юнита из клетки
        }

        // Метод для проверки, пустая ли клетка
        public bool IsCellEmpty(int x, int y)
        {
            return x >= 0 && x < Grid.GetLength(0) && y >= 0 && y < Grid.GetLength(1) && Grid[x, y] == null;
            // Проверяем, не выходит ли индекс за пределы массива, и пустая ли клетка
        }

    }
}
