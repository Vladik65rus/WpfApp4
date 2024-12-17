using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;

        public MainWindow()
        {
            InitializeComponent();
            _game = new Game(8);  // Размер поля 8x8


        }
        // Обработчик события кнопки "Начать игру"

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            // Логика начала игры
            MessageBox.Show("Игра началась!");
        }
        // Добавление в игру юнита типа "Воин"

        private void AddWarrior_Click(object sender, RoutedEventArgs e)
        {
            string unicodeSymbol = "♔";  // Белый король
            Unit warrior = new Unit("Warrior", UnitType.Warrior, 100, 20, 10, unicodeSymbol);
            _game.AddUnitToPlayer(1, warrior);  // Добавление юнита для игрока 1
            DisplayUnits();  // Обновляем отображение
        }

        // Добавление в игру юнита типа "Лучник"

        private void AddArcher_Click(object sender, RoutedEventArgs e)
        {
            string unicodeSymbol = "♕";  // Белая ферзь
            Unit archer = new Unit("Archer", UnitType.Archer, 80, 30, 5, unicodeSymbol);
            _game.AddUnitToPlayer(1, archer);
            DisplayUnits();  // Обновляем отображение
        }


        private void AddMage_Click(object sender, RoutedEventArgs e)
        {
            Unit mage = new Unit("Mage", UnitType.Mage, 70, 40, 3);
            _game.AddUnitToPlayer(1, mage); // Добавление юнита для игрока 1
            DisplayUnits();
        }
        // Отображение всех юнитов на поле

        private void DisplayUnits()
        {
            GameGrid.Children.Clear();  // Очищаем игровое поле

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    // Создание кнопки для каждой клетки игрового поля

                    Button cellButton = new Button
                    {
                        Width = 60,
                        Height = 60,
                        Tag = new Point(row, col),  // Сохраняем координаты клетки
                        FontFamily = new FontFamily("Segoe UI Symbol"),  // Указываем шрифт для Unicode символов
                        FontSize = 32,  // Устанавливаем размер шрифта
                        Background = (row + col) % 2 == 0 ? Brushes.LightYellow : Brushes.Gray,  // Цвет клетки
                    };

                    Unit unit = _game.Board.Grid[row, col];  // Получаем юнита из поля

                    if (unit != null && !string.IsNullOrEmpty(unit.UnicodeSymbol))

                    {
                        // Если юнит есть, отображаем его юникод символ
                        cellButton.Content = unit.UnicodeSymbol;  // Используем юникод символ
                    }
                    else
                    {
                        // Если юнит отсутствует, показываем пустое содержимое
                        cellButton.Content = "";  // Оставляем пустым
                    }

                    // Добавляем обработчик клика
                    cellButton.Click += CellButton_Click;
                    Grid.SetRow(cellButton, row);  // Устанавливаем строку
                    Grid.SetColumn(cellButton, col);  // Устанавливаем столбец

                    GameGrid.Children.Add(cellButton);  // Добавляем кнопку в сетку
                    if (unit != null)
                    {
                        MessageBox.Show($"Юникод символ: {unit.UnicodeSymbol}");  // Проверяем юникоды
                        cellButton.Content = unit.UnicodeSymbol;  // Отображаем юникод символ
                    }

                }
            }
        }


        // Обработчик события добавления белого короля

        private void AddWhiteKing_Click(object sender, RoutedEventArgs e)
        {
            string unicodeSymbol = "♔";  // Белый король
            Unit whiteKing = new Unit("White King", UnitType.Warrior, 100, 20, 10, unicodeSymbol);
            _game.AddUnitToPlayer(1, whiteKing);  // Добавление юнита для игрока 1
            DisplayUnits();  // Обновляем отображение
        }
        // Обработчик события добавления черной ферзи

        private void AddBlackQueen_Click(object sender, RoutedEventArgs e)
        {
            string unicodeSymbol = "♛";  // Черная ферзь
            Unit blackQueen = new Unit("Black Queen", UnitType.Warrior, 100, 30, 10, unicodeSymbol);
            _game.AddUnitToPlayer(2, blackQueen);  // Добавление юнита для игрока 2
            DisplayUnits();  // Обновляем отображение
        }
        // Добавление стандартных фигур на доску (шахматные)

        private void AddPieces(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Добавление фигур на доску...");

            // Белые фигуры
            _game.Board.PlaceUnit(new Unit("White Rook", UnitType.Warrior, 100, 20, 10, "♖"), 0, 0);
            Console.WriteLine("Фигура White Rook в (0, 0): ♖");

            _game.Board.PlaceUnit(new Unit("White Knight", UnitType.Warrior, 100, 20, 10, "♘"), 0, 1);
            Console.WriteLine("Фигура White Knight в (0, 1): ♘");

            _game.Board.PlaceUnit(new Unit("White Bishop", UnitType.Warrior, 100, 20, 10, "♗"), 0, 2);
            Console.WriteLine("Фигура White Bishop в (0, 2): ♗");

            _game.Board.PlaceUnit(new Unit("White Queen", UnitType.Warrior, 100, 20, 10, "♕"), 0, 3);
            Console.WriteLine("Фигура White Queen в (0, 3): ♕");

            _game.Board.PlaceUnit(new Unit("White King", UnitType.Warrior, 100, 20, 10, "♔"), 0, 4);
            Console.WriteLine("Фигура White King в (0, 4): ♔");

            for (int i = 0; i < 8; i++)
            {
                _game.Board.PlaceUnit(new Unit("White Pawn", UnitType.Warrior, 100, 10, 5, "♙"), 1, i);
                Console.WriteLine($"Фигура White Pawn в (1, {i}): ♙");
            }

            // Черные фигуры
            _game.Board.PlaceUnit(new Unit("Black Rook", UnitType.Warrior, 100, 20, 10, "♜"), 7, 0);
            Console.WriteLine("Фигура Black Rook в (7, 0): ♜");

            _game.Board.PlaceUnit(new Unit("Black Knight", UnitType.Warrior, 100, 20, 10, "♞"), 7, 1);
            Console.WriteLine("Фигура Black Knight в (7, 1): ♞");

            _game.Board.PlaceUnit(new Unit("Black Bishop", UnitType.Warrior, 100, 20, 10, "♝"), 7, 2);
            Console.WriteLine("Фигура Black Bishop в (7, 2): ♝");

            _game.Board.PlaceUnit(new Unit("Black Queen", UnitType.Warrior, 100, 20, 10, "♛"), 7, 3);
            Console.WriteLine("Фигура Black Queen в (7, 3): ♛");

            _game.Board.PlaceUnit(new Unit("Black King", UnitType.Warrior, 100, 20, 10, "♚"), 7, 4);
            Console.WriteLine("Фигура Black King в (7, 4): ♚");

            for (int i = 0; i < 8; i++)
            {
                _game.Board.PlaceUnit(new Unit("Black Pawn", UnitType.Warrior, 100, 10, 5, "♟"), 6, i);
                Console.WriteLine($"Фигура Black Pawn в (6, {i}): ♟");
            }

            DisplayUnits();
        }


        // Метод для размещения юнита на поле

        public void PlaceUnitOnBoard(int row, int col)
        {
            // Добавляем юнит на поле в выбранную клетку
            if (_game.Board.IsCellEmpty(row, col))
            {
                Unit warrior = new Unit("Warrior", UnitType.Warrior, 100, 20, 10);
                _game.Board.PlaceUnit(warrior, row, col);
                DisplayUnits();  // Обновляем отображение
            }
            else
            {
                MessageBox.Show("Эта клетка уже занята!");
            }
        }
        // Переменная для отслеживания очередности хода

        private bool isPlayer1Turn = true;
        // Обработчик начала хода

        private void StartTurn_Click(object sender, RoutedEventArgs e)
        {
            if (isPlayer1Turn)
            {
                MessageBox.Show("Ход игрока 1");
                isPlayer1Turn = false;
            }
            else
            {
                MessageBox.Show("Ход игрока 2");
                isPlayer1Turn = true;
            }
            DisplayUnits();  // Обновляем отображение
        }
        // Переменная для выбранного юнита

        private Unit selectedUnit = null;  // Переменная для выбранного юнита

        // Обработчик клика по клетке для выбора юнита

        private void CellButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);

            MessageBox.Show($"Клетка {row},{col} нажата!");
        }



        // Обработчик выбора юнита

        private void SelectUnit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем ссылку на кнопку
                Button button = (Button)sender;

                // Получаем координаты выбранной клетки
                int row = Grid.GetRow(button);
                int col = Grid.GetColumn(button);

                selectedUnit = _game.Board.Grid[row, col];  // Попытка выбрать юнита в клетке

                if (selectedUnit == null)
                {
                    MessageBox.Show("Здесь нет юнита.");
                }
                else
                {
                    MessageBox.Show($"Выбран юнит: {selectedUnit.Name}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
        // Запуск сражения между юнитами
        private void StartBattle_Click(object sender, RoutedEventArgs e)
        {
            _game.StartBattle(); // Запускаем сражение
            DisplayUnits();  // Обновляем отображение юнитов
        }
        // Обработчик перемещения юнита

        private void MoveUnit_Click(object sender, RoutedEventArgs e)
        {
            // Логика перемещения юнита на поле
            if (selectedUnit != null)
            {
                // Проверяем, что юнит выбран, и отображаем информацию для перемещения
                MessageBox.Show($"Вы выбрали юнита {selectedUnit.Name}. Переместите его.");
            }
            else
            {
                MessageBox.Show("Выберите юнита для перемещения.");
            }
        }
        // Обработчик атаки юнита на другие юниты
        private void AttackUnit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUnit != null)
            {
                MessageBox.Show($"Юнит {selectedUnit.Name} атакует!");

                foreach (var unit in _game.Board.Grid)
                {
                    if (unit != null && unit != selectedUnit && AreUnitsAdjacent(selectedUnit, unit))
                    {
                        unit.TakeDamage(selectedUnit.AttackPower);  // Атака на соседний юнит
                        if (!unit.IsAlive())
                        {
                            MessageBox.Show($"{unit.Name} погиб!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите юнита для атаки.");
            }
        }

        // Метод для проверки соседства двух юнитов
        private bool AreUnitsAdjacent(Unit unit1, Unit unit2)
        {
            return Math.Abs(unit1.X - unit2.X) <= 1 && Math.Abs(unit1.Y - unit2.Y) <= 1;
        }

        // Обработчик изменения размера окна и масштабирования элементов
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double scale = e.NewSize.Width / 800.0;  // Масштаб относительно изначального размера
            LayoutTransform = new ScaleTransform(scale, scale);  // Применяем масштабирование
        }
    }
}
