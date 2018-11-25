using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_1
{
    class Computer
    {
        int number;   // загаданное число
        decimal cash; // наличные
        // Конструктор с параметрами
        public Computer(int number = 0, decimal cash = 1000)
        {
            this.number = number;
            this.cash = cash;
        }
        // Свойства для доступа к полям класса 
        public int Number { get => number; set => number = value; }
        public decimal Cash { get => cash; set => cash = value; }
        // Свойство для загадывания случайного числа
        public void Rand()
        {
            Random rand = new Random();
            Number = rand.Next(1, 101);
        }
    }
}
