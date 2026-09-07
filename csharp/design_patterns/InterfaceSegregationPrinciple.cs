using System;
using System.Reflection.Metadata;

// ReSharper disable once InvalidXmlDocComment
/// <summary>
/// Interfaces should be atomic and segrated so nobody that implements an interface
/// has to implement methods they do not need
///
/// </summary>

namespace InterfaceSegregationPrinciple
{
    public class Document
    {

    }
    /// <summary>
    /// Big ole interface with multiple methods
    /// </summary>
    public interface IMachine
    {
        public void Print(Document d);
        public void Scan(Document d);

        public void Fax(Document d);
    }

    /// <summary>
    /// So far this implementation is OK because our multi purpose printer uses all three methods
    /// But what happens when you have an old fashion printer that only does print?
    /// </summary>
    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public class OldFashionPrinter : IMachine
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }
        
        // Now we have extra stuff that we NEED to implement when it does not make sense.
        // As these operations are undefined... So now thats a bit of a problem.
        // The idea is to make sure people do not pay for what they do not need.
        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
    }

    //Lets make more atomic interface that have less concerns
    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    /// <summary>
    /// Now we can make a photocopier that could implement both interfaces
    /// </summary>
    public class PhotoCopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    // We can take it a step further and use 
    public interface IMultiFunctionDevice : IPrinter, IScanner
    {
    } //...


    // If you have an interface which includes too much stuff just break it apart
    public class MultiFunctionMachine : IMultiFunctionDevice
    {
       // Instead of implementing the methods separately why
       // don't we use delegation as such:
       private readonly IPrinter _printer;
       private readonly IScanner _scanner;

       public MultiFunctionMachine(IPrinter printer, IScanner scanner)
       {
           _printer = printer ?? throw new ArgumentNullException();
           _scanner = scanner ?? throw new ArgumentNullException();
       }

       //Delegate the calls to the printer and scanner (called the Decorator pattern) 
       public void Print(Document d)
       {
           _printer.Print(d);
       }

       public void Scan(Document d)
       {
           _scanner.Scan(d);
       }
    }

    //But what happens when you have 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
