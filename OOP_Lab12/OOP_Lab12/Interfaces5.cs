using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab12
{
    public interface IName
    {
        string Name { get { return Name; } set { this.Name = value; } }
    }

    public interface IDrive
    {
        public void Drive(ICarManagement carManagement);
    }

    public interface ICarManagement
    {
        public void StartEngine(Engine engine);
        public int Power { get; set; }
    }
}
