using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DesignPatterns
{
    /// <summary>
    /// Illustrates the single responsibility principle:
    /// One Class should not have multiple responsibilities
    /// This is less of a pattern and more of a good advice
    /// A particular should only have one reason to change 
    /// </summary>
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntries(string text)
        {
            entries.Add($"{++count}: {text}");  
            return count; //memento pattern: more on that later
        }

        public void RemoveEntry(int index)
        {
            // not the best way
            entries.RemoveAt(index);
        }

        /// <summary>
        /// Override the ToString() 
        /// output a nicely formatted ( with new line ) 
        /// journal entries
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries); 
        }

        #region Bad Practice
        //Breaking the principle
        //Too many responsabilieties for a class separate their concerns
        //Say you wanted to add persistence to your journal
        //Journal class should only care about adding and removing entries to a journal
        //Create a different class


        //public void Save(string filename)
        //{
        //    File.WriteAllText(filename, ToString());
        //}

        //public static Journal Load(string filename)
        //{

        //}

        //public void Load(Uri uri)
        //{

        //}
        #endregion
    }

    public class Persistence
    {
        //The job of saving to a file should not belong to Journal class
        //Better separation of concerns here
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }
    }
    class SingleResponsibility
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            journal.AddEntries("Today I started one big change");
            journal.AddEntries("My girl completes me");
            Console.WriteLine(journal);

            Persistence p = new Persistence();
            var fileName = @"C:\temp\Journal.txt";
            p.SaveToFile(journal,fileName, true);

            //Starts a process .calling default program to open .txt files 
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo(fileName)
                {
                    UseShellExecute = true,
                }
            }.Start();
        }
    }
}
