using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory.CreateShape(ShapeType.Circle, new ShapeInfo() { Radius = 2 }).CalcArea().PrintArea();
            ShapeFactory.CreateShape(ShapeType.Triangle, new ShapeInfo() { Side = 2 }).CalcArea().PrintArea();
            ShapeFactory.CreateShape(ShapeType.Square, new ShapeInfo() { Width = 2,Height = 5}).CalcArea().PrintArea();
            Console.ReadLine();
        }
    }


    public abstract class Shape
    {
        protected double Area { get; set; }

        protected ShapeInfo _info { get; set; }

        public Shape(ShapeInfo info)
        {
            _info = info;
        }

        public abstract Shape CalcArea();

        public double GetArea()
        {
            return Area;
        }

        public void PrintArea()
        {
            Console.WriteLine($"Area:{Area}");
        }
    }

    public class Triangle : Shape
    {

        private double _side;

        public Triangle(ShapeInfo info) : base(info)
        {
            _side = info.Side;
        }


        public override Shape CalcArea()
        {
            Area = _side * _side * 0.5;
            return this;
        }
    }

    public class Circle : Shape
    {

        private double _radius;

        public Circle(ShapeInfo info) : base(info)
        {
            _radius = info.Radius;
        }

        public override Shape CalcArea()
        {
            Area = _radius * _radius * Math.PI;
            return this;
        }
    }

    public class Square : Shape
    {

        private double _width;

        private double _height;

        public Square(ShapeInfo info) : base(info)
        {
            _width = info.Width;
            _height = info.Height;
        }


        public override Shape CalcArea()
        {
            Area = _width * _height;
            return this;
        }
    }


    public struct ShapeInfo
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public double Radius { get; set; }

        public double Side { get; set; }
    }

    public static class ShapeFactory
    {

        public static Shape CreateShape(ShapeType type, ShapeInfo info)
        {
            switch (type)
            {
                case ShapeType.Circle:
                    return new Circle(info);
                case ShapeType.Square:
                    return new Square(info);
                case ShapeType.Triangle:
                    return new Triangle(info);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }


    public enum ShapeType
    {
        Circle,
        Square,
        Triangle
    }
}
 

