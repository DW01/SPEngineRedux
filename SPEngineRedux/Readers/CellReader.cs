using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SPEngineRedux.Definitions;
using SPEngineRedux.Utilities;


namespace SPEngineRedux.Readers
{
    class CellReader
    {
        // Open the default Cell Data Bank.
        public void OpenDefaultCellBank()
        {
            JsonUtilities.ReadCellJson("//JsonResources/cell_bank.json");
        }

        // Open a user-defined Cell Data Bank.
        public void OpenUserCellBank(string filename)
        {
            JsonUtilities.ReadCellJson(filename);
        }
    }
}
