using System;
using System.Collections.Generic;
using System.Text;

namespace DPFactoryMethodTetrisFigure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Figure dev = new SquareFigure("Квадрат");
            Creator house2 = dev.Create();


            dev = new TieFigure("Шпала");
            Creator house = dev.Create();

            Console.ReadLine();
        }
    }
    // абстрактный класс
    public abstract class Figure
    {
        public string Name { get; set; }
        public int[,] Element { get; set; }

        public Figure(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public Creator Create();

        public void Show()
        {
            for (int i = 0; i < Element.Length; i++)
            {
                for (int j = 0; j < Element.LongLength; j++)
                {
                    Console.WriteLine(Element[i, j]);
                }
            }
        }
    }
    // строит 
    public class SquareFigure : Figure
    {
        public SquareFigure(string n) : base(n)
        {
            Element = new int[4,4] { {1, 1, 1, 0}, {1, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0} };
        }

        public override Creator Create()
        {
            return new SquareForm();
        }
    }
    // строит 
    public class TieFigure : Figure
    {
        public TieFigure(string n) : base(n)
        {
            Element = new int[4, 4] { { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        }

        public override Creator Create()
        {
            return new TieForm();
        }
    }

    public abstract class Creator
    {
        public abstract Figure FactoryMethod();
    }

    public class SquareForm : Creator
    {
        public SquareForm()
        {
            //Console.WriteLine("Панельный дом построен");
        }
        public override Figure FactoryMethod() { return new SquareFigure("Квадрат"); }
    }

    public class TieForm : Creator
    {   
        public TieForm()
        {
            //Console.WriteLine("Деревянный дом построен");
        }
        public override Figure FactoryMethod() { return new TieFigure("Шпала"); }
    }
}
