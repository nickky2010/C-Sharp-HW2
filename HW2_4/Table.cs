using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_4
{
    //  Создать класс «Таблица», описывающий объекты-таблицы из двух столбцов, содержащий следующие элементы:
    class Table
    {
        //  Закрытые поля: заголовок таблицы, заголовки столбцов, ширина первого столбца, ширина второго столбца.
        private string headTable;   // заголовок таблицы
        private string headCol1;    // заголовок 1 столбца
        private string headCol2;    // заголовок 2 столбца
        private int lenghtCol1;     // ширина 1 столбца
        private int lenghtCol2;     // ширина 2 столбца
        //  Конструктор с параметрами.
        public Table (string headTable, string headCol1, string headCol2, int lenghtCol1, int lenghtCol2)
        {
            this.headTable = headTable;
            this.headCol1 = headCol1;
            this.headCol2 = headCol2;
            this.lenghtCol1 = lenghtCol1;
            this.lenghtCol2 = lenghtCol2;
        }
        //  Метод для вывода шапки таблицы.
        public void PrintHead ()
        {
            // первая строчка
            Console.Write("╔");
            for (int i = 0; i <= lenghtCol1; i++)
                Console.Write("═");
            for (int i = 0; i < lenghtCol2; i++)
                Console.Write("═");
            Console.WriteLine("╗");
            // вторая строчка - заголовок таблицы
            ShowCol(lenghtCol1+lenghtCol2+1 - ShowColLeft(lenghtCol1 + lenghtCol2 + 1, headTable) - headTable.Length, headTable, lenghtCol1 + lenghtCol2 + 1);
            Console.WriteLine("║");
            // третья строчка
            Console.Write("╠");
            for (int i = 0; i < lenghtCol1; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < lenghtCol2; i++)
                Console.Write("═");
            Console.WriteLine("╣");
            // четвертая строчка - заголовок 1 столбца
            ShowCol(lenghtCol1 - ShowColLeft(lenghtCol1, headCol1) - headCol1.Length, headCol1, lenghtCol1);
            // четвертая строчка - заголовок 2 столбца
            ShowCol(lenghtCol2 - ShowColLeft(lenghtCol2, headCol2) - headCol2.Length, headCol2, lenghtCol2);
            Console.WriteLine("║");
            // пятая строчка
            Console.Write("╠");
            for (int i = 0; i < lenghtCol1; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < lenghtCol2; i++)
                Console.Write("═");
            Console.WriteLine("╣");
        }
        //  Метод для вывода строки таблицы (входные параметры – числовые значения, которые выводятся в строке таблицы).
        public void PrintString(double x, double f)
        {
            string value;
            // значение 1 столбца
            value = x.ToString();
            ShowCol(lenghtCol1 - ShowColLeft(lenghtCol1, value) - value.Length, value, lenghtCol1);
            // значение 2 столбца
            value = f.ToString();
            ShowCol(lenghtCol2 - ShowColLeft(lenghtCol2, value) - value.Length, value, lenghtCol2);
            Console.WriteLine("║");
        }
        //  Метод для вывода низа таблицы.
        public void PrintBottom()
        {
            Console.Write("╚");
            for (int i = 0; i < lenghtCol1; i++)
                Console.Write("═");
            Console.Write("╩");
            for (int i = 0; i < lenghtCol2; i++)
                Console.Write("═");
            Console.WriteLine("╝");
        }

        // находим количество пробелов слева, печатаем их и возвращаем их количество
        static int ShowColLeft(int COL, string str)
        {
            int spLeft = (COL - str.Length) / 2;
            Console.Write("║");
            for (int i = 0; i < spLeft; i++)
                Console.Write(" ");
            return spLeft;
        }
        
        // печатаем значение и пробелы справа
        static void ShowCol(int spRight, string str, int COL) 
        {
            if (str.Length > COL)
                Console.Write(str.Substring(0, COL));
            else
                Console.Write(str);
            for (int i = 0; i < spRight; i++)
                Console.Write(" ");
        }
    }
}
