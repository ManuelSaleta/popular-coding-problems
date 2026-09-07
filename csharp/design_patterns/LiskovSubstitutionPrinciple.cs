using System;

// ReSharper disable once InvalidXmlDocComment
/// <summary>
/// Who is Barbara Liskov?
/// https://en.wikipedia.org/wiki/Barbara_Liskov
/// Main idea you should be able to substite a base type for sub-type.
/// What it means: Liskov's principle states that you should always be able to 'up-cast' to your base type (Rectangle)
// And maintain the same operation. I.E the Square sq should still behave as a Square even when you're 
// getting a reference to a Rectangle.
/// </summary>
namespace LiskovSubstitutionPrinciple
{
    public class Rectangle
    {
        public Rectangle()
        {
        }

        public Rectangle(int width, int height)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Width = width;
            // ReSharper disable once VirtualMemberCallInConstructor
            Height = height;
        }

        // Pre fix: 
        // public int Width { get; set; } = 0;
        // public int Height { get; set; } = 0;

        // Post fix: using virtual will ensure that the compiler will 
        // look at the setters from Square since there is an override
        // of Width and Height there
        public virtual int Width { get; set; } = 0;
        public virtual int Height { get; set; } = 0;

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    /// <summary>
    /// You can start to see why implementing a Square from a Rectangle
    /// will be a bad idea and make it difficult to leverage our pattern
    /// </summary>
    public class Square : Rectangle
    {
        // Pre fix:
        // public new int Width
        // {
        //     set => base.Width = base.Height = value;
        // }
        //
        // public new int Height
        // {
        //     set => base.Height = base.Width = value;
        // }

        // Post fix:
        public override int Width
        {
            set => base.Width = base.Height = value;
        }
        
        public override int Height
        {
            set => base.Height = base.Width = value;
        }

    }

    internal class Program
    {
        public static int Area(Rectangle r) => r.Width * r.Height;

        private static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            
            // Post fix
            // Square sq = new Square
            // {
            //     Width = 4
            // };

            //Based on inheritance you would think you could legally change Square sq to 
            Rectangle sq = new Square();
            // You would expect the same behavior meaning sq as a new Square should have an area of
            // height * width, instead you get area: 0 because we are only setting the Width not height:
            // Liskov's principle states that you should always be able to 'up-cast' to your base type (Rectangle)
            // And maintain the same operation. I.E the Square sq should still behave as a Square even when you're 
            // getting a reference to a Rectangle. 

            // FIX: To uphold this principle the fix is to make sure that if there is an override of width and height
            // to be indicated as such. Like make the properties virtual in base class and override them in the derived
            // class.

            sq.Width = 4;
            
           // with the Post fix code, our Rectangle sq = new Square() will operate correctly

            Console.WriteLine($"{rc} has area: {Area(rc)}");
            Console.WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}