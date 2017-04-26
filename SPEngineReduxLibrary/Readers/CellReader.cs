using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SPEngineReduxLibrary.Readers
{
    public class CellBank
    {
        // Cell properties.
        public string CellName { get; set; } // String. Name of cell, used in Legend Cells and user interface.
        public string CellID { get; set; }
        public string Color { get; set; }
        public int Classification { get; set; }
        public string Alignment { get; set; }


        public bool DoesCellExist { get; set; }


        public bool IsCellPassable { get; set; }
        public bool CanOccupyCell { get; set; }
        public bool IsCellDestructible { get; set; }
        public bool BlocksRangedAttacks { get; set; }


        public bool CellHasStats { get; set; }


        public int CurrentCellHP { get; set; }
        public int MaxCellHP { get; set; }
        public int CurrentCellMP { get; set; }
        public int MaxCellMP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int INT { get; set; }
        public int SPR { get; set; }
        public float CritChance { get; set; }
        public float EvadeChance { get; set; }
        public int Move { get; set; }
        public int XLevels { get; set; }
        public int CON { get; set; }
    }

    public class RootObject
    {
        public List<CellBank> CellBank { get; set; }
    }

    public class CellReader
    {
        // Open the default Cell Data Bank.
        public void OpenDefaultCellBank()
        {
            try
            {
                var JsonData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "JsonResources/DefaultCells.bank"));
                JArray DefaultCells = JArray.Parse(JsonData);
            }
            catch (FileNotFoundException DefaultCellBankMissingException)
            {
                throw new FileNotFoundException("Cannot find default Cell Bank. Make sure it's present in JsonResources.", DefaultCellBankMissingException);
            }
            catch (DirectoryNotFoundException JsonResourcesMissingException)
            {
                throw new DirectoryNotFoundException("Can't access the JsonResources directory. Has it been moved or deleted?", JsonResourcesMissingException);
            }
            catch (Exception ex)
            {
                throw new IOException("Unknown error opening default Cell Bank.", ex);
            }
        }

        // Print Cells out.
        public void PrintCellsToConsole()
        {
            try
            {
                var JsonData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "JsonResources/DefaultCells.bank"));

                JArray AttributeList = JArray.Parse(JsonData);
                foreach (JObject CellType in AttributeList.Children())
                {
                    Console.WriteLine("Found Cell \"{0}\" with Identifier \"{1}\" and hexcode \"{2}\".\n", CellType["CellName"].ToString(), CellType["CellID"].ToString(), CellType["Color"].ToString());
                }
            }
            catch (FileNotFoundException DefaultCellBankMissingException)
            {
                throw new FileNotFoundException("Cannot find default Cell Bank. Make sure it's present in JsonResources.", DefaultCellBankMissingException);
            }
            catch (DirectoryNotFoundException JsonResourcesMissingException)
            {
                throw new DirectoryNotFoundException("Can't access the JsonResources directory. Has it been moved or deleted?", JsonResourcesMissingException);
            }
            catch (Exception ex)
            {
                throw new IOException("Unknown error opening default Cell Bank.", ex);
            }

        }
    }
}