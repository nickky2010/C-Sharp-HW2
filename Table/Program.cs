//                                                      Задание 4.
//  Создать класс «Функция», описывающий объекты-функции из семейства функций заданного вида: 1+cos^2(x+a)/|x^3-2b^2|
//  Класс должен содержать следующие элементы: 
//      Закрытые поля для хранения значения параметров функции a и b.
//      Свойства для доступа к параметрам функции.
//      Метод для вычисления значения функции (входной параметр – значение аргумента х).
//      Метод для табулирования функции (входные параметры - хнач, хкон, шаг ∆х). 
//При хнач <= хкон шаг прибавлять, при хнач > хкон шаг вычитать(использовать тернарную операцию? :).
//      Метод ToString(), результатом которого является строковое представление функции.
//      Статический метод для ввода начального значения аргумента, конечного значения аргумента и шага изменения 
//аргумента функции (выходные параметры - хнач, хкон, шаг ∆х) Ввод продолжать до тех пор пока не будет введен шаг ∆х>= 0.

//  Создать класс «Таблица», описывающий объекты-таблицы из двух столбцов, содержащий следующие элементы:
//      Закрытые поля: заголовок таблицы, заголовки столбцов, ширина первого столбца, ширина второго столбца.
//      Конструктор с параметрами.
//      Метод для вывода шапки таблицы.
//      Метод для вывода строки таблицы (входные параметры – числовые значения, которые выводятся в строке таблицы).
//      Метод для вывода низа таблицы.

//  Разработать программу, которая выполняет следующие действия:
//      Создает два объекта класса «Функция» (параметры функций вводятся с клавиатуры).
//      Для каждого объекта вычисляет значения для трех различных значений аргумента.
//      Для каждого объекта–функции выполняет табулирование для ряда значений аргумента. 
//Результат выводить в виде таблицы, в заголовке таблицы приводить вид функции.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Создается два объекта класса «Функция» (параметры функций вводятся с клавиатуры).
            Function function1 = new Function();
            Function function2 = new Function();
            double x1 = Input(function1, 1);
            double x2 = Input(function2, 2);
            //  Для каждого объекта вычисляет значения для трех различных значений аргумента.
            Console.WriteLine(function1.PrintFunctionValue(x1, function1, out double f1));
            Console.WriteLine(function2.PrintFunctionValue(x2, function2, out double f2));
            // печатаем в виде таблицы
            Table table = new Table("f(x)=1+cos^2(x+a)/|x^3-2b^2|", new Table.Column ("123456789", 4), new Table.Column("f(x)",16), new Table.Column("x(f)",25));
            table.PrintHead(false);
            table.PrintString(x1.ToString(), f1.ToString());
            table.PrintString(x2.ToString(), f2.ToString());
            table.PrintBottom();
            //  Для каждого объекта–функции выполняет табулирование для ряда значений аргумента. 
            //  Результат выводить в виде таблицы, в заголовке таблицы приводить вид функции.
            Function.Input(out double xBegin, out double xEnd, out double xStep);
            // печатаем таблицу для 1 функции
            Console.WriteLine(function1.ToString());
            Table table1 = new Table(function1.ToString(), new Table.Column("123456789"), new Table.Column("f(x)",8));
            table1.PrintHead();
            PrintTabLineFunction(xBegin, xEnd, xStep, table1, function1);
            table1.PrintBottom();
            // печатаем таблицу для 2 функции
            Console.WriteLine(function2.ToString());
            Table table2 = new Table(function2.ToString(), new Table.Column("x"), new Table.Column("f(x)"));
            table2.PrintHead();
            PrintTabLineFunction(xBegin, xEnd, xStep, table2, function2);
            table2.PrintBottom();
            Console.ReadKey();

        }
        static double Input(Function function, int n)
        {
            Console.WriteLine("Введите параметры для {0} функции: ", n);
            Console.Write("a{0} = ", n);
            function.A = Convert.ToDouble(InpunDouble());
            Console.Write("b{0} = ", n);
            function.B = Convert.ToDouble(InpunDouble());
            Console.Write("x{0} = ", n);
            return (Convert.ToDouble(InpunDouble()));
        }
        static void PrintTabLineFunction(double xBegin, double xEnd, double xStep, Table table, Function function)
        {
            if (xBegin <= xEnd)
                for (double x = xBegin; xBegin <= xEnd; xBegin += xStep)
                {
                    table.PrintString(x.ToString(), function.calcFunction(x).ToString());
                    x = function.tabulationFunction(xBegin, xEnd, xStep);
                }
            else
                for (double x = xBegin; xBegin >= xEnd; xBegin -= xStep)
                {
                    table.PrintString(x, function.calcFunction(x));
                    x = function.tabulationFunction(xBegin, xEnd, xStep);
                }
        }
        static string InpunDouble()
        {
            string str = Console.ReadLine();
            return str.Replace('.', ',');
        }
    }
}
