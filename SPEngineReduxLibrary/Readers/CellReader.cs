﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace SPEngineReduxLibrary.Readers
{
    class Cell
    {
        // Cell attributes.
        // We have to use properties here because hyphens are illegal in C#.

        // Cell descriptors.
        [JsonProperty(PropertyName = "cell-name")]
        public string CellName { get; set; } // Cell name.

        [JsonProperty(PropertyName = "cell-id")]
        public string CellID { get; set; } // Cell Identifier.

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; } // Cell color, in hexadecimal.

        [JsonProperty(PropertyName = "classification")]
        public int Classification { get; set; } // Cell classification. 0 for Empty Cells, 1 for Object Cells, 2 for Units.

        [JsonProperty(PropertyName = "alignment")]
        public int Alignment { get; set; } // Cell alignment. 0 for Envirnment, 1-9 for Team Alignment.

        // Does the Cell exist?
        [JsonProperty(PropertyName = "exists")]
        public bool DoesCellExist { get; set; } // Boolean. No need to explain. Largely used for Void or Invisible cells.

        // Cell traversal properties.
        [JsonProperty(PropertyName = "passable")]
        public bool IsCellPassable { get; set; } // Boolean. 0 for no, 1 for yes.

        [JsonProperty(PropertyName = "occupiable")]
        public bool CanOccupyCell { get; set; } // Can we occupy the Cell? 1 for yes, 0 for no.

        [JsonProperty(PropertyName = "destructable")]
        public bool IsCellDestructible { get; set; } // If the Cell is of type Object, can we destroy it? 1 for YES, 0 for NO.

        [JsonProperty(PropertyName = "block-ranged")]
        public bool BlocksRangedAttacks { get; set; } // Does the Cell block ranged attacks (Block Property)? 1 for YES, 0 for NO.

        // Cell statistics. Only useful if IsCellDestructible is 1 or Cell is of tye Unit (2).
        [JsonProperty(PropertyName = "has-stats")]
        public bool CellHasStats { get; set; } // Are we working with Statistics for this Cell? 1 for YES, 2 for NO.
    }

    public class CellReader
    {
        // Open the default Cell Data Bank.
        public string OpenDefaultCellBank()
        {
            string filename = Path.Combine(Directory.GetCurrentDirectory(), "JsonResources/DefaultCells.bank");
            using (StreamReader data_reader = File.OpenText(filename))
            {
                if (File.Exists(filename))
                {
                    JObject cells = JObject.Parse(filename);
                    return (string)cells;
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
        public string OpenUserCellBank(string filename)
        {
            using (StreamReader data_reader = File.OpenText(filename))
            {
                if (File.Exists(filename))
                {
                    JObject cells = JObject.Parse(filename);
                    return (string)cells;
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