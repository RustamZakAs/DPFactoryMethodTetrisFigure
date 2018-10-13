using System;
using System.Collections.Generic;
using System.Text;

namespace DPFactoryMethodTetrisFigure
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Creator> CreatorList = new List<Creator>();
            CreatorList.Add(new SquareForm());
            CreatorList.Add(new TieForm());

            Random r = new Random();

            //for (int i = 0; i < CreatorList.Count; i++)
            //{
            //    Figure f = CreatorList[r.Next(0, CreatorList.Count)].FactoryMethod();
            //    f.Show();
            //}

            while (true)
            {
                Figure f = CreatorList[r.Next(0, CreatorList.Count)].FactoryMethod();
                f.Show();
                Console.ReadLine();
            }

            //Console.ReadLine();
        }
    }
    // абстрактный класс
    public abstract class Figure
    {
        public string Name { get; set; }
        public int[,] Element { get; set; }
        public ConsoleColor color { get; set; }

        public Figure(string n)
        {
            Name = n;
        }

        public void Show()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(Element[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
    // строит 
    public class BigSquareFigure : Figure
    {
        public BigSquareFigure(string n) : base(n)
        {
            Element = new int[4,4] { {1, 1, 1, 1}, {1, 1, 1, 1}, {1, 1, 1, 1}, {1, 1, 1, 1} };
        }
    }
    // строит 
    public class TieFigure : Figure
    {
        public TieFigure(string n) : base(n)
        {
            Element = new int[4, 4] { { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
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
            Console.WriteLine("");
        }
        public override Figure FactoryMethod() { return new BigSquareFigure("Большой Квадрат"); }
    }

    public class TieForm : Creator
    {   
        public TieForm()
        {
            Console.WriteLine("");
        }
        public override Figure FactoryMethod() { return new TieFigure("Верхняя Шпала"); }
    }
}
