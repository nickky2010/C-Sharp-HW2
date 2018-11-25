//                                          Задание 2. 
//  Разработать класс, описывающий некоторый физический материал.
//  Поля:   имя, плотность.
//  Методы: getters/setters;
//          ToString() – значения полей объекта в csv формат(например, steel;7850). 
//  Разработать класс, описывающий однородный предмет, состоящий из одного материала.
//  Поля:   имя, материал(объект класса, описанного выше), объём.
//  Методы: 
//          getters/setters;
//          GetMass() – вычисление массы предмета(= плотность* объём);
//          ToString() – объект в строку в csv формате(wire; steel;7850;0.03;235.5). 
//  В методе Main:
//          1 Создать объект Стальной_Провод из стали в объёме 0.03м3.
//          2 Вывести объект на консоль с использованием ToString().
//          3 Изменить материал провода на медь(плотность = 8500) и вывести на консоль его новую массу.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            HomogeneousObject homogeneousObject = new HomogeneousObject("wire", "steel", 7850d, 0.03);
            Console.WriteLine(homogeneousObject.ToString());
            homogeneousObject.PhysicMaterialName = "cuprum";
            homogeneousObject.PhysicMaterialDensity = 8500d;
            Console.WriteLine(homogeneousObject.ToString());
            Console.ReadKey();
        }
    }
}
