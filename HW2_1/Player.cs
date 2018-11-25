using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_1
{
    class Player
    {
        int number;   // вариант загаданного числа
        decimal cash; // наличные игрока
        int attempt;  // количество попыток игрока
        public Player()
        {
            Random rand = new Random();
            cash = rand.Next(100, 501);
            number = 0;
        }
        // Свойства для доступа к полям класса 
        public int Number { get => number; set => number = value; }
        public decimal Cash { get => cash; set => cash = value; }
        public int Attempt { get => attempt; set => attempt = value; }
    }
}
