using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_2
{
    class HomogeneousObject
    {
        string name;                                                // имя
        PhysicalMaterial physicalMaterial = new PhysicalMaterial(); // материал
        double volume;                                              // объём
        // конструктор
        public HomogeneousObject(string name, string physicMaterialName, double physicMaterialDensity, double volume)
        {
            this.name = name;
            physicalMaterial.Name = physicMaterialName;
            physicalMaterial.Density = physicMaterialDensity;
            this.volume = volume;
        }
        // Свойства для доступа к полям класса 
        public string Name { get => name; set => name = value; }
        public string PhysicMaterialName { get => physicalMaterial.Name; set => physicalMaterial.Name = value; }
        public double PhysicMaterialDensity { get => physicalMaterial.Density; set => physicalMaterial.Density = value; }
        public double Volume { get => volume; set => volume = value; }
        public double GetMass ()
        {
            return physicalMaterial.Density * volume;
        }
        public override string ToString()
        {
            return (name+";"+physicalMaterial.ToString()+";"+volume+";"+GetMass());
        }
    }
}
