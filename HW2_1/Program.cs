//                                              Задание 1. 
//  Написать игру со следующим сценарием.
//  В игре 2 участника:
//      - компьютер
//      - игрок
//  У игрока есть некоторая сумма денег - задается случайным образом в диапазоне от 100 до 500 рублей в начале игры.
//  Компьютер загадывает число в диапазоне от 1 до 100. Игрок сообщает, за сколько попыток (N) он берется отгадать это число. 
//  Если игрок угадал число за N или менее попыток, сумма на его счету увеличивается.
//  Увеличение суммы (P) должно быть тем больше, чем меньше число N. 
//  Если игрок не угадал число за N попыток, сумма на его счету уменьшается.
//  Уменьшение суммы (M) должно быть тем больше, чем больше число N.
//  Игра завершается, когда игрок выиграет 1000 рублей или когда он все проиграет.
//  Подумайте, какие зависимости P и М от N надо задать, чтобы в выигрыше в основном был игровой клуб(компьютер).
//  Для генерирования случайных чисел используйте класс Random.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HW2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            Player player = new Player();
            decimal bet;            // ставка
            while (player.Cash < 1000m && player.Cash > 0)
            {
                Console.Clear();
                Console.WriteLine("Компьютер загадает число в диапазоне от 1 до 100.");
                Console.WriteLine("Введите количество попыток за которое вы его отгадаете.");
                Console.Write("Количество попыток: ");
                player.Attempt = Convert.ToInt32(Console.ReadLine());
                // определяем ставку
                if (player.Cash > 700m)
                    bet = player.Cash * 0.05m;
                else if (player.Cash > 400m)
                    bet = player.Cash * 0.04m;
                else if (player.Cash > 100m)
                    bet = player.Cash * 0.03m;
                else if (player.Cash > 10m)
                    bet = player.Cash * 0.02m;
                else
                    bet = player.Cash;
                // загадываем случайное число
                computer.Rand();
                player.Number = 0;
                int attempt = 1; // Всего попыток угадать число
                while (computer.Number != player.Number)
                {
                    // просчет возможного выигрыша
                    decimal realBet;
                    if (player.Attempt > attempt)
                        realBet = bet + bet* (100m / player.Attempt) * 0.01m * (10m/attempt);
                    else if (player.Attempt == attempt && player.Attempt != 1)
                        realBet = bet;
                    else if (player.Attempt == attempt && player.Attempt == 1)
                        realBet = bet*100m;
                    else 
                        realBet = -bet + bet * (player.Attempt-attempt+1) * 0.1m * (attempt/2.5m);
                    // выводим на экран
                    Console.Clear();
                    Console.WriteLine($"Деньги компьютера: {computer.Cash:0.00}\t\t\tСтавка: {bet:0.00}\t\t\tДеньги игрока: {player.Cash:0.00}");
                    Console.WriteLine($"\nВаше число попыток: {player.Attempt}");
                    Console.WriteLine($"Всего попыток угадать число: {attempt++}");
                    if (realBet>0)
                        Console.WriteLine($"Ваш возможный выигрыш на данный момент: {realBet:0.00}");
                    else
                        Console.WriteLine($"Ваш проигрыш на данный момент: {realBet:0.00}");
                    Console.Write("\nВведите число: ");
                    player.Number = Convert.ToInt32(Console.ReadLine());
                    if (computer.Number != player.Number)
                    {
                        Console.WriteLine("Неверно!");
                        Thread.Sleep(1000);
                        if (realBet<0 && player.Cash < Math.Abs(realBet))
                        {
                            player.Cash += realBet;
                            computer.Cash -= realBet;
                            break;
                        }   
                    }
                    else
                    {
                        Console.WriteLine($"Верно! Загаданное число: {computer.Number}");
                        player.Cash += realBet;
                        computer.Cash -= realBet;
                    }
                }
                Console.ReadKey();
            }
            if (player.Cash >= 1000m)
                Console.WriteLine($"Вы выиграли!!! Ваш баланс на счету: {player.Cash:0.00}");
            else
                Console.WriteLine($"Вы проиграли!!! Ваш баланс на счету: {player.Cash:0.00}");
            Console.ReadKey();
        }
    }
}
