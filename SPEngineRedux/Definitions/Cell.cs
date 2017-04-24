using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using SPEngineRedux.Utilities;

namespace SPEngineRedux.Definitions
{
    class Cell
    {
        // Cell attributes.
        // We have to use properties here because hyphens are illegal in C#.
        [JsonProperty(PropertyName = "cell-name")]
        public string cellname; // Cell name.

        [JsonProperty(PropertyName = "cell-id")]
        public char cellid; // Cell Identifier.

        [JsonProperty(PropertyName = "cell-color")]
        public string cellcolor; // Cell color, in hexadecimal.


        // Open the default Cell Bank.
        public void OpenDefaultCellBank()
        {
            JsonUtilities.ReadCellJson("//JsonResources/cell_bank.json");
        }
    }
}
