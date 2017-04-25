using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public static void OpenDefaultCellBank()
        {
            string filename = "//JsonResources/cell_bank.json";
            using (StreamReader data_reader = File.OpenText(filename))
            {
                if (File.Exists(filename))
                {
                    JObject cells = JObject.Parse(filename);
                }
                else if (!File.Exists(filename))
                {
                    throw new FileNotFoundException("Cannot find default Cell Bank. Make sure it's present in JsonResources.");
                }
                else
                {
                    throw new IOException("Unknown error opening default Cell Bank.");
                }
            }
        }

        // Open a user-defined Cell Data Bank.
        public void OpenUserCellBank(string filename)
        {
            using (StreamReader data_reader = File.OpenText(filename))
            {
                if (File.Exists(filename))
                {
                    JObject cells = JObject.Parse(filename);
                }
                else if (!File.Exists(filename))
                {
                    throw new FileNotFoundException("Cannot find Cell Bank. Make sure it's present in JsonResources.");
                }
                else
                {
                    throw new IOException("Unknown error opening Cell Bank.");
                }
            }
        }
    }
}
