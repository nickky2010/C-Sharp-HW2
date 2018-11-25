using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_2
{
    class PhysicalMaterial
    {
        string name;    // имя
        double density; // плотность
        // Свойства для доступа к полям класса 
        public string Name { get => name; set => name = value; }
        public double Density { get => density; set => density = value; }
        public override string ToString()
        {
            return (name+";"+density);
        }
    }
}
