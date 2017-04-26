using SPEngineReduxLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEngineReduxDefaultCellTester
{
    class Program
    {
        static void Main(string[] args)
        {
            SPEngineReduxLibrary.Readers.CellReader cellreader = new SPEngineReduxLibrary.Readers.CellReader();
            cellreader.PrintCellsToConsole();
            Console.ReadLine();
        }
    }
}
