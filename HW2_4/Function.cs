using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_4
{
    //  Класс «Функция», описывающий объекты-функции из семейства функций заданного вида: 1+cos^2(x+a)/|x^3-2b^2|
    class Function
    {
        //  Закрытые поля для хранения значения параметров функции a и b.
        private double a;
        private double b;
        //  Свойства для доступа к параметрам функции.
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        //  Метод для вычисления значения функции (входной параметр – значение аргумента х).
        public double calcFunction (double x)
        {
            return ((1 + Math.Pow(Math.Cos(x + a), 2d)) /Math.Abs(Math.Pow(x,3d) - 2* Math.Pow(b, 2d)));
        }
        //  Метод для табулирования функции (входные параметры - хнач, хкон, шаг ∆х). 
        //  При хнач <= хкон шаг прибавлять, при хнач > хкон шаг вычитать(использовать тернарную операцию? :).
        public double tabulationFunction (double xBegin, double xEnd, double xStep)
        {
            return (xBegin <= xEnd ? xBegin += xStep : xBegin -= xStep);
        }
        //  Метод ToString(), результатом которого является строковое представление функции.
        public override string ToString()
        {
            return ("f(x) = 1+cos^2(x+"+a+")/|x^3-2"+2*Math.Pow(b,2)+"|");
        }
        public string PrintFunctionValue(double x, Function function, out double f)
        {
            f = function.calcFunction(x);
            return ("f("+x+ ") = "+ f);
        }
        //  Статический метод для ввода начального значения аргумента, конечного значения аргумента и шага изменения 
        //  аргумента функции (выходные параметры - хнач, хкон, шаг ∆х) Ввод продолжать до тех пор пока не будет введен шаг ∆х>= 0.
        public static void Input(out double xBegin, out double xEnd, out double xStep)
        {
            Console.Write("Введите начальное значение аргумента:\nХнач = ");
            if (!double.TryParse(InpunDouble(), out xBegin))
                throw new Exception("Неправильное число");
            Console.Write("Введите конечное значение аргумента:\nХкон = ");
            if (!double.TryParse(InpunDouble(), out xEnd))
                throw new Exception("Неправильное число");
            do
            {
                Console.Write("Введите шаг изменения:\nXшаг = ");
                if (!double.TryParse(InpunDouble(), out xStep))
                    throw new Exception("Неправильное число");
            } while (xStep<=0);
        }
        static string InpunDouble()
        {
            string str = Console.ReadLine();
            return str.Replace('.', ',');
        }
    }
}
