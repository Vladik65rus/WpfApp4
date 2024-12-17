using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp4
{
    // Класс для представления игры
    public class Game
    {
        public Board Board { get; set; }  // Игровое поле
        public List<Unit> Player1Units { get; set; }  // Список юнитов игрока 1
        public List<Unit> Player2Units { get; set; }  // Список юнитов игрока 2

        // Конструктор игры с заданным размером поля
        public Game(int boardSize)
        {
            Board = new Board(boardSize);  // Создаем игровое поле
            Player1Units = new List<Unit>();  // Инициализируем список юнитов для игрока 1
            Player2Units = new List<Unit>();  // Инициализируем список юнитов для игрока 2
        }

        // Метод для проверки окончания игры
        public bool CheckGameOver()
        {
            // Если у игрока 1 нет юнитов, игрок 2 побеждает
            if (Player1Units.Count == 0)
            {
                MessageBox.Show("Игрок 2 победил!");
                return true;
            }

            // Если у игрока 2 нет юнитов, игрок 1 побеждает
            if (Player2Units.Count == 0)
            {
                MessageBox.Show("Игрок 1 победил!");
                return true;
            }

            // Игра продолжается, если у обоих игроков есть юниты
            return false;
        }

        // Метод для начала сражения
        public void StartBattle()
        {
            // Перебираем всех юнитов игрока 1
            foreach (var unit1 in Player1Units)
            {
                // Перебираем всех юнитов игрока 2
                foreach (var unit2 in Player2Units)
                {
                    // Проверяем, находятся ли юниты рядом
                    if (AreUnitsAdjacent(unit1, unit2))
                    {
                        // Атака юнитов (каждый юнит атакует другого)
                        unit1.TakeDamage(unit2.AttackPower);
                        unit2.TakeDamage(unit1.AttackPower);

                        // Проверка на живучесть: если юнит мертв, удаляем его из списка
                        if (!unit1.IsAlive()) Player1Units.Remove(unit1);
                        if (!unit2.IsAlive()) Player2Units.Remove(unit2);
                    }
                }
            }

            // Проверка окончания игры после сражения
            CheckGameOver();
        }

        // Метод для проверки, находятся ли два юнита на соседних клетках
        private bool AreUnitsAdjacent(Unit unit1, Unit unit2)
        {
            // Проверяем разницу координат для соседних клеток
            return Math.Abs(unit1.X - unit2.X) <= 1 && Math.Abs(unit1.Y - unit2.Y) <= 1;
        }

        // Метод для добавления юнита на поле для игрока
        public void AddUnitToPlayer(int playerNumber, Unit unit)
        {
            if (playerNumber == 1)
                Player1Units.Add(unit);  // Добавляем юнита в список игрока 1
            else
                Player2Units.Add(unit);  // Добавляем юнита в список игрока 2
        }

    }

}
