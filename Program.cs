using System;
using System.Collections.Generic;
using System.Text;

namespace DPFactoryMethodTetrisFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure dev = new SquareFigure("ООО КирпичСтрой");
            House house2 = dev.Create();

            dev = new TieFigure("Частный застройщик");
            House house = dev.Create();

            Console.ReadLine();
        }
    }
    // абстрактный класс строительной компании
    abstract class Figure
    {
        public string Name { get; set; }

        public Figure(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public House Create();
    }
    // строит панельные дома
    class SquareFigure : Figure
    {
        public SquareFigure(string n) : base(n)
        { }

        public override House Create()
        {
            return new PanelHouse();
        }
    }
    // строит деревянные дома
    class TieFigure : Figure
    {
        public TieFigure(string n) : base(n)
        { }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    abstract class House
    { }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        }
    }
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }
}
