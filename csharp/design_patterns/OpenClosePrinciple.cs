using System;
using System.Collections.Generic;
using System.Linq;

//open close principle states: Classes should be open for extension
//but close to modification. Nobody should be going back to the filter
//And modifying the body. Use Inheritance to Extend Filter functionality
//Without modifying their body. To solve our current issue we will
//implement a enterprise pattern called the specification pattern
namespace OpenClosePrinciple
{
    //Example website with Product and a filterBy method

    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Yuge
    }

    public class Product
    {
        // bad design public field
        public string Name;

        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Color = color;
            Size = size;
        }
    }

    /// <summary>
    /// This class breaks our open closed principle
    /// </summary>
    public class ProductFiler
    {
//        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
//        {
//            foreach (var product in products)
//            {
//                /* You use a yield return statement to return each element one at a time.
//                The sequence returned from an iterator method can be consumed by using a foreach
//                statement or LINQ query. Each iteration of the foreach loop calls the iterator method.
//                When a yield return statement is reached in the iterator method, expression is returned,
//                and the current location in code is retained. Execution is restarted from that location
//                the next time that the iterator function is called.
//                You can use a yield break statement to end the iteration. */
//                if (product.Size == size)
//                    yield return product; //cool!
//            }
//        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            // using LINQ
            return products.Where(product => product.Color == color);
        }

        //// let people filter by both now
        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Color color, Size size)
        {
            // using LINQ
            return products.Where(p => p.Color == color && p.Size == size);
        }
    }

    /// <summary>
    /// Implements specification pattern where
    /// dictates whether or not a product satisfies some
    /// particular criteria for any type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<in T>
    {
        bool IsSatisfied(T type);
    }

    /// <summary>
    /// This is the expansion portion of the open/close principle
    /// wherein by having an interface we can expand the filtering
    /// mechanism in conjunction with the ISpecification interface
    /// to allow for a flexible program that could filter
    /// Many product types by more specifications.  
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFilter<T>
    {
        public IEnumerable<Product> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    /// <summary>
    /// Lets specify items by color using a more flexible interface
    /// </summary>
    ///
    public class ColorSpecification : ISpecification<Product> //could be other type
    {
        private readonly Color _color;

        public ColorSpecification(Color color)
        {
            _color = color;
        }

        /// <summary>
        /// Check if it satisfies a Product t specification
        /// This method can be used a Method group
        /// With respect to delegates, method groups provide a simple syntax to assign a method to a delegate variable.
        /// This syntax does not require explicitly invoking the delegate's constructor. Method groups allow using overloads of the method.
        /// Which overload to invoke is determined by the delegate’s signature.
        /// If an anonymous function (expression lambda or anonymous method) consists of only one method,
        /// it is possible to convert it to a method group to achieve more compact syntax and prevent compile-time overhead caused by using lambdas.
        /// https://www.jetbrains.com/help/resharper/ConvertClosureToMethodGroup.html
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSatisfied(Product t)
        {
            return t.Color == _color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }

        public bool IsSatisfied(Product type)
        {
            return type.Size == _size;
        }
    }

    /// <summary>
    /// user combinator
    /// </summary>
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _firstSpecification;
        private readonly ISpecification<T> _secondSpecification;

        public AndSpecification(ISpecification<T> firstSpecification, ISpecification<T> secondSpecification)
        {
            this._firstSpecification = firstSpecification ?? throw new NullReferenceException();
            this._secondSpecification = secondSpecification ?? throw new NullReferenceException();
        }

        public bool IsSatisfied(T type)
        {
            return _firstSpecification.IsSatisfied(type) && _secondSpecification.IsSatisfied(type);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            // Syntax is sick here huurrr - IsSatisfied is being used as a method group.
            return items.Where(spec.IsSatisfied);
        }

    }

    internal class Demo
    {
        private static void Main()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFiler();
            Console.WriteLine("Green Products (old):");

            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} is Green");
            }

            //use better filter
            var bf = new BetterFilter();
            Console.WriteLine("Green products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {p.Name} is green");
            }

            //Lets find our large blue items ;)
            Console.WriteLine("Large blue items: ");
            foreach (var p in bf.Filter(
                products,
                new AndSpecification<Product>(
                   new ColorSpecification(Color.Blue),
                   new SizeSpecification(Size.Large)))
            )
            {
                Console.WriteLine($" - {p.Name} is big and blue");
            }

            /*
             * RECAP: The Open-Close principle states that parts of a system of a subsystem should be open to extension but close to modification
             *  Like extending the functionality of a filter. but we should not have to go back to FetterFilter and add items.
             *  instead we make new classes and implement ISpecification,  and we feed that into something that's already being made.
             *  like expanding th filter criteria by feeding it a new specification;
             */
        }// main
    }// demo
}// namespace