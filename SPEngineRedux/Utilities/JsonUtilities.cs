using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using SPEngineRedux.Definitions;

namespace SPEngineRedux.Utilities
{
    class JsonUtilities
    {
        // JSON reader function.
        public static void ReadCellJson(string filename)
        {
            using (StreamReader data_reader = File.OpenText(filename))
            {
                string json = data_reader.ReadToEnd();
                List<Cell> cells = JsonConvert.DeserializeObject<List<Cell>>(json);
            }
        }
    }
}
